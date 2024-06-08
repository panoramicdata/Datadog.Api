using Datadog.Api.Models;
using Datadog.Api.Models.Usage;
using Refit;

namespace Datadog.Api.Interfaces;

public interface IUsage
{
	/// <summary>
	/// Get hourly usage by product family.
	/// This endpoint requires the usage_read authorization scope.
	/// </summary>
	/// <param name="startHour">Datetime in ISO-8601 format, UTC, precise to hour: [YYYY-MM-DDThh] for usage beginning at this hour.</param>
	/// <param name="endHour">Datetime in ISO-8601 format, UTC, precise to hour: [YYYY-MM-DDThh] for usage ending before this hour.</param>
	/// <param name="productFamilies">Comma separated list of product families to retrieve.</param>
	/// <param name="includeDescendants">Include child organization usage in the response. Defaults to false.</param>
	/// <param name="includeBreakdown">Include breakdown of usage by subcategories where applicable (for product family logs only). Defaults to false.</param>
	/// <param name="versions">Comma separated list of product family versions to use in the format product_family:version.</param>
	/// <param name="limit">Maximum number of results to return (between 1 and 500) - defaults to 500 if limit not specified.</param>
	/// <param name="nextRecordId">List following results with a next_record_id provided in the previous query.</param>
	/// <param name="cancellationToken"></param>
	/// <seealso href="https://docs.datadoghq.com/api/latest/usage-metering/"/>
	[Get("/v2/usage/hourly_usage")]
	Task<StringIdentifiedResponse<HourlyUsage>> GetAsync(
		[AliasAs("filter[timestamp][start]")] string startHour,
		[AliasAs("filter[timestamp][end]")] string endHour,
		[AliasAs("filter[product_families]")] IReadOnlyCollection<ProductFamily> productFamilies,
		[AliasAs("filter[include_descendants]")] bool includeDescendants = false,
		[AliasAs("filter[include_breakdown]")] bool includeBreakdown = false,
		[AliasAs("filter[versions]")] string? versions = null,
		[AliasAs("page[limit]")] int limit = 500,
		[AliasAs("page[next_record_id]")] string? nextRecordId = null,
		CancellationToken cancellationToken = default);
}
