using System.Text.Json.Serialization;

namespace Datadog.Api.Models.Hosts;

public class LogsAgent
{
	[JsonPropertyName("auto_multi_line_detection_enabled")]
	public required bool AutoMultiLineDetectionEnabled { get; set; }

	[JsonPropertyName("transport")]
	public required string Transport { get; set; }
}
