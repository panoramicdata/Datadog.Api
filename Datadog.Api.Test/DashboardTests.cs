using FluentAssertions;

namespace Datadog.Api.Test;

public class DashboardTests(DatadogClient client)
{
	[Fact]
	public async Task Get_Page_Succeeds()
	{
		// Arrange
		var result = await client.Dashboards.GetAsync(default);
		result.Should().NotBeNull();
	}
}