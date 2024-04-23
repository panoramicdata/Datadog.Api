using FluentAssertions;

namespace Datadog.Api.Test;

public class UserTests(DatadogClient client)
{
	[Fact]
	public async Task Get_Page_Succeeds()
	{
		// Arrange
		var result = await client.Users.GetAsync(default);
		result.Should().NotBeNull();
	}
}