using System.Text.Json.Serialization;

namespace Datadog.Api.Models;

public class Links
{
	[JsonPropertyName("first")]
	public required string First { get; set; }

	[JsonPropertyName("self")]
	public required string Self { get; set; }

	[JsonPropertyName("last")]
	public string? Last { get; set; }

	[JsonPropertyName("next")]
	public string? Next { get; set; }

	[JsonPropertyName("prev")]
	public string? Prev { get; set; }
}