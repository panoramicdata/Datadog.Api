using System.Text.Json.Serialization;

namespace Datadog.Api.Models;

public abstract class BaseAttributes
{
	[JsonPropertyName("$type")]
	public string? Type { get; set; }

	[JsonPropertyName("created_at")]
	public required DateTimeOffset CreatedAt { get; set; }

	[JsonPropertyName("modified_at")]
	public required DateTimeOffset ModifiedAt { get; set; }
}