﻿using Datadog.Api.Models;
using Datadog.Api.Models.WebhooksIntegrations;
using Refit;

namespace Datadog.Api.Interfaces;

public interface IWebhooksIntegrations
{
	[Get("/v1/integration/webhooks/configuration/webhooks")]
	Task<Response<WebhooksIntegration>> GetAsync(CancellationToken cancellationToken);
}
