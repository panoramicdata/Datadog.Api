using Datadog.Api.Models;
using Datadog.Api.Models.Downtimes;
using Refit;

namespace Datadog.Api.Interfaces;

public interface IDowntimes
{
	[Get("/v2/downtime")]
	Task<GuidIdentifiedResponse<Downtime>> GetAsync(CancellationToken cancellationToken);
}