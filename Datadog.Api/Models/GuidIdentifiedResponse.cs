using System.Text.Json.Serialization;

namespace Datadog.Api.Models;

public class GuidIdentifiedResponse<TData>
{
	[JsonPropertyName("data")]
	public required IReadOnlyCollection<GuidIdentifiedEntity<TData>> Data { get; set; }

	[JsonPropertyName("included")]
	public IReadOnlyCollection<GuidIdentifiedBaseEntity>? Included { get; set; }

	[JsonPropertyName("meta")]
	public required Meta Meta { get; set; }

	[JsonPropertyName("links")]
	public Links? Links { get; set; }
}