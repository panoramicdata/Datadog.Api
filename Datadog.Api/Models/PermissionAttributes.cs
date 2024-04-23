using System.Text.Json.Serialization;

namespace Datadog.Api.Models;

public class PermissionAttributes
{
	[JsonPropertyName("name")]
	public required string Name { get; set; }

	[JsonPropertyName("display_name")]
	public required string DisplayName { get; set; }

	[JsonPropertyName("description")]
	public required string Description { get; set; }

	[JsonPropertyName("created")]
	public required DateTime Created { get; set; }

	[JsonPropertyName("group_name")]
	public required string GroupName { get; set; }

	[JsonPropertyName("display_type")]
	public required string DisplayType { get; set; }

	[JsonPropertyName("restricted")]
	public bool IsRestricted { get; set; }
}
