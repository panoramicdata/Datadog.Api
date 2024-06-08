using System.Text.Json.Serialization;

namespace Datadog.Api.Models;

public class Meta
{
	[JsonPropertyName("page")]
	public PageInfo? Page { get; set; }

	[JsonPropertyName("pagination")]
	public Pagination? Pagination { get; set; }
}