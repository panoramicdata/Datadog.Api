using System.Text.Json.Serialization;

namespace Datadog.Api.Models.Hosts;

public class HostMeta
{
	[JsonPropertyName("socket-fqdn")]
	public required string SocketFqdn { get; set; }

	[JsonPropertyName("cpuCores")]
	public required int CpuCores { get; set; }

	[JsonPropertyName("platform")]
	public required string Platform { get; set; }

	[JsonPropertyName("gohai")]
	public required string Gohai { get; set; }

	[JsonPropertyName("container_meta")]
	public required ContainerMeta ContainerMeta { get; set; }

	[JsonPropertyName("socket-hostname")]
	public required string SocketHostname { get; set; }

	[JsonPropertyName("install_method")]
	public required InstallMethod InstallMethod { get; set; }

	[JsonPropertyName("fbsdV")]
	public required string[] FbsdV { get; set; }

	[JsonPropertyName("processor")]
	public required string Processor { get; set; }

	[JsonPropertyName("macV")]
	public required string[] MacV { get; set; }

	[JsonPropertyName("machine")]
	public required string Machine { get; set; }

	[JsonPropertyName("agent_version")]
	public required string AgentVersion { get; set; }

	[JsonPropertyName("network")]
	public required object Network { get; set; }

	[JsonPropertyName("logs_agent")]
	public required LogsAgent LogsAgent { get; set; }

	[JsonPropertyName("agent_checks")]
	public required string[][] AgentChecks { get; set; }

	[JsonPropertyName("nixV")]
	public required string[] NixV { get; set; }

	[JsonPropertyName("pythonV")]
	public required string PythonV { get; set; }

	[JsonPropertyName("timezones")]
	public required string[] Timezones { get; set; }

	[JsonPropertyName("agent_flavor")]
	public required string AgentFlavor { get; set; }

	[JsonPropertyName("winV")]
	public required string[] WinV { get; set; }

	[JsonPropertyName("host_id")]
	public required long HostId { get; set; }
}
