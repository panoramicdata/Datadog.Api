using System.Text.Json.Serialization;

namespace Datadog.Api.Models;

public class DashboardsResponse
{
	[JsonPropertyName("dashboards")]
	public required IReadOnlyCollection<Dashboard> Dashboards { get; set; }
}