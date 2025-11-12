namespace Datadog.Api.Test;

public class ContainerTests(DatadogClientFixture fixture, ITestOutputHelper output) : BaseTest(fixture, output)
{
	[Fact]
	public async Task Get_Page_Succeeds()
	{
		// Arrange
		var result = await Client
			.Containers
			.GetAsync(CancellationToken);

		result.Should().NotBeNull();
	}
}
