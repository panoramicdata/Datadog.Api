using System.Text.Json.Serialization;

namespace Datadog.Api.Models.Metrics;

public class Metric
{
	[JsonPropertyName("id")]
	public required string Id { get; set; }

	[JsonPropertyName("$type")]
	public required string Type { get; set; }
}
