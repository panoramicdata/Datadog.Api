using System.Text.Json.Serialization;

namespace Datadog.Api.Models.Hosts;

public class HostMetrics
{
	[JsonPropertyName("cpu")]
	public required float Cpu { get; set; }

	[JsonPropertyName("iowait")]
	public required float IoWait { get; set; }

	[JsonPropertyName("load")]
	public required float Load { get; set; }
}
