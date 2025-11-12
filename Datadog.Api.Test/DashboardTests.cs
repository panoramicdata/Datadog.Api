namespace Datadog.Api.Test;

public class DashboardTests(DatadogClientFixture fixture, ITestOutputHelper output) : BaseTest(fixture, output)
{
	[Fact]
	public async Task Get_Page_Succeeds()
	{
		// Arrange
		var result = await Client
			.Dashboards
			.GetAsync(CancellationToken);

		result.Should().NotBeNull();
	}
}