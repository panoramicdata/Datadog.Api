using Datadog.Api.Models.DashboardLists;
using System.Text.Json.Serialization;

namespace Datadog.Api.Models;

[JsonDerivedType(typeof(IntIdentifiedEntity<DashboardList>), "dashboard_lists")]
public class IntIdentifiedBaseEntity
{
	public IntIdentifiedBaseEntity()
	{
	}

	[JsonPropertyName("$type")]
	public string? Type { get; set; }

	[JsonPropertyName("id")]
	public required int Id { get; set; }
}