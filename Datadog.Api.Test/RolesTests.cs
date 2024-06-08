﻿using FluentAssertions;

namespace Datadog.Api.Test;

public class RolesTests(DatadogClient client)
{
	[Fact]
	public async Task Get_Page_Succeeds()
	{
		// Arrange
		var result = await client
			.Roles
			.GetAsync(default);

		result.Should().NotBeNull();
	}
}