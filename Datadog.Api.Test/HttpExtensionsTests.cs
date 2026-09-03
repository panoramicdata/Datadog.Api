using Datadog.Api;
using System.Net.Http;
using System.Net.Http.Headers;
using Xunit;

namespace Datadog.Api.Test;

/// <summary>
/// Tests for header redaction in diagnostic output.
///
/// <para>
/// <c>AuthenticatedHttpClientHandler</c> adds <c>DD-API-KEY</c> and, where configured,
/// <c>DD-APPLICATION-KEY</c> to every request, then joined every header key and value into its
/// Debug level log message. Both keys were therefore written verbatim wherever those messages
/// ended up.
/// </para>
///
/// <para>
/// Datadog does not use an Authorization header, and neither key expires. A redaction list copied
/// from a sibling package would have missed both, and an exposed pair stays usable until it is
/// revoked.
/// </para>
///
/// <para>
/// These are pure unit tests. They construct headers directly and require no credentials, no
/// configuration and no live account.
/// </para>
/// </summary>
public class HttpExtensionsTests
{
	private const string FakeApiKey = "0123456789abcdef0123456789abcdef";
	private const string FakeApplicationKey = "fedcba9876543210fedcba9876543210fedcba98";

	/// <summary>
	/// The headline case: both Datadog keys must go, set exactly as the handler sets them.
	/// </summary>
	[Fact]
	public void ToDebugString_BothDatadogKeys_AreRedacted()
	{
		using var request = new HttpRequestMessage();
		request.Headers.Add("DD-API-KEY", FakeApiKey);
		request.Headers.Add("DD-APPLICATION-KEY", FakeApplicationKey);

		var debugString = request.Headers.ToDebugString();

		debugString.Should().NotContain(FakeApiKey);
		debugString.Should().NotContain(FakeApplicationKey);
		debugString.Should().Contain($"DD-API-KEY: <redacted, length {FakeApiKey.Length}>");
		debugString.Should().Contain($"DD-APPLICATION-KEY: <redacted, length {FakeApplicationKey.Length}>");
	}

	/// <summary>
	/// Proves the defect being fixed: the previous rendering leaked, the replacement does not.
	/// </summary>
	[Fact]
	public void ToDebugString_UnlikeTheOldJoin_DoesNotContainTheKey()
	{
		using var request = new HttpRequestMessage();
		request.Headers.Add("DD-API-KEY", FakeApiKey);

		// This is exactly what the handler did before the fix.
		var previousRendering = string.Join(
			"\n",
			request.Headers.Select(h => $"{h.Key}: {string.Join(", ", h.Value.Select(v => v))}"));

		previousRendering.Should().Contain(FakeApiKey, "the previous rendering is what leaked");
		request.Headers.ToDebugString().Should().NotContain(FakeApiKey);
	}

	/// <summary>
	/// A header added without validation keeps whatever casing the caller used.
	/// </summary>
	/// <param name="headerName">The header name casing under test.</param>
	[Theory]
	[InlineData("dd-api-key")]
	[InlineData("DD-Api-Key")]
	[InlineData("dd-application-key")]
	[InlineData("DD-Application-Key")]
	public void ToDebugString_DatadogKeys_AreRedactedWhateverTheCasing(string headerName)
	{
		using var request = new HttpRequestMessage();
		request.Headers.TryAddWithoutValidation(headerName, FakeApiKey);

		var debugString = request.Headers.ToDebugString();

		debugString.Should().NotContain(FakeApiKey);
		debugString.Should().Contain("<redacted");
	}

	/// <summary>
	/// The standard credential-bearing header names are redacted too.
	/// </summary>
	/// <param name="headerName">The credential-bearing header name under test.</param>
	[Theory]
	[InlineData("Authorization")]
	[InlineData("Proxy-Authorization")]
	[InlineData("Cookie")]
	[InlineData("X-API-Key")]
	[InlineData("Api-Key")]
	[InlineData("X-Api-Token")]
	[InlineData("X-Auth-Token")]
	public void ToDebugString_StandardCredentialHeaders_AreRedacted(string headerName)
	{
		const string secret = "s3cr3t-value-that-must-not-be-logged";
		using var request = new HttpRequestMessage();
		request.Headers.TryAddWithoutValidation(headerName, secret);

		var debugString = request.Headers.ToDebugString();

		debugString.Should().NotContain(secret);
		debugString.Should().Contain("<redacted");
	}

