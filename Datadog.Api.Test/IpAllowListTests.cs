namespace Datadog.Api.Test;

public class IpAllowListTests(DatadogClientFixture fixture, ITestOutputHelper output) : BaseTest(fixture, output)
{
	[Fact]
	public async Task Get_Page_Succeeds()
	{
		// Act
		var result = await ExecuteApiCallAsync(
			() => Client.IpAllowLists.GetAsync(CancellationToken),
			nameof(Get_Page_Succeeds));

		// Assert
		result.Should().NotBeNull();
	}
}