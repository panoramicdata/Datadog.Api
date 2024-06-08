using System.Text.Json.Serialization;

namespace Datadog.Api.Models.Roles;

public class Role : NamedBaseAttributes
{
	[JsonPropertyName("user_count")]
	public int? UserCount { get; set; }
}
