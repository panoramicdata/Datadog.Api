using System.Text.Json.Serialization;

namespace Datadog.Api.Models.Teams;
public class TeamsResponse
{
	[JsonPropertyName("teams")]
	public required IReadOnlyCollection<Team> Teams { get; set; }
}
