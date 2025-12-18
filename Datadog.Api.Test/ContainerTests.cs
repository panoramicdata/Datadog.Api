namespace Datadog.Api.Test;

public class ContainerTests(DatadogClientFixture fixture, ITestOutputHelper output) : BaseTest(fixture, output)
{
	[Fact]
	public async Task Get_Page_Succeeds()
	{
		await AssertApiCallSucceedsAsync(
			() => Client.Containers.GetAsync(CancellationToken),
			nameof(Get_Page_Succeeds));
	}
}
