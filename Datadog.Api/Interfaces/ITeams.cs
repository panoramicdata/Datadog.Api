using Datadog.Api.Models;
using Datadog.Api.Models.Teams;
using Refit;

namespace Datadog.Api.Interfaces;

public interface ITeams
{
	[Get("/v2/team")]
	Task<GuidIdentifiedResponse<Team>> GetAsync(
		[AliasAs("page[number]")] int? page = null,
		[AliasAs("page[size]")] int? pageSize = null,
		[AliasAs("sort")] string? sort = null,
		[AliasAs("filter[keyword]")] string? filterKeyword = null,
		[AliasAs("filter[me]")] bool? filterMe = null,
		[AliasAs("fields[team]")] ICollection<string>? fields = null,
		CancellationToken cancellationToken = default
		);
}
