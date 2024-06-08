using FluentAssertions;

namespace Datadog.Api.Test;

public class MetricTests(DatadogClient client)
{
	[Fact]
	public async Task GetActiveMetrics_Succeeds()
	{
		// Arrange
		var oneHourAgoUnixTimestamp = DateTimeOffset.UtcNow.AddHours(-1).ToUnixTimeSeconds();

		// Act
		var result = await client
			.Metrics
			.GetActiveAsync(oneHourAgoUnixTimestamp);

		result.Should().NotBeNull();
	}

	[Fact]
	public async Task GetMetrics_Succeeds()
	{
		// Act
		var result = await client
			.Metrics
			.GetMetricsAsync(cancellationToken: default);

		// Assert
		result.Should().NotBeNull();
	}

	[Fact]
	public async Task GetMetadata_Succeeds()
	{
		// Arrange
		var oneHourAgoUnixTimestamp = DateTimeOffset.UtcNow.AddHours(-1).ToUnixTimeSeconds();
		var metricsResponse = await client
			.Metrics
			.GetActiveAsync(oneHourAgoUnixTimestamp);

		// Act
		foreach (var metricName in metricsResponse.MetricNames.Take(10))
		{
			var result = await client
				.Metrics
				.GetMetadataAsync(metricName, default);

			// Assert
			result.Should().NotBeNull();
		}
	}


	[Fact]
	public async Task GetRelatedAssets_Succeeds()
	{
		// Arrange
		var oneHourAgoUnixTimestamp = DateTimeOffset.UtcNow.AddHours(-1).ToUnixTimeSeconds();
		var metricsResponse = await client
			.Metrics
			.GetActiveAsync(oneHourAgoUnixTimestamp);

		// Act
		foreach (var metricName in metricsResponse.MetricNames.Take(10))
		{
			var result = await client
				.Metrics
				.GetRelatedAssetsAsync(metricName, default);

			// Assert
			result.Should().NotBeNull();
		}
	}


	[Fact]
	public async Task QueryTimeSeriesPoints_Succeeds()
	{
		// Arrange
		DateTimeOffset utcNow = DateTimeOffset.UtcNow;
		var twentyFiveHoursAgoUnixTimestamp = utcNow.AddHours(-25).ToUnixTimeSeconds();
		var oneHourAgoUnixTimestamp = utcNow.AddHours(-1).ToUnixTimeSeconds();
		var metricsResponse = await client
			.Metrics
			.GetActiveAsync(oneHourAgoUnixTimestamp);

		// Act
		foreach (var metricName in metricsResponse.MetricNames.Take(10))
		{
			var queryString = $"{metricName}{{*}}";

			var result = await client
				.Metrics
				.QueryTimeSeriesPointsAsync(
					twentyFiveHoursAgoUnixTimestamp,
					oneHourAgoUnixTimestamp,
					queryString,
					default);

			// Assert
			result.Should().NotBeNull();
		}
	}
}