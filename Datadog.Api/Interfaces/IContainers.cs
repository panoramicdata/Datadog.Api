﻿using Datadog.Api.Models;
using Datadog.Api.Models.Containers;
using Refit;

namespace Datadog.Api.Interfaces;

public interface IContainers
{
	[Get("/v2/containers")]
	Task<Response<Container>> GetAsync(CancellationToken cancellationToken);
}
