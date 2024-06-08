using Datadog.Api.Models;
using Datadog.Api.Models.Roles;
using Refit;

namespace Datadog.Api.Interfaces;

public interface IRoles
{
	[Get("/v2/roles")]
	Task<Response<Role>> GetAsync(CancellationToken cancellationToken);
}
