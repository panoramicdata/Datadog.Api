namespace Datadog.Api.Test;

public class IpAllowListTests(DatadogClientFixture fixture, ITestOutputHelper output) : BaseTest(fixture, output)
{
	[Fact]
	public async Task Get_Page_Succeeds()
	{
		// Arrange
		var result = await Client
			.IpAllowLists
			.GetAsync(CancellationToken);

		result.Should().NotBeNull();
	}
}