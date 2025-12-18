namespace Datadog.Api.Test;

public class AwsTests(DatadogClientFixture fixture, ITestOutputHelper output) : BaseTest(fixture, output)
{
	[Fact]
	public async Task Get_AwsTagFilters_Succeeds()
	{
		await AssertApiCallSucceedsAsync(
			() => Client.Aws.GetTagFiltersAsync(CancellationToken),
			nameof(Get_AwsTagFilters_Succeeds));
	}

	[Fact]
	public async Task Get_NamespaceRules_Succeeds()
	{
		await AssertApiCallSucceedsAsync(
			() => Client.Aws.GetNamespaceRulesAsync(CancellationToken),
			nameof(Get_NamespaceRules_Succeeds));
	}

	[Fact]
	public async Task Get_EventBridgeSources_Succeeds()
	{
		await AssertApiCallSucceedsAsync(
			() => Client.Aws.GetEventBridgeSourcesAsync(CancellationToken),
			nameof(Get_EventBridgeSources_Succeeds));
	}
}