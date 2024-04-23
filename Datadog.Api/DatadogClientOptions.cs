
using Microsoft.Extensions.Logging;

namespace Datadog.Api;

public class DatadogClientOptions
{
	/// <summary>
	/// The API key to use for authentication
	/// </summary>
	public required string ApiKey { get; set; }

	/// <summary>
	/// The optional application key to use for authentication.
	/// Needed for some endpoints
	/// </summary>
	public string? ApplicationKey { get; set; }

	/// <summary>
	/// An optional user agent to use for the requests
	/// </summary>
	public string? UserAgent { get; set; }

	/// <summary>
	/// An optional logger
	/// </summary>
	public ILogger? Logger { get; set; }
}