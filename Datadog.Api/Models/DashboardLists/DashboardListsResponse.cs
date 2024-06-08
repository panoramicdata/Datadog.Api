using System.Text.Json.Serialization;

namespace Datadog.Api.Models.DashboardLists;
public class DashboardListsResponse
{
	[JsonPropertyName("dashboard_lists")]
	public required IReadOnlyCollection<DashboardList> DashboardLists { get; set; }
}
