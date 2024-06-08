using System.Text.Json.Serialization;

namespace Datadog.Api.Models.Hosts;

public class HostsResponse
{
	[JsonPropertyName("host_list")]
	public required IReadOnlyCollection<Host> Hosts { get; set; }

	[JsonPropertyName("total_returned")]
	public required int TotalReturnedCount { get; set; }

	[JsonPropertyName("total_matching")]
	public required int TotalMatchingCount { get; set; }

	[JsonPropertyName("exact_total_matching")]
	public required bool ExactTotalMatching { get; set; }
}
