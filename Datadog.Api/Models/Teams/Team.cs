using System.Text.Json.Serialization;

namespace Datadog.Api.Models.Teams;

public class Team
{
	[JsonPropertyName("created_at")]
	public required DateTimeOffset CreatedAt { get; set; }

	[JsonPropertyName("description")]
	public required string Description { get; set; }

	[JsonPropertyName("modified_at")]
	public required DateTimeOffset ModifiedAt { get; set; }

	[JsonPropertyName("link_count")]
	public required int LinkCount { get; set; }

	[JsonPropertyName("name")]
	public required string Name { get; set; }

	[JsonPropertyName("summary")]
	public required object Summary { get; set; }

	[JsonPropertyName("handle")]
	public required string Handle { get; set; }

	[JsonPropertyName("user_count")]
	public required int UserCount { get; set; }

}