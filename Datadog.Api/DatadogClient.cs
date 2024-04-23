using Datadog.Api.Interfaces;
using Refit;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Datadog.Api;

public class DatadogClient : IDisposable
{
	private readonly HttpClient _httpClient;
	private bool disposedValue;

	public DatadogClient(DatadogClientOptions options)
	{
		_httpClient = new HttpClient(new AuthenticatedHttpClientHandler(options))
		{
			BaseAddress = new Uri("https://api.datadoghq.com/api")
		};

		var refitSettings = new RefitSettings
		{
			ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
				Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },
				UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow
			})
		};

		Containers = RestService.For<IContainers>(_httpClient, refitSettings);
		Dashboards = RestService.For<IDashboards>(_httpClient, refitSettings);
		Hosts = RestService.For<IHosts>(_httpClient, refitSettings);
		Roles = RestService.For<IRoles>(_httpClient, refitSettings);
		Users = RestService.For<IUsers>(_httpClient, refitSettings);
	}

	public IContainers Containers { get; set; }

	public IDashboards Dashboards { get; set; }

	public IHosts Hosts { get; set; }

	public IUsers Users { get; set; }

	public IRoles Roles { get; set; }

	protected virtual void Dispose(bool disposing)
	{
		if (!disposedValue)
		{
			if (disposing)
			{
				_httpClient?.Dispose();
			}

			disposedValue = true;
		}
	}

	public void Dispose()
	{
		// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}
}
