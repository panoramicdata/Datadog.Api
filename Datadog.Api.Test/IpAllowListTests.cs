using FluentAssertions;

namespace Datadog.Api.Test;

public class IpAllowListTests(DatadogClient client)
{
	[Fact]
	public async Task Get_Page_Succeeds()
	{
		// Arrange
		var result = await client
			.IpAllowLists
			.GetAsync(default);

		result.Should().NotBeNull();
	}
}