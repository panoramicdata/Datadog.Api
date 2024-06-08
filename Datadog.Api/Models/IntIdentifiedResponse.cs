using System.Text.Json.Serialization;

namespace Datadog.Api.Models;

public class IntIdentifiedResponse<TData>
{
	[JsonPropertyName("data")]
	public required IReadOnlyCollection<IntIdentifiedEntity<TData>> Data { get; set; }

	[JsonPropertyName("included")]
	public IReadOnlyCollection<IntIdentifiedBaseEntity>? Included { get; set; }

	[JsonPropertyName("meta")]
	public required Meta Meta { get; set; }

	[JsonPropertyName("links")]
	public Links? Links { get; set; }
}

