using System.Text.Json.Serialization;

namespace Datadog.Api.Models.Usage;

public class Measurement
{
	[JsonPropertyName("usage_type")]
	public required string UsageType { get; set; }

	[JsonPropertyName("value")]
	public required object? Value { get; set; }
}

