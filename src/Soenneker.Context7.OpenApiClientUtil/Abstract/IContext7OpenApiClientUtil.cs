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
    ValueTask<Context7OpenApiClient> Get(CancellationToken cancellationToken = default);
}
