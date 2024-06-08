using Datadog.Api.Models.Usage;
using System.Text.Json.Serialization;

namespace Datadog.Api.Models;

[JsonDerivedType(typeof(StringIdentifiedEntity<HourlyUsage>), "usage_timeseries")]
public class StringIdentifiedBaseEntity : BaseEntity
{
	[JsonPropertyName("id")]
	public string? Id { get; set; }
}