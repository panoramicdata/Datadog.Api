using Datadog.Api.Models;
using Refit;

namespace Datadog.Api.Interfaces;

public interface IHosts
{
	[Get("/v1/hosts")]
	Task<HostsResponse> GetAsync(CancellationToken cancellationToken);
}