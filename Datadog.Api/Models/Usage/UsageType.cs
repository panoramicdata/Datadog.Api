using System.Runtime.Serialization;

namespace Datadog.Api.Models.Usage;
public enum UsageType
{
	[EnumMember(Value = "*")]
	All,

	[EnumMember(Value = "api_usage")]
	ApiUsage,

	[EnumMember(Value = "apm_fargate_usage")]
	ApmFargateUsage,

	[EnumMember(Value = "apm_host_usage")]
	ApmHostUsage,

	[EnumMember(Value = "apm_usm_usage")]
	ApmUsmUsage,

	[EnumMember(Value = "appsec_fargate_usage")]
	AppsecFargateUsage,

	[EnumMember(Value = "appsec_usage")]
	AppsecUsage,

	[EnumMember(Value = "asm_serverless_traced_invocations_usage")]
	AsmServerlessTracedInvocationsUsage,

	[EnumMember(Value = "asm_serverless_traced_invocations_percentage")]
	AsmServerlessTracedInvocationsPercentage,

	[EnumMember(Value = "browser_usage")]
	BrowserUsage,

	[EnumMember(Value = "ci_pipeline_indexed_spans_usage")]
	CiPipelineIndexedSpansUsage,

	[EnumMember(Value = "ci_test_indexed_spans_usage")]
	CiTestIndexedSpansUsage,

	[EnumMember(Value = "ci_visibility_itr_usage")]
	CiVisibilityItrUsage,

	[EnumMember(Value = "cloud_siem_usage")]
	CloudSiemUsage,

	[EnumMember(Value = "container_excl_agent_usage")]
	ContainerExclAgentUsage,

	[EnumMember(Value = "container_usage")]
	ContainerUsage,

	[EnumMember(Value = "cspm_containers_usage")]
	CspmContainersUsage,

	[EnumMember(Value = "cspm_hosts_usage")]
	CspmHostsUsage,

	[EnumMember(Value = "custom_event_usage")]
	CustomEventUsage,

	[EnumMember(Value = "custom_ingested_timeseries_usage")]
	CustomIngestedTimeseriesUsage,

	[EnumMember(Value = "custom_timeseries_usage")]
	CustomTimeseriesUsage,

	[EnumMember(Value = "cws_containers_usage")]
	CwsContainersUsage,

	[EnumMember(Value = "cws_hosts_usage")]
	CwsHostsUsage,

	[EnumMember(Value = "dbm_hosts_usage")]
	DbmHostsUsage,

	[EnumMember(Value = "dbm_queries_usage")]
	DbmQueriesUsage,

	[EnumMember(Value = "error_tracking_usage")]
	ErrorTrackingUsage,

	[EnumMember(Value = "error_tracking_percentage")]
	ErrorTrackingPercentage,

	[EnumMember(Value = "estimated_indexed_logs_usage")]
	EstimatedIndexedLogsUsage,

	[EnumMember(Value = "estimated_indexed_spans_usage")]
	EstimatedIndexedSpansUsage,

	[EnumMember(Value = "estimated_ingested_logs_usage")]
	EstimatedIngestedLogsUsage,

	[EnumMember(Value = "estimated_ingested_spans_usage")]
	EstimatedIngestedSpansUsage,

	[EnumMember(Value = "estimated_rum_sessions_usage")]
	EstimatedRumSessionsUsage,

	[EnumMember(Value = "fargate_usage")]
	FargateUsage,

	[EnumMember(Value = "functions_usage")]
	FunctionsUsage,

	[EnumMember(Value = "incident_management_monthly_active_users_usage")]
	IncidentManagementMonthlyActiveUsersUsage,

	[EnumMember(Value = "indexed_spans_usage")]
	IndexedSpansUsage,

	[EnumMember(Value = "infra_host_usage")]
	InfraHostUsage,

	[EnumMember(Value = "ingested_logs_bytes_usage")]
	IngestedLogsBytesUsage,

	[EnumMember(Value = "ingested_spans_bytes_usage")]
	IngestedSpansBytesUsage,

	[EnumMember(Value = "invocations_usage")]
	InvocationsUsage,

	[EnumMember(Value = "lambda_traced_invocations_usage")]
	LambdaTracedInvocationsUsage,

	[EnumMember(Value = "logs_indexed_15day_usage")]
	LogsIndexed15DayUsage,

	[EnumMember(Value = "logs_indexed_180day_usage")]
	LogsIndexed180DayUsage,

	[EnumMember(Value = "logs_indexed_1day_usage")]
	LogsIndexed1DayUsage,

	[EnumMember(Value = "logs_indexed_30day_usage")]
	LogsIndexed30DayUsage,

	[EnumMember(Value = "logs_indexed_360day_usage")]
	LogsIndexed360DayUsage,

	[EnumMember(Value = "logs_indexed_3day_usage")]
	LogsIndexed3DayUsage,

	[EnumMember(Value = "logs_indexed_45day_usage")]
	LogsIndexed45DayUsage,

	[EnumMember(Value = "logs_indexed_60day_usage")]
	LogsIndexed60DayUsage,

	[EnumMember(Value = "logs_indexed_7day_usage")]
	LogsIndexed7DayUsage,

	[EnumMember(Value = "logs_indexed_90day_usage")]
	LogsIndexed90DayUsage,

	[EnumMember(Value = "logs_indexed_custom_retention_usage")]
	LogsIndexedCustomRetentionUsage,

	[EnumMember(Value = "mobile_app_testing_usage")]
	MobileAppTestingUsage,

	[EnumMember(Value = "ndm_netflow_usage")]
	NdmNetflowUsage,

	[EnumMember(Value = "npm_host_usage")]
	NpmHostUsage,

	[EnumMember(Value = "obs_pipeline_bytes_usage")]
	ObsPipelineBytesUsage,

	[EnumMember(Value = "obs_pipelines_vcpu_usage")]
	ObsPipelinesVcpuUsage,

	[EnumMember(Value = "online_archive_usage")]
	OnlineArchiveUsage,

	[EnumMember(Value = "profiled_container_usage")]
	ProfiledContainerUsage,

	[EnumMember(Value = "profiled_fargate_usage")]
	ProfiledFargateUsage,

	[EnumMember(Value = "profiled_host_usage")]
	ProfiledHostUsage,

	[EnumMember(Value = "rum_browser_mobile_sessions_usage")]
	RumBrowserMobileSessionsUsage,

	[EnumMember(Value = "rum_replay_sessions_usage")]
	RumReplaySessionsUsage,

	[EnumMember(Value = "sds_scanned_bytes_usage")]
	SdsScannedBytesUsage,

	[EnumMember(Value = "serverless_apps_usage")]
	ServerlessAppsUsage,

	[EnumMember(Value = "siem_ingested_bytes_usage")]
	SiemIngestedBytesUsage,

	[EnumMember(Value = "snmp_usage")]
	SnmpUsage,

	[EnumMember(Value = "universal_service_monitoring_usage")]
	UniversalServiceMonitoringUsage,

	[EnumMember(Value = "vuln_management_hosts_usage")]
	VulnManagementHostsUsage,

	[EnumMember(Value = "workflow_executions_usage")]
	WorkflowExecutionsUsage
}
