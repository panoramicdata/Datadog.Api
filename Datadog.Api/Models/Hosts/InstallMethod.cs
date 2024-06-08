using System.Text.Json.Serialization;

namespace Datadog.Api.Models.Hosts;

public class InstallMethod
{
	[JsonPropertyName("installer_version")]
	public required string InstallerVersion { get; set; }

	[JsonPropertyName("tool")]
	public required string Tool { get; set; }

	[JsonPropertyName("tool_version")]
	public required string ToolVersion { get; set; }
}
