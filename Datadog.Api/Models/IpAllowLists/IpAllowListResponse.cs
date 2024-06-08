using System.Text.Json.Serialization;

namespace Datadog.Api.Models.IpAllowLists;

public class IpAllowListsResponse
{
	[JsonPropertyName("ipAllowLists")]
	public required IReadOnlyCollection<IpAllowList> IpAllowLists { get; set; }
}