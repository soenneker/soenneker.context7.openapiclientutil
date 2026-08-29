using Soenneker.Context7.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Soenneker.Context7.OpenApiClientUtil.Abstract;
/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface IContext7OpenApiClientUtil: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Returns the configured context7 OpenAPI Client used by the Context7 OpenAPI Client.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested context7 OpenAPI Client.</returns>
    ValueTask<Context7OpenApiClient> Get(CancellationToken cancellationToken = default);
}
