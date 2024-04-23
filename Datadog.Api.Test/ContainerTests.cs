using FluentAssertions;

namespace Datadog.Api.Test;

public class ContainerTests(DatadogClient client)
{
	[Fact]
	public async Task Get_Page_Succeeds()
	{
		// Arrange
		var result = await client.Containers.GetAsync(default);
		result.Should().NotBeNull();
	}
}
