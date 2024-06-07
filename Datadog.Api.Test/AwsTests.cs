using FluentAssertions;

namespace Datadog.Api.Test;

public class AwsTests(DatadogClient client)
{
	[Fact]
	public async Task Get_AwsTagFilters_Succeeds()
	{
		// Arrange
		var result = await client
			.Aws
			.GetTagFiltersAsync(default);

		result.Should().NotBeNull();
	}

	[Fact]
	public async Task Get_NamespaceRules_Succeeds()
	{
		// Arrange
		var result = await client
			.Aws
			.GetNamespaceRulesAsync(default);

		result.Should().NotBeNull();
	}

	[Fact]
	public async Task Get_EventBridgeSources_Succeeds()
	{
		// Arrange
		var result = await client
			.Aws
			.GetEventBridgeSourcesAsync(default);

		result.Should().NotBeNull();
	}
}