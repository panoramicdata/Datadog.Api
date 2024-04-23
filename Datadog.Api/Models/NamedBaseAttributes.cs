using System.Text.Json.Serialization;

namespace Datadog.Api.Models;

public abstract class NamedBaseAttributes : BaseAttributes
{
	[JsonPropertyName("name")]
	public required string Name { get; set; }

}