using Datadog.Api.Models.Containers;
using Datadog.Api.Models.Dashboards;
using Datadog.Api.Models.Downtimes;
using Datadog.Api.Models.Hosts;
using Datadog.Api.Models.IpAllowLists;
using Datadog.Api.Models.Roles;
using Datadog.Api.Models.Tags;
using Datadog.Api.Models.Teams;
using Datadog.Api.Models.Users;
using Datadog.Api.Models.WebhooksIntegrations;
using System.Text.Json.Serialization;

namespace Datadog.Api.Models;

[JsonDerivedType(typeof(GuidIdentifiedEntity<Container>), "containers")]
[JsonDerivedType(typeof(GuidIdentifiedEntity<Dashboard>), "dashboards")]
[JsonDerivedType(typeof(GuidIdentifiedEntity<Downtime>), "downtimes")]
[JsonDerivedType(typeof(GuidIdentifiedEntity<Host>), "host")]
[JsonDerivedType(typeof(GuidIdentifiedEntity<IpAllowList>), "ipAllowLists")]
[JsonDerivedType(typeof(GuidIdentifiedEntity<Role>), "roles")]
[JsonDerivedType(typeof(GuidIdentifiedEntity<Tag>), "tags")]
[JsonDerivedType(typeof(GuidIdentifiedEntity<Team>), "handle")]
[JsonDerivedType(typeof(GuidIdentifiedEntity<User>), "users")]
[JsonDerivedType(typeof(GuidIdentifiedEntity<PermissionAttributes>), "permissions")]
[JsonDerivedType(typeof(GuidIdentifiedEntity<WebhooksIntegration>), "webhook_integration")]
public abstract class GuidIdentifiedBaseEntity : BaseEntity
{
	public GuidIdentifiedBaseEntity()
	{
	}

	[JsonPropertyName("id")]
	public required Guid Id { get; set; }
}
