﻿using Datadog.Api.Models;
using Datadog.Api.Models.Users;
using Refit;

namespace Datadog.Api.Interfaces;

public interface IUsers
{
	[Get("/v2/users")]
	Task<Response<User>> GetAsync(CancellationToken cancellationToken);
}