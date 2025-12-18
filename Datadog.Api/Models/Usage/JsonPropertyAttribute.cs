
namespace Datadog.Api.Models.Usage;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
internal sealed class JsonPropertyAttribute : Attribute
{
}