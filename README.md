# Datadog.Api

A .NET API for Datadog

## Unit Tests

To run unit tests, set up your unit test User secrets to match the usersecrets.example.json file.

## Usage

```csharp
using Datadog.Api;

var client = new DatadogClient(new()
{
	ApiKey = "API_KEY",
	ApplicationKey = "APPLICATION_KEY"
});

var users = await client.Users.GetAllAsync();
```