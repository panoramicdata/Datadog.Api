using System.Text.Json.Serialization;

namespace Datadog.Api.Models.DashboardLists;

public class Author
{
	[JsonPropertyName("name")]
	public required string Name { get; set; }

	[JsonPropertyName("handle")]
	public required string Handle { get; set; }
}
