using System.Text.Json.Serialization;

namespace Datadog.Api.Models;

public class PageInfo
{
	[JsonPropertyName("total_count")]
	public int TotalCount { get; set; }

	[JsonPropertyName("total_filtered_count")]
	public int TotalFilteredCount { get; set; }

	[JsonPropertyName("max_page_size")]
	public int MaxPageSize { get; set; }
}

