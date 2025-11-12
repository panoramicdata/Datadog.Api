namespace Datadog.Api.Test;

public class AwsTests(DatadogClientFixture fixture, ITestOutputHelper output) : BaseTest(fixture, output)
{
	[Fact]
	public async Task Get_AwsTagFilters_Succeeds()
	{
		// Arrange
		var result = await Client
			.Aws
			.GetTagFiltersAsync(CancellationToken);

		result.Should().NotBeNull();
	}

	[Fact]
	public async Task Get_NamespaceRules_Succeeds()
	{
		// Arrange
		var result = await Client
			.Aws
			.GetNamespaceRulesAsync(CancellationToken);

		result.Should().NotBeNull();
	}

	[Fact]
	public async Task Get_EventBridgeSources_Succeeds()
	{
		// Arrange
		var result = await Client
			.Aws
			.GetEventBridgeSourcesAsync(CancellationToken);

		result.Should().NotBeNull();
	}
}