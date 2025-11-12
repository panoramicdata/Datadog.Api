namespace Datadog.Api.Test;

public class DashboardListTests(DatadogClientFixture fixture, ITestOutputHelper output) : BaseTest(fixture, output)
{
	[Fact]
	public async Task Get_Page_Succeeds()
	{
		// Arrange
		var result = await Client
			.DashboardLists
			.GetAsync(CancellationToken);

		result.Should().NotBeNull();
	}
}