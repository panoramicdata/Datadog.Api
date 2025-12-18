using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Datadog.Api;

public class AuthenticatedHttpClientHandler(DatadogClientOptions options) : HttpClientHandler
{
	private readonly DatadogClientOptions _options = options;
	private readonly ILogger _logger = options.Logger ?? NullLogger.Instance;
	private static readonly JsonSerializerOptions JsonSerializerOptions = new()
	{
		WriteIndented = true,
		Converters = { new JsonStringEnumConverter() },
		UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow
	};

	/// <summary>
	/// Override of the base method that is used to handle the sending of a request
	/// </summary>
	/// <param name="request">The request that is to be sent</param>
	/// <param name="cancellationToken">A cancellation token for the operation</param>
	/// <returns>The response to the request that was sent</returns>
	protected override async Task<HttpResponseMessage> SendAsync(
		HttpRequestMessage request,
		CancellationToken cancellationToken)
	{
		// Generate a unique request id
		var requestId = Guid.NewGuid();

		// Accept JSON
		request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

		// Authentication
		request.Headers.Add("DD-API-KEY", _options.ApiKey);
		if (!string.IsNullOrWhiteSpace(_options.ApplicationKey))
		{
			request.Headers.Add("DD-APPLICATION-KEY", _options.ApplicationKey);
		}

		// User Agent
		if (!string.IsNullOrWhiteSpace(_options.UserAgent))
		{
			request.Headers.Add("User-Agent", _options.UserAgent);
		}

		// Check the logging level as the operation to
		// extract the content is expensive
		if (_logger.IsEnabled(LogLevel.Debug))
		{
			var url = request.RequestUri!.ToString();
			var headers = string.Join("\n", request.Headers.Select(h => $"{h.Key}: {string.Join(", ", h.Value.Select(v => v))}"));
			var body = request.Content is not null
				? await request
					.Content
					.ReadAsStringAsync(cancellationToken)
					.ConfigureAwait(false)
				: string.Empty;

			_logger.LogDebug(
				"{RequestId}: REQUEST: Url:{Url}\nHeaders:{Headers}\nBody: {Body}",
				requestId,
				url,
				headers,
				body);
		}

		// Make the HTTP call
		var httpResponse = await base
			.SendAsync(request, cancellationToken)
			.ConfigureAwait(false)
			;

		// Check the logging level as the operation to
		// extract the content is expensive
		if (_logger.IsEnabled(LogLevel.Debug))
		{
			var headers = string.Join("\n", httpResponse.Headers.Select(h => $"{h.Key}: {string.Join(", ", h.Value.Select(v => v))}"));
			var body = httpResponse.Content is not null
				? await httpResponse.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false)
				: string.Empty;
			try
			{
				// Get an object using System.Text.Json
				var jObject = JsonSerializer.Deserialize<object>(body);
				body = JsonSerializer.Serialize(jObject, JsonSerializerOptions);
			}
			catch (Exception)
			{
				// This doesn't work for arrays, which return the JArray type
			}

			_logger.LogDebug(
				"{RequestId}: RESPONSE: {StatusCode}\nHeaders:{Headers}\nBody: {Body}",
				requestId,
				httpResponse.StatusCode,
				headers,
				body);
		}

		// Was the request successful?
		if (!httpResponse.IsSuccessStatusCode)
		{
			// No - read the body but don't process it (response will be returned as-is)
			if (httpResponse.Content is not null)
			{
				_ = await httpResponse
					.Content
					.ReadAsStringAsync(cancellationToken)
					.ConfigureAwait(false);
			}
		}

		// Rewrite the content, replacing all instances of "type" with "$type"
		if (httpResponse.Content is not null)
		{
			var content = await httpResponse
				.Content
				.ReadAsStringAsync(cancellationToken)
				.ConfigureAwait(false)
				;

			// Replace all instances of "type" with "$type"
			content = content.Replace("\"type\"", "\"$type\"", StringComparison.Ordinal);

			// Rewrite the content
			httpResponse.Content = new StringContent(content);
		}

		return httpResponse;
	}
}