using AwesomeAssertions;

namespace Datadog.Api.Test;

public class DowntimeTests(DatadogClientFixture fixture, ITestOutputHelper output) : BaseTest(fixture, output)
{
	[Fact]
	public async Task Get_Page_Succeeds()
	{
		// Arrange
		var result = await Client
			.Downtimes
			.GetAsync(CancellationToken);

		result.Should().NotBeNull();
	}
}
