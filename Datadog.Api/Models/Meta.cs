using System.Text.Json.Serialization;

namespace Datadog.Api.Models;

public class Meta
{
	[JsonPropertyName("page")]
	public required PageInfo Page { get; set; }
}