	/// <summary>
	/// Where a scheme is present it is kept, because knowing which mechanism was used aids diagnosis.
	/// </summary>
	[Fact]
	public void ToDebugString_BearerToken_KeepsTheSchemeAndLength()
	{
		const string token = "abcdefghijklmnopqrstuvwxyz0123456789";
		using var request = new HttpRequestMessage();
		request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

		var debugString = request.Headers.ToDebugString();

		debugString.Should().Be($"Authorization: Bearer <redacted, length {token.Length}>");
	}

	/// <summary>
	/// A cookie value also contains a space, so treating the text before the first space as a scheme
	/// would preserve the very value being redacted. Only Authorization style headers keep a scheme.
	/// </summary>
	[Fact]
	public void ToDebugString_CookieValueContainingASpace_IsRedactedWhole()
	{
		const string cookie = "session=abc123def456; HttpOnly";
		using var request = new HttpRequestMessage();
		request.Headers.TryAddWithoutValidation("Cookie", cookie);

		var debugString = request.Headers.ToDebugString();

		debugString.Should().Be($"Cookie: <redacted, length {cookie.Length}>");
		debugString.Should().NotContain("session=");
	}

	/// <summary>
	/// Redaction must be surgical: the useful headers alongside the keys must survive intact.
	/// </summary>
	[Fact]
	public void ToDebugString_RedactsOnlyTheSensitiveHeaders()
	{
		using var request = new HttpRequestMessage();
		request.Headers.Add("DD-API-KEY", FakeApiKey);
		request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		request.Headers.TryAddWithoutValidation("User-Agent", "Datadog.Api");

		var debugString = request.Headers.ToDebugString();

		debugString.Should().NotContain(FakeApiKey);
		debugString.Should().Contain("Accept: application/json");
		debugString.Should().Contain("User-Agent: Datadog.Api");
	}

	/// <summary>
	/// Response headers go through the same helper, so Set-Cookie is covered.
	/// </summary>
	[Fact]
	public void ToDebugString_ResponseSetCookie_IsRedacted()
	{
		using var response = new HttpResponseMessage();
		response.Headers.TryAddWithoutValidation("Set-Cookie", "session=abc123def456; HttpOnly");

		var debugString = response.Headers.ToDebugString();

		debugString.Should().NotContain("abc123def456");
		debugString.Should().Contain("<redacted");
	}

	/// <summary>
	/// A vendor may prefix the standard header name rather than using it directly.
	/// </summary>
	[Fact]
	public void ToDebugString_VendorPrefixedAuthorizationHeader_IsRedacted()
	{
		const string token = "abcdefghijklmnopqrstuvwxyz";
		using var request = new HttpRequestMessage();
		request.Headers.TryAddWithoutValidation("X-Vendor-Authorization", $"Bearer {token}");

		var debugString = request.Headers.ToDebugString();

		debugString.Should().NotContain(token);
		debugString.Should().Contain("<redacted");
	}

	/// <summary>
	/// A request carrying no credential is rendered with nothing removed.
	/// </summary>
	[Fact]
	public void ToDebugString_NonSensitiveHeader_IsUnchanged()
	{
		using var request = new HttpRequestMessage();
		request.Headers.TryAddWithoutValidation("User-Agent", "Datadog.Api");

		var debugString = request.Headers.ToDebugString();

		debugString.Should().Be("User-Agent: Datadog.Api");
	}

	/// <summary>
	/// An empty header collection produces no output at all.
	/// </summary>
	[Fact]
	public void ToDebugString_NoHeaders_IsEmpty()
	{
		using var request = new HttpRequestMessage();

		request.Headers.ToDebugString().Should().BeEmpty();
	}
}
