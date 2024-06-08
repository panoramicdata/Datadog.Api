using System.Text.Json.Serialization;

namespace Datadog.Api.Models.WebhooksIntegrations;

public class WebhooksIntegrationResponse
{
	[JsonPropertyName("webhook_integrations")]
	public required IReadOnlyCollection<WebhooksIntegration> WebhooksIntegrations { get; set; }
}