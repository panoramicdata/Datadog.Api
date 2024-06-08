using System.Text.Json.Serialization;

namespace Datadog.Api.Models.Hosts;

public class ContainerMeta
{
	[JsonPropertyName("cri_name")]
	public required string CriName { get; set; }

	[JsonPropertyName("cri_version")]
	public required string CriVersion { get; set; }

	[JsonPropertyName("docker_swarm")]
	public required string DockerSwarm { get; set; }

	[JsonPropertyName("docker_version")]
	public required string DockerVersion { get; set; }

	[JsonPropertyName("kubelet_version")]
	public string? KubeletVersion { get; set; }
}
