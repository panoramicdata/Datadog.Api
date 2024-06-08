using System.Text.Json.Serialization;

namespace Datadog.Api.Models.Users;

public class User : NamedBaseAttributes
{
	[JsonPropertyName("handle")]
	public required string Handle { get; set; }

	[JsonPropertyName("email")]
	public required string Email { get; set; }

	[JsonPropertyName("icon")]
	public required Uri Icon { get; set; }

	[JsonPropertyName("title")]
	public required string Title { get; set; }

	[JsonPropertyName("verified")]
	public required bool IsVerified { get; set; }

	[JsonPropertyName("service_account")]
	public required bool ServiceAccount { get; set; }

	[JsonPropertyName("disabled")]
	public required bool IsDisabled { get; set; }

	[JsonPropertyName("allowed_login_methods")]
	public required IReadOnlyCollection<object> AllowedLoginMethods { get; set; }

	[JsonPropertyName("status")]
	public required string Status { get; set; }

	[JsonPropertyName("mfa_enabled")]
	public required bool IsMfaEnabled { get; set; }
}