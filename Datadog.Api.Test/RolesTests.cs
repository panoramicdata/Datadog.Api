namespace Datadog.Api.Test;

public class RolesTests(DatadogClientFixture fixture, ITestOutputHelper output) : BaseTest(fixture, output)
{
	[Fact]
	public async Task Get_Page_Succeeds()
	{
		// Act
		var result = await ExecuteApiCallAsync(
			() => Client.Roles.GetAsync(CancellationToken),
			nameof(Get_Page_Succeeds));

		// Assert
		result.Should().NotBeNull();
	}
}