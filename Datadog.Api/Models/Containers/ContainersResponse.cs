using System.Text.Json.Serialization;

namespace Datadog.Api.Models.Containers;

public class ContainersResponse
{
	[JsonPropertyName("containers")]
	public required IReadOnlyCollection<Container> Containers { get; set; }
}