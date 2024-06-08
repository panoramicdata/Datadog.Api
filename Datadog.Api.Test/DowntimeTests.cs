using FluentAssertions;

namespace Datadog.Api.Test;

public class DowntimeTests(DatadogClient client)
{
	[Fact]
	public async Task Get_Page_Succeeds()
	{
		// Arrange
		var result = await client
			.Downtimes
			.GetAsync(default);

		result.Should().NotBeNull();
	}
}
