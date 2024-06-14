﻿using Datadog.Api.Models.Usage;
using FluentAssertions;
using System.Globalization;

namespace Datadog.Api.Test;

public class UsageTests(DatadogClient client)
{
	[Fact]
	public async Task Get_HourlyUsage_Succeeds()
	{
		// Arrange
		// Get the last 30 days of usage data, at the midnight boundary
		// Create start and end dates for the last 30 days as strings in the format "YYYY-MM-DDThh"
		var currentDate = DateTimeOffset.UtcNow;
		var startDate = currentDate.AddDays(-30).ToString("yyyy-MM-ddT00", CultureInfo.InvariantCulture);
		var endDate = currentDate.ToString("yyyy-MM-ddT00", CultureInfo.InvariantCulture);

		// Act
		var result = await client
			.Usage
			.GetHourlyUsageAsync(
				startDate,
				endDate,
				[ProductFamily.All],
				cancellationToken: default
				);

		result.Should().NotBeNull();
	}

	[Fact]
	public async Task Get_HourlyUsageAttribution_Succeeds()
	{
		// Arrange
		// Get the last 30 days of usage data, at the midnight boundary
		// Create start and end dates for the last 30 days as strings in the format "YYYY-MM-DDThh"
		var currentDate = DateTimeOffset.UtcNow;
		var startDate = currentDate.AddDays(-1).ToString("yyyy-MM-ddT00", CultureInfo.InvariantCulture);
		var endDate = currentDate.ToString("yyyy-MM-ddT00", CultureInfo.InvariantCulture);

		// Act
		var result = await client
			.Usage
			.GetHourlyUsageAttributionAsync(
				startDate,
				endDate,
				UsageType.ApiUsage,
				cancellationToken: default
				);

		result.Should().NotBeNull();
	}
}
