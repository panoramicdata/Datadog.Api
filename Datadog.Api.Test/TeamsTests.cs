using FluentAssertions;

namespace Datadog.Api.Test;

public class TeamsTests(DatadogClient client)
{
	[Fact]
	public async Task Get_Page_Succeeds()
	{
		// Arrange
		var result = await client
			.Teams
			.GetAsync(cancellationToken: default);

		result.Should().NotBeNull();
	}
}
