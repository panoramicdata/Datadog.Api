namespace Datadog.Api.Test;

public class RolesTests(DatadogClientFixture fixture, ITestOutputHelper output) : BaseTest(fixture, output)
{
	[Fact]
	public async Task Get_Page_Succeeds()
	{
		// Arrange
		var result = await Client
			.Roles
			.GetAsync(CancellationToken);

		result.Should().NotBeNull();
	}
}