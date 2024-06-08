using System.Text.Json.Serialization;

namespace Datadog.Api.Models.Metrics;

public class ActiveMetricsResponse
{
	[JsonPropertyName("metrics")]
	public required IReadOnlyCollection<string> MetricNames { get; set; }

	[JsonPropertyName("from")]
	public required string From { get; set; }
}
