using FluentAssertions;

namespace Datadog.Api.Test;

public class DashboardListTests(DatadogClient client)
{
	[Fact]
	public async Task Get_Page_Succeeds()
	{
		// Arrange
		var result = await client
			.DashboardLists
			.GetAsync(default);

		result.Should().NotBeNull();
	}
}