using System.Text.Json.Serialization;

namespace Datadog.Api.Models.Dashboards;

public class DashboardsResponse
{
	[JsonPropertyName("dashboards")]
	public required IReadOnlyCollection<Dashboard> Dashboards { get; set; }
}