namespace Datadog.Api.Test;

public class DashboardListTests(DatadogClientFixture fixture, ITestOutputHelper output) : BaseTest(fixture, output)
{
	[Fact]
	public async Task Get_Page_Succeeds()
	{
		await AssertApiCallSucceedsAsync(
			() => Client.DashboardLists.GetAsync(CancellationToken),
			nameof(Get_Page_Succeeds));
	}
}