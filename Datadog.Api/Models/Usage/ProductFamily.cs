using System.Runtime.Serialization;

namespace Datadog.Api.Models.Usage;
public enum ProductFamily
{
	[EnumMember(Value = "all")]
	All,

	[EnumMember(Value = "analyzed_logs")]
	AnalyzedLogs,

	[EnumMember(Value = "application_security")]
	ApplicationSecurity,

	[EnumMember(Value = "audit_trail")]
	AuditTrail,

	[EnumMember(Value = "serverless")]
	Serverless,

	[EnumMember(Value = "ci_app")]
	CIApp,

	[EnumMember(Value = "cloud_cost_management")]
	CloudCostManagement,

	[EnumMember(Value = "csm_container_enterprise")]
	CSMContainerEnterprise,

	[EnumMember(Value = "csm_host_enterprise")]
	CSMHostEnterprise,

	[EnumMember(Value = "cspm")]
	CSPM,

	[EnumMember(Value = "custom_events")]
	CustomEvents,

	[EnumMember(Value = "cws")]
	CWS,

	[EnumMember(Value = "dbm")]
	DBM,

	[EnumMember(Value = "error_tracking")]
	ErrorTracking,

	[EnumMember(Value = "fargate")]
	Fargate,

	[EnumMember(Value = "infra_hosts")]
	InfraHosts,

	[EnumMember(Value = "incident_management")]
	IncidentManagement,

	[EnumMember(Value = "indexed_logs")]
	IndexedLogs,

	[EnumMember(Value = "indexed_spans")]
	IndexedSpans,

	[EnumMember(Value = "ingested_spans")]
	IngestedSpans,

	[EnumMember(Value = "iot")]
	IoT,

	[EnumMember(Value = "lambda_traced_invocations")]
	LambdaTracedInvocations,

	[EnumMember(Value = "logs")]
	Logs,

	[EnumMember(Value = "network_flows")]
	NetworkFlows,

	[EnumMember(Value = "network_hosts")]
	NetworkHosts,

	[EnumMember(Value = "netflow_monitoring")]
	NetflowMonitoring,

	[EnumMember(Value = "observability_pipelines")]
	ObservabilityPipelines,

	[EnumMember(Value = "online_archive")]
	OnlineArchive,

	[EnumMember(Value = "profiling")]
	Profiling,

	[EnumMember(Value = "rum")]
	Rum,

	[EnumMember(Value = "rum_browser_sessions")]
	RumBrowserSessions,

	[EnumMember(Value = "rum_mobile_sessions")]
	RumMobileSessions,

	[EnumMember(Value = "sds")]
	SDS,

	[EnumMember(Value = "snmp")]
	SNMP,

	[EnumMember(Value = "synthetics_api")]
	SyntheticsAPI,

	[EnumMember(Value = "synthetics_browser")]
	SyntheticsBrowser,

	[EnumMember(Value = "synthetics_mobile")]
	SyntheticsMobile,

	[EnumMember(Value = "synthetics_parallel_testing")]
	SyntheticsParallelTesting,

	[EnumMember(Value = "timeseries")]
	Timeseries
}
