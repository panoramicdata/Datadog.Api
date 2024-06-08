using Datadog.Api.Models.DashboardLists;
using Refit;

namespace Datadog.Api.Interfaces;

public interface IDashboardLists
{
	[Get("/v1/dashboard/lists/manual")]
	Task<DashboardListsResponse> GetAsync(CancellationToken cancellationToken);
}
