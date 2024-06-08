using System.Runtime.Serialization;

namespace Datadog.Api.Models.Metrics;

public enum MetricType
{
	[EnumMember(Value = "count")]
	Count,
	[EnumMember(Value = "gauge")]
	Gauge,
	[EnumMember(Value = "rate")]
	Rate,
	[EnumMember(Value = "set")]
	Set
}