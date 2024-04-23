using System.Text.Json.Serialization;

namespace Datadog.Api.Models;

public class HostsResponse
{
	[JsonPropertyName("hosts")]
	public required IReadOnlyCollection<Host> Hosts { get; set; }
}
