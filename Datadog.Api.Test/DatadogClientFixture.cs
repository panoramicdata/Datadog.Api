using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Datadog.Api.Test;

public class DatadogClientFixture : IDisposable
{
	private bool _disposed;

	public DatadogClient Client { get; }
	public IConfiguration Configuration { get; }
	public ILoggerFactory LoggerFactory { get; }

	public DatadogClientFixture()
	{
		// Load configuration
		Configuration = new ConfigurationBuilder()
			.AddJsonFile("appsettings.json", optional: true)
			.AddEnvironmentVariables()
			.AddUserSecrets<DatadogClientFixture>()
			.Build();

		// Get API credentials
		var apiKey = Configuration["ApiKey"]
			?? throw new InvalidOperationException("Missing config: ApiKey. Please configure user secrets.");
		var applicationKey = Configuration["ApplicationKey"];

		// Create logger factory with debug output
		LoggerFactory = Microsoft.Extensions.Logging.LoggerFactory.Create(builder =>
		{
			builder
				.SetMinimumLevel(LogLevel.Debug)
				.AddDebug();
		});

		var logger = LoggerFactory.CreateLogger<DatadogClient>();

		Client = new DatadogClient(new DatadogClientOptions
		{
			ApiKey = apiKey,
			ApplicationKey = applicationKey,
			UserAgent = "Datadog.Api.Test",
			Logger = logger
		});
	}

	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (_disposed)
			return;

		if (disposing)
		{
			Client?.Dispose();
			LoggerFactory?.Dispose();
		}

		_disposed = true;
	}
}
