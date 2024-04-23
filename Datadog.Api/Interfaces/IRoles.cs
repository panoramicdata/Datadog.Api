using Datadog.Api.Models;
using Refit;

namespace Datadog.Api.Interfaces;

public interface IRoles
{
	[Get("/v2/roles")]
	Task<Response<Role>> GetAsync(CancellationToken cancellationToken);
}
