using Datadog.Api.Models;
using Refit;

namespace Datadog.Api.Interfaces;

public interface IContainers
{
	[Get("/v1/containers")]
	Task<Response<Container>> GetAsync(CancellationToken cancellationToken);
}
