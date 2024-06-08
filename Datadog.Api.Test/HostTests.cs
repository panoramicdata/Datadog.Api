using FluentAssertions;

namespace Datadog.Api.Test;

public class HostTests(DatadogClient client)
{
	[Fact]
	public async Task Get_Page_Succeeds()
	{
		// Arrange
		var result = await client
			.Hosts
			.GetAsync(default);

		result.Should().NotBeNull();
	}
}