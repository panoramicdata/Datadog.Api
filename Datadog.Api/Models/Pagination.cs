using System.Text.Json.Serialization;

namespace Datadog.Api.Models;

public class Pagination
{
	[JsonPropertyName("offset")]
	public required int Offset { get; set; }

	[JsonPropertyName("first_offset")]
	public required int FirstOffset { get; set; }

	[JsonPropertyName("prev_offset")]
	public required int PrevOffset { get; set; }

	[JsonPropertyName("next_offset")]
	public required int NextOffset { get; set; }

	[JsonPropertyName("last_offset")]
	public required int LastOffset { get; set; }

	[JsonPropertyName("limit")]
	public required int Limit { get; set; }

	[JsonPropertyName("$type")]
	public required string Type { get; set; }

	[JsonPropertyName("total")]
	public required int Total { get; set; }
}
