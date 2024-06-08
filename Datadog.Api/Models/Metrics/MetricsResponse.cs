using System.Text.Json.Serialization;

namespace Datadog.Api.Models.Metrics;

public class MetricsResponse
{
	[JsonPropertyName("data")]
	public required IReadOnlyCollection<Metric> MetricNames { get; set; }
}
