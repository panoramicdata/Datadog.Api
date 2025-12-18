namespace Datadog.Api.Test;

public class HostTests(DatadogClientFixture fixture, ITestOutputHelper output) : BaseTest(fixture, output)
{
	[Fact]
	public async Task Get_Page_Succeeds()
	{
		await AssertApiCallSucceedsAsync(
			() => Client.Hosts.GetAsync(CancellationToken),
			nameof(Get_Page_Succeeds));
	}
}