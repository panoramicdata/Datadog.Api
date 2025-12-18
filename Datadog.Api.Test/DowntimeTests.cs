namespace Datadog.Api.Test;

public class DowntimeTests(DatadogClientFixture fixture, ITestOutputHelper output) : BaseTest(fixture, output)
{
	[Fact]
	public async Task Get_Page_Succeeds()
	{
		await AssertApiCallSucceedsAsync(
			() => Client.Downtimes.GetAsync(CancellationToken),
			nameof(Get_Page_Succeeds));
	}
}
