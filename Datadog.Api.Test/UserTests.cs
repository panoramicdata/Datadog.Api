namespace Datadog.Api.Test;

public class UserTests(DatadogClientFixture fixture, ITestOutputHelper output) : BaseTest(fixture, output)
{
	[Fact]
	public async Task Get_Page_Succeeds()
	{
		// Arrange
		var result = await Client
			.Users
			.GetAsync(CancellationToken);

		result.Should().NotBeNull();
	}
}

public class WebhooksIntegrationTests(DatadogClientFixture fixture, ITestOutputHelper output) : BaseTest(fixture, output)
{
	[Fact]
	public async Task Get_Page_Succeeds()
	{
		// Arrange
		var result = await Client
			.WebhooksIntegrations
			.GetAsync(CancellationToken);

		result.Should().NotBeNull();
	}
}