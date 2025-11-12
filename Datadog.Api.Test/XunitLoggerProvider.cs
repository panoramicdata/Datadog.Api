using Microsoft.Extensions.Logging;

namespace Datadog.Api.Test;

/// <summary>
/// Logger provider that writes to XUnit test output
/// </summary>
public sealed class XunitLoggerProvider(ITestOutputHelper testOutputHelper) : ILoggerProvider
{
	public ILogger CreateLogger(string categoryName)
	{
		return new XunitLogger(testOutputHelper, categoryName);
	}

	public void Dispose()
	{
		// Nothing to dispose
	}

	private sealed class XunitLogger(ITestOutputHelper testOutputHelper, string categoryName) : ILogger
	{
		public IDisposable? BeginScope<TState>(TState state) where TState : notnull
		{
			return null;
		}

		public bool IsEnabled(LogLevel logLevel)
		{
			return logLevel >= LogLevel.Debug;
		}

		public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
		{
			if (!IsEnabled(logLevel))
				return;

			try
			{
				var message = formatter(state, exception);
				testOutputHelper.WriteLine($"[{logLevel}] {categoryName}: {message}");

				if (exception != null)
				{
					testOutputHelper.WriteLine(exception.ToString());
				}
			}
			catch
			{
				// ITestOutputHelper can throw if called from wrong context
				// Just swallow the exception
			}
		}
	}
}
