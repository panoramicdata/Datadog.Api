using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit.DependencyInjection.Logging;

namespace Datadog.Api.Test;

public class Startup
{
	public static void ConfigureServices(IServiceCollection services)
	{
		// Load config
		var config = new ConfigurationBuilder()
			.AddJsonFile("appsettings.json", true)
			.AddEnvironmentVariables()
			.AddUserSecrets<Startup>()
			.Build();

		services
			.AddLogging(lb => lb
				.AddDebug()
				.AddFilter(level => level >= LogLevel.Debug)
				.AddXunitOutput()
			)
			.AddTransient(s =>
				new DatadogClient(new DatadogClientOptions
				{
					ApiKey = config["ApiKey"] ?? throw new FormatException("Missing config: ApiKey"),
					ApplicationKey = config["ApplicationKey"],
					UserAgent = "Datadog.Api.Test",
					Logger = s.GetRequiredService<ILogger<DatadogClient>>()
				})
			)
			;
	}
}
