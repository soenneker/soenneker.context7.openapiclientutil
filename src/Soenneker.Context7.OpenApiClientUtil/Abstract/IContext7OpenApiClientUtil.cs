using Soenneker.Context7.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Soenneker.Context7.OpenApiClientUtil.Abstract;

/// <summary>
/// Provides a lazily created Context7 OpenAPI client for the service lifetime.
/// </summary>
public interface IContext7OpenApiClientUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Returns the cached, configured Context7 OpenAPI client.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the generated client.</returns>
    ValueTask<Context7OpenApiClient> Get(CancellationToken cancellationToken = default);
}
