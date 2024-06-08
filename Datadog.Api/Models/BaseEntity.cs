using System.Text.Json.Serialization;

namespace Datadog.Api.Models;

public abstract class BaseEntity
{
	[JsonPropertyName("$type")]
	public string? Type { get; set; }
}