using Datadog.Api.Models;
using Refit;

namespace Datadog.Api.Interfaces;

public interface IDashboards
{
	[Get("/v1/dashboard")]
	Task<DashboardsResponse> GetAsync(CancellationToken cancellationToken);
}
