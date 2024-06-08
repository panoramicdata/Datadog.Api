using System.Text.Json.Serialization;

namespace Datadog.Api.Models;

public class Pagination
{
	[JsonPropertyName("offset")]
	public int? Offset { get; set; }

	[JsonPropertyName("first_offset")]
	public int? FirstOffset { get; set; }

	[JsonPropertyName("prev_offset")]
	public int? PrevOffset { get; set; }

	[JsonPropertyName("next_offset")]
	public int? NextOffset { get; set; }

	[JsonPropertyName("next_record_id")]
	public string? NextRecordId { get; set; }

	[JsonPropertyName("last_offset")]
	public int? LastOffset { get; set; }

	[JsonPropertyName("limit")]
	public int? Limit { get; set; }

	[JsonPropertyName("$type")]
	public string? Type { get; set; }

	[JsonPropertyName("total")]
	public int? Total { get; set; }
}
