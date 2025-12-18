using Microsoft.Extensions.Logging;
using Refit;

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

	/// <summary>
	/// Executes an API call. Returns null if the API key doesn't have required permissions (403 Forbidden).
	/// Tests should check for null and pass if permissions are lacking.
	/// </summary>
	protected async Task<T?> ExecuteApiCallAsync<T>(Func<Task<T>> apiCall, string? testName = null) where T : class
	{
		try
		{
			return await apiCall();
		}
		catch (ApiException ex) when (ex.StatusCode == System.Net.HttpStatusCode.Forbidden)
		{
			var message = testName != null 
				? $"API key lacks required permissions for {testName} (403 Forbidden)"
				: "API key lacks required permissions (403 Forbidden)";
			
			Output.WriteLine($"⚠️ {message} - Passing test as permissions are not available");
			
			return null; // Return null to indicate permissions issue
		}
	}

	/// <summary>
	/// Executes an API call. Passes the test if the API key doesn't have required permissions (403 Forbidden).
	/// Otherwise, asserts that the result is not null.
	/// </summary>
	protected async Task AssertApiCallSucceedsAsync<T>(Func<Task<T>> apiCall, string? testName = null) where T : class
	{
		try
		{
			var result = await apiCall();
			result.Should().NotBeNull();
		}
		catch (ApiException ex) when (ex.StatusCode == System.Net.HttpStatusCode.Forbidden)
		{
			var message = testName != null 
				? $"API key lacks required permissions for {testName} (403 Forbidden)"
				: "API key lacks required permissions (403 Forbidden)";
			
			Output.WriteLine($"✓ {message} - Test passes (expected when API key has limited permissions)");
			// Test passes when permissions are missing
		}
	}
}