namespace Datadog.Api.Test;

public class TeamsTests(DatadogClientFixture fixture, ITestOutputHelper output) : BaseTest(fixture, output)
{
	[Fact]
	public async Task Get_Page_Succeeds()
	{
		// Arrange
		var result = await Client
			.Teams
			.GetAsync(cancellationToken: CancellationToken);

		result.Should().NotBeNull();
	}
}
