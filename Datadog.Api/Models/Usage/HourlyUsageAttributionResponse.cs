using System.Text.Json.Serialization;

namespace Datadog.Api.Models.Usage;

public class HourlyUsageAttributionResponse
{
	[JsonPropertyName("metadata")]
	public required Meta Metadata { get; set; }

	[JsonPropertyName("usage")]
	public required IReadOnlyCollection<Usage> Usage { get; set; }
}

