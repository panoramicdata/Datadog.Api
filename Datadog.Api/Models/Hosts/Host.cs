using System.Text.Json.Serialization;

namespace Datadog.Api.Models.Hosts;

public class Host
{
	[JsonPropertyName("id")]
	public required long Id { get; set; }

	[JsonPropertyName("tags_by_source")]
	public required IDictionary<string, ICollection<string>> TagsBySource { get; set; }

	[JsonPropertyName("aliases")]
	public required ICollection<string> Aliases { get; set; }

	[JsonPropertyName("apps")]
	public required ICollection<string> Apps { get; set; }

	[JsonPropertyName("sources")]
	public required ICollection<string> Sources { get; set; }

	[JsonPropertyName("name")]
	public required string Name { get; set; }

	[JsonPropertyName("host_name")]
	public required string HostName { get; set; }

	[JsonPropertyName("up")]
	public required bool IsUp { get; set; }

	[JsonPropertyName("last_reported_time")]
	public required int LastReportedTime { get; set; }

	[JsonPropertyName("is_muted")]
	public required bool IsMuted { get; set; }

	[JsonPropertyName("mute_timeout")]
	public required object MuteTimeout { get; set; }

	[JsonPropertyName("meta")]
	public required HostMeta Meta { get; set; }

	[JsonPropertyName("metrics")]
	public required HostMetrics Metrics { get; set; }
}