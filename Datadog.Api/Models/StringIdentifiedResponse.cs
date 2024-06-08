using System.Text.Json.Serialization;

namespace Datadog.Api.Models;

public class StringIdentifiedResponse<TData>
{
	[JsonPropertyName("data")]
	public required IReadOnlyCollection<StringIdentifiedEntity<TData>> Data { get; set; }

	[JsonPropertyName("included")]
	public IReadOnlyCollection<StringIdentifiedBaseEntity>? Included { get; set; }

	[JsonPropertyName("meta")]
	public required Meta Meta { get; set; }

	[JsonPropertyName("links")]
	public Links? Links { get; set; }
}

