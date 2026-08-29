using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Context7.HttpClients.Registrars;
using Soenneker.Context7.OpenApiClientUtil.Abstract;

namespace Soenneker.Context7.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class Context7OpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="Context7OpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddContext7OpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddContext7OpenApiHttpClientAsSingleton()
                .TryAddSingleton<IContext7OpenApiClientUtil, Context7OpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="Context7OpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddContext7OpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddContext7OpenApiHttpClientAsSingleton()
                .TryAddScoped<IContext7OpenApiClientUtil, Context7OpenApiClientUtil>();

        return services;
    }
}
