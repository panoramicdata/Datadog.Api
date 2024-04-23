using System.Text.Json.Serialization;

namespace Datadog.Api.Models;

public class Role : NamedBaseAttributes
{
	[JsonPropertyName("user_count")]
	public int? UserCount { get; set; }
}
