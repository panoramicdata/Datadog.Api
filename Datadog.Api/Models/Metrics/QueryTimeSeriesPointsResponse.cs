using System.Text.Json.Serialization;

namespace Datadog.Api.Models.Metrics;

public class QueryTimeSeriesPointsResponse
{
	[JsonPropertyName("status")]
	public required string Status { get; set; }

	[JsonPropertyName("res_type")]
	public required string ResourceType { get; set; }

	[JsonPropertyName("resp_version")]
	public required int ResponseVersion { get; set; }

	[JsonPropertyName("query")]
	public required string Query { get; set; }

	[JsonPropertyName("from_date")]
	public required long FromDate { get; set; }

	[JsonPropertyName("to_date")]
	public required long ToDate { get; set; }

	[JsonPropertyName("series")]
	public required IReadOnlyCollection<Series> Series { get; set; }

	[JsonPropertyName("values")]
	public required IReadOnlyCollection<object> Values { get; set; }

	[JsonPropertyName("times")]
	public required IReadOnlyCollection<object> Times { get; set; }

	[JsonPropertyName("message")]
	public required string Message { get; set; }

	[JsonPropertyName("group_by")]
	public required IReadOnlyCollection<object> GroupBy { get; set; }
}

public class Series
{
	[JsonPropertyName("unit")]
	public required IReadOnlyCollection<Unit> Units { get; set; }

	[JsonPropertyName("query_index")]
	public required int QueryIndex { get; set; }

	[JsonPropertyName("aggr")]
	public required object Aggregation { get; set; }

	[JsonPropertyName("metric")]
	public required string Metric { get; set; }

	[JsonPropertyName("tag_set")]
	public required IReadOnlyCollection<object> TagSet { get; set; }

	[JsonPropertyName("expression")]
	public required string Expression { get; set; }

	[JsonPropertyName("scope")]
	public required string Scope { get; set; }

	[JsonPropertyName("interval")]
	public required int Interval { get; set; }

	[JsonPropertyName("length")]
	public required int Length { get; set; }

	[JsonPropertyName("start")]
	public required long Start { get; set; }

	[JsonPropertyName("end")]
	public required long End { get; set; }

	[JsonPropertyName("pointlist")]
	public required float[][] PointList { get; set; }

	[JsonPropertyName("display_name")]
	public required string DisplayName { get; set; }

	[JsonPropertyName("attributes")]
	public required Attributes Attributes { get; set; }
}

public class Attributes
{
}

public class Unit
{
	[JsonPropertyName("family")]
	public required string Family { get; set; }

	[JsonPropertyName("id")]
	public required int Id { get; set; }

	[JsonPropertyName("name")]
	public required string Name { get; set; }

	[JsonPropertyName("short_name")]
	public required string ShortName { get; set; }

	[JsonPropertyName("plural")]
	public required string Plural { get; set; }

	[JsonPropertyName("scale_factor")]
	public required float ScaleFactor { get; set; }
}
