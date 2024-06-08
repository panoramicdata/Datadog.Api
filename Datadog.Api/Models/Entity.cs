using System.Text.Json.Serialization;

namespace Datadog.Api.Models;

public class GuidIdentifiedEntity<TAttributes> : GuidIdentifiedBaseEntity
{
	[JsonPropertyName("attributes")]
	public required TAttributes Attributes { get; set; }

	[JsonPropertyName("relationships")]
	public IReadOnlyDictionary<string, object>? Relationships { get; set; }
}
public class IntIdentifiedEntity<TAttributes> : IntIdentifiedBaseEntity
{
	[JsonPropertyName("attributes")]
	public required TAttributes Attributes { get; set; }

	[JsonPropertyName("relationships")]
	public IReadOnlyDictionary<string, object>? Relationships { get; set; }
}