using System.Text.Json.Serialization;

namespace Datadog.Api.Models.Usage;

public class Usage
{
	[JsonPropertyName("hour")]
	public required DateTimeOffset Hour { get; set; }

	[JsonPropertyName("org_name")]
	public required string OrgName { get; set; }

	[JsonPropertyName("public_id")]
	public required string PublicId { get; set; }

	[JsonPropertyName("region")]
	public required string Region { get; set; }

	[JsonPropertyName("tag_config_source")]
	public required string TagConfigSource { get; set; }

	[JsonPropertyName("tags")]
	public required IReadOnlyDictionary<string, string> Tags { get; set; }

	[JsonPropertyName("total_usage_sum")]
	public required string TotalUsageSum { get; set; }

	[JsonPropertyName("updated_at")]
	public required string UpdatedAt { get; set; }

	[JsonPropertyName("usage_type")]
	public UsageType UsageType { get; set; }
}

