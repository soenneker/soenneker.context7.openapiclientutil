[![](https://img.shields.io/nuget/v/soenneker.context7.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.context7.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.context7.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.context7.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.context7.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.context7.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.context7.openapiclientutil/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.context7.openapiclientutil/actions/workflows/codeql.yml)

# Soenneker.Context7.OpenApiClientUtil

Provides a lazily created, reusable Context7 Kiota client backed by the configured Context7 HTTP provider.

## Install

```bash
dotnet add package Soenneker.Context7.OpenApiClientUtil
```

## Configuration

```json
{
  "Context7": {
    "ApiKey": "ctx7sk-..."
  }
}
```

The underlying HTTP package defaults to `https://context7.com/api/` and `Authorization: Bearer <ApiKey>`. It also supports `Context7:ClientBaseUrl`, `Context7:AuthHeaderName`, and `Context7:AuthHeaderValueTemplate` for compatible gateways or proxies.

## Registration

```csharp
using Soenneker.Context7.OpenApiClientUtil.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddContext7OpenApiClientUtilAsSingleton();
```

Use `AddContext7OpenApiClientUtilAsScoped()` when each application scope should cache its own generated client while sharing the singleton HTTP provider.

## Usage

```csharp
using Soenneker.Context7.OpenApiClient.Models;
using Soenneker.Context7.OpenApiClientUtil.Abstract;

public sealed class DocumentationSearch(IContext7OpenApiClientUtil clientUtil)
{
    public async ValueTask<SearchResponse?> Search(string library, string question, CancellationToken cancellationToken)
    {
        var client = await clientUtil.Get(cancellationToken);

        return await client.V2.Libs.Search.GetAsync(
            request =>
            {
                request.QueryParameters.LibraryName = library;
                request.QueryParameters.Query = question;
            },
            cancellationToken);
    }
}
```

`Get` initializes the client once for the utility's lifetime. Concurrent callers share that initialization and receive the same client instance.

## Practical notes

- Configuration is captured when the underlying HTTP client is first created. Recreate the service lifetime to apply a changed API key or base URL.
- Both registrations use a singleton HTTP provider. Disposing a scoped utility releases its generated-client reference without removing the shared `HttpClient`; the HTTP provider disposes that client when the application container shuts down.
- Generated endpoint results may be nullable, and service errors are surfaced through generated error models or Kiota exceptions.
- Redact API keys and authorization headers from logs, traces, and exception diagnostics.
