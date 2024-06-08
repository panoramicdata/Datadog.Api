using System.Text.Json.Serialization;

namespace Datadog.Api.Models.Tags;

public class TagsResponse
{
	[JsonPropertyName("tags")]
	public required IReadOnlyCollection<Tag> Tags { get; set; }
}