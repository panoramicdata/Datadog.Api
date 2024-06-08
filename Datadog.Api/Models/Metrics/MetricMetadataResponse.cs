using System.Text.Json.Serialization;

namespace Datadog.Api.Models.Metrics;

public class MetricMetadataResponse
{
	/// <summary>
	/// Metric description.
	/// </summary>
	[JsonPropertyName("description")]
	public required string? Description { get; set; }

	/// <summary>
	/// Name of the integration that sent the metric if applicable.
	/// </summary>
	[JsonPropertyName("integration")]
	public required string? Integration { get; set; }

	/// <summary>
	/// Per unit of the metric such as second in bytes per second.
	/// </summary>
	[JsonPropertyName("per_unit")]
	public required string? PerUnit { get; set; }

	/// <summary>
	/// A more human-readable and abbreviated version of the metric name.
	/// </summary>
	[JsonPropertyName("short_name")]
	public required string? ShortName { get; set; }

	/// <summary>
	/// StatsD flush interval of the metric in seconds if applicable.
	/// </summary>
	[JsonPropertyName("statsd_interval")]
	public required int? StatsdIntervalSeconds { get; set; }

	/// <summary>
	/// Metric type such as gauge or rate.
	/// </summary>
	[JsonPropertyName("$type")]
	public required MetricType? Type { get; set; }

	/// <summary>
	/// Primary unit of the metric such as byte or operation.
	/// </summary>
	[JsonPropertyName("unit")]
	public required string? Unit { get; set; }
}
