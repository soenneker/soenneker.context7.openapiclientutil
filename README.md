[![](https://img.shields.io/nuget/v/soenneker.context7.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.context7.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.context7.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.context7.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.context7.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.context7.openapiclientutil/)

# Soenneker.Context7.OpenApiClientUtil

Exposes a cached OpenAPI client instance.

## Install

```bash
dotnet add package Soenneker.Context7.OpenApiClientUtil
```

## Quick start

```csharp
using Soenneker.Context7.OpenApiClientUtil.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddContext7OpenApiClientUtilAsSingleton();
```

Adds `Context7OpenApiClientUtil` as a singleton service.

## What you get

- `IContext7OpenApiClientUtil` — Exposes a cached OpenAPI client instance.
- `Context7OpenApiClientUtilRegistrar` — Registers the OpenAPI client utility for dependency injection.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `Context7OpenApiClientUtilRegistrar.AddContext7OpenApiClientUtilAsSingleton(services)` | Adds `Context7OpenApiClientUtil` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `Context7OpenApiClientUtilRegistrar.AddContext7OpenApiClientUtilAsScoped(services)` | Adds `Context7OpenApiClientUtil` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Reuse the registered client instead of constructing one per operation.
- Dispose instances you own when their scope ends so held resources can be released.
