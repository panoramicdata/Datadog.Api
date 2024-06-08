using Datadog.Api.Models.Metrics;
using Refit;

namespace Datadog.Api.Interfaces;

public interface IMetrics
{
	/// <summary>
	/// Get Metrics
	/// </summary>
	/// <param name="from">Seconds since the Unix epoch.</param>
	/// <param name="host">Optional: Hostname for filtering the list of metrics returned. If set, metrics retrieved are those with the corresponding hostname tag.</param>
	/// <param name="tagFilter">Filter metrics that have been submitted with the given tags. Supports boolean and wildcard expressions. Cannot be combined with other filters.</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Get("/v1/metrics")]
	Task<MetricsResponse> GetActiveAsync(
		[AliasAs("from")] long from,
		[AliasAs("host")] string? host = null,
		[AliasAs("tag_filter")] string? tagFilter = null,
		CancellationToken cancellationToken = default);

	/// <summary>
	/// Get metric metadata
	/// </summary>
	[Get("/v1/metrics/{metricName}")]
	Task<MetricMetadataResponse> GetMetadataAsync(
		[Query("metricName")] string metricName,
		CancellationToken cancellationToken = default);

	/// <summary>
	/// Query timeseries points. This endpoint requires the timeseries_query authorization scope.
	/// </summary>
	[Get("/v1/query")]
	Task<QueryTimeSeriesPointsResponse> QueryTimeSeriesPointsAsync(
		[AliasAs("from")] long from,
		[AliasAs("to")] long until,
		[AliasAs("query")] string query,
		CancellationToken cancellationToken);
}
