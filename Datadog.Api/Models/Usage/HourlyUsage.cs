using System.Text.Json.Serialization;

namespace Datadog.Api.Models.Usage;

public class HourlyUsage : StringIdentifiedBaseEntity
{
	[JsonPropertyName("product_family")]
	public required string ProductFamily { get; set; }

	[JsonPropertyName("org_name")]
	public required string OrgName { get; set; }

	[JsonPropertyName("public_id")]
	public required string PublicId { get; set; }

	[JsonPropertyName("region")]
	public required string Region { get; set; }

	[JsonPropertyName("timestamp")]
	public required DateTimeOffset Timestamp { get; set; }

	[JsonPropertyName("measurements")]
	public required IReadOnlyCollection<Measurement> Measurements { get; set; }
}

