using Datadog.Api.Models.DashboardLists;
using System.Text.Json.Serialization;

namespace Datadog.Api.Models;

[JsonDerivedType(typeof(IntIdentifiedEntity<DashboardList>), "dashboard_lists")]
public abstract class IntIdentifiedBaseEntity : BaseEntity
{
	public IntIdentifiedBaseEntity()
	{
	}

	[JsonPropertyName("id")]
	public required int Id { get; set; }
}