using System.Text.Json.Serialization;

namespace Datadog.Api.Models;

[JsonDerivedType(typeof(Entity<User>), "users")]
[JsonDerivedType(typeof(Entity<Role>), "roles")]
[JsonDerivedType(typeof(Entity<PermissionAttributes>), "permissions")]
public class BaseEntity
{
	public BaseEntity()
	{
	}

	[JsonPropertyName("$type")]
	public string? Type { get; set; }

	[JsonPropertyName("id")]
	public required Guid Id { get; set; }
}