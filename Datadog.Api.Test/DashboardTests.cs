namespace Datadog.Api.Test;

public class DashboardTests(DatadogClientFixture fixture, ITestOutputHelper output) : BaseTest(fixture, output)
{
	[Fact]
	public async Task Get_Page_Succeeds()
	{
		await AssertApiCallSucceedsAsync(
			() => Client.Dashboards.GetAsync(CancellationToken),
			nameof(Get_Page_Succeeds));
	}
}