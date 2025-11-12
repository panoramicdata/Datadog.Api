
namespace Datadog.Api.Models.Usage;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
internal class JsonPropertyAttribute : Attribute
{
}