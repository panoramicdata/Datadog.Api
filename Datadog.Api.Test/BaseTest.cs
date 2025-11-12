using Microsoft.Extensions.Logging;

namespace Datadog.Api.Test;

public class BaseTest : IClassFixture<DatadogClientFixture>
{
	protected DatadogClient Client { get; }
	protected ITestOutputHelper Output { get; }
	protected static CancellationToken CancellationToken => TestContext.Current.CancellationToken;

	public BaseTest(DatadogClientFixture fixture, ITestOutputHelper output)
	{
		Output = output;

		// Create a logger factory that writes to XUnit test output
		var loggerFactory = LoggerFactory.Create(builder =>
		{
			builder
				.SetMinimumLevel(LogLevel.Debug)
				.AddProvider(new XunitLoggerProvider(output));
		});

		var logger = loggerFactory.CreateLogger<DatadogClient>();

		// Create a new client instance with XUnit logging for this test
		Client = new DatadogClient(new DatadogClientOptions
		{
			ApiKey = fixture.Configuration["ApiKey"]
				?? throw new InvalidOperationException("Missing config: ApiKey. Please configure user secrets."),
			ApplicationKey = fixture.Configuration["ApplicationKey"],
			UserAgent = "Datadog.Api.Test",
			Logger = logger
		});
	}
}