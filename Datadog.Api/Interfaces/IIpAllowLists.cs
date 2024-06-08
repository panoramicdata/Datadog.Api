using Datadog.Api.Models.IpAllowLists;
using Refit;

namespace Datadog.Api.Interfaces;

public interface IIpAllowLists
{
	[Get("/v2/ip_allowlist")]
	Task<IpAllowListsResponse> GetAsync(CancellationToken cancellationToken);
}
