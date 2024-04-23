using System.Text.Json.Serialization;

namespace Datadog.Api.Models;

public class Dashboard : BaseAttributes
{
	[JsonPropertyName("id")]
	public required string Id { get; set; }

	[JsonPropertyName("title")]
	public required string Title { get; set; }

	[JsonPropertyName("description")]
	public required object Description { get; set; }

	[JsonPropertyName("layout_type")]
	public required string LayoutType { get; set; }

	[JsonPropertyName("url")]
	public required Uri Url { get; set; }

	[JsonPropertyName("is_read_only")]
	public required bool IsReadOnly { get; set; }

	[JsonPropertyName("author_handle")]
	public required string AuthorHandle { get; set; }

	[JsonPropertyName("deleted_at")]
	public DateTimeOffset? DeletedAt { get; set; }
}

