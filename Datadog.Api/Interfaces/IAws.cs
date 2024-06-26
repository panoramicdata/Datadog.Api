﻿using Datadog.Api.Models;
using Datadog.Api.Models.Aws;
using Refit;

namespace Datadog.Api.Interfaces;

/// <summary>
/// See <a href="https://docs.datadoghq.com/api/latest/aws-integration/">https://docs.datadoghq.com/api/latest/aws-integration/</a>
/// </summary>
public interface IAws
{
	/// <summary>
	/// Get all AWS tag filters.
	/// </summary>
	/// <seealso href="https://docs.datadoghq.com/api/latest/aws-integration/#get-all-aws-tag-filters"/>
	/// <param name="cancellationToken">The cancellation token.</param>
	[Get("/v1/integration/aws/filtering")]
	Task<GuidIdentifiedResponse<AwsTagFilters>> GetTagFiltersAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Get all AWS namespace rules.
	/// </summary>
	/// <seealso href="https://docs.datadoghq.com/api/latest/aws-integration/#list-namespace-rules"/>
	/// <param name="cancellationToken">The cancellation token.</param>
	[Get("/v1/integration/aws/available_namespace_rules")]
	Task<GuidIdentifiedResponse<NamespaceRules>> GetNamespaceRulesAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Get all Amazon EventBridge sources
	/// </summary>
	/// <seealso href="https://docs.datadoghq.com/api/latest/aws-integration/#get-all-amazon-eventbridge-sources"/>
	[Get("/v1/integration/aws/event_bridge")]
	Task<GuidIdentifiedResponse<EventBridgeSources>> GetEventBridgeSourcesAsync(
		CancellationToken cancellationToken);
}
