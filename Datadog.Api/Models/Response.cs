using System.Text.Json.Serialization;

namespace Datadog.Api.Models;

public class Response<TData>
{
	[JsonPropertyName("data")]
	public required IReadOnlyCollection<Entity<TData>> Data { get; set; }

	[JsonPropertyName("included")]
	public IReadOnlyCollection<BaseEntity>? Included { get; set; }

	[JsonPropertyName("meta")]
	public required Meta Meta { get; set; }
}
