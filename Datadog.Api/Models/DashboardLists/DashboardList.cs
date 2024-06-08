using System.Text.Json.Serialization;

namespace Datadog.Api.Models.DashboardLists;

public class DashboardList : IntIdentifiedBaseEntity
{
	[JsonPropertyName("author")]
	public required Author Author { get; set; }

	[JsonPropertyName("created")]
	public required DateTimeOffset Created { get; set; }

	[JsonPropertyName("dashboards")]
	public required object Dashboards { get; set; }

	[JsonPropertyName("dashboard_count")]
	public required int DashboardCount { get; set; }

	[JsonPropertyName("is_favorite")]
	public required bool IsFavorite { get; set; }

	[JsonPropertyName("modified")]
	public required DateTime Modified { get; set; }

	[JsonPropertyName("name")]
	public required string Name { get; set; }
}
