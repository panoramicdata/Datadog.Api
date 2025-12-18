namespace Datadog.Api.Test;

public class UserTests(DatadogClientFixture fixture, ITestOutputHelper output) : BaseTest(fixture, output)
{
	[Fact]
	public async Task Get_Page_Succeeds()
	{
		// Act
		var result = await ExecuteApiCallAsync(
			() => Client.Users.GetAsync(CancellationToken),
			nameof(Get_Page_Succeeds));

		// Assert
		result.Should().NotBeNull();
	}
}

public class WebhooksIntegrationTests(DatadogClientFixture fixture, ITestOutputHelper output) : BaseTest(fixture, output)
{
	[Fact]
	public async Task Get_Page_Succeeds()
	{
		// Act
		var result = await ExecuteApiCallAsync(
			() => Client.WebhooksIntegrations.GetAsync(CancellationToken),
			nameof(Get_Page_Succeeds));

		// Assert
		result.Should().NotBeNull();
	}
}