using System.Text.Json.Serialization;

namespace Datadog.Api.Models;

public class StringIdentifiedEntity<TAttributes> : StringIdentifiedBaseEntity
{
	public StringIdentifiedEntity()
	{
	}

	[JsonPropertyName("attributes")]
	public required TAttributes Attributes { get; set; }

	[JsonPropertyName("relationships")]
	public IReadOnlyDictionary<string, object>? Relationships { get; set; }
}
