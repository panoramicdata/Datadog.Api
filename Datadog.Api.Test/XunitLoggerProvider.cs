using Microsoft.Extensions.Logging;
using System.Text;

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
		// AsyncLocal, rather than a field, so that scopes opened on one asynchronous
		// flow are not observed by tests running in parallel on another.
		private readonly AsyncLocal<Scope?> _currentScope = new();

		public IDisposable BeginScope<TState>(TState state) where TState : notnull
		{
			return new Scope(this, state);
		}

		public bool IsEnabled(LogLevel logLevel)
		{
			return logLevel >= LogLevel.Debug;
		}

		public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
		{
			if (!IsEnabled(logLevel))
			{
				return;
			}

			try
			{
				var message = formatter(state, exception);
				testOutputHelper.WriteLine($"[{logLevel}]{FormatEventId(eventId)} {categoryName}:{FormatScopes()} {message}");

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

		private static string FormatEventId(EventId eventId)
		{
			return eventId.Id == 0 && eventId.Name is null
				? string.Empty
				: $"[{eventId}]";
		}

		private string FormatScopes()
		{
			var scope = _currentScope.Value;
			if (scope is null)
			{
				return string.Empty;
			}

			// Scopes are chained innermost-first, so collect then reverse for readability.
			var states = new List<object>();
			for (var current = scope; current is not null; current = current.Parent)
			{
				states.Add(current.State);
			}

			states.Reverse();

			var builder = new StringBuilder();
			foreach (var state in states)
			{
				builder.Append(" => ").Append(state);
			}

			return builder.ToString();
		}

		private sealed class Scope : IDisposable
		{
			private readonly XunitLogger _logger;

			public Scope(XunitLogger logger, object state)
			{
				_logger = logger;
				State = state;
				Parent = logger._currentScope.Value;
				logger._currentScope.Value = this;
			}

			public object State { get; }

			public Scope? Parent { get; }

			public void Dispose() => _logger._currentScope.Value = Parent;
		}
	}
}
