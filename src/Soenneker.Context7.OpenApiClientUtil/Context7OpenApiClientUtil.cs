using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.Context7.HttpClients.Abstract;
using Soenneker.Context7.OpenApiClientUtil.Abstract;
using Soenneker.Context7.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Context7.OpenApiClientUtil;

/// <inheritdoc cref="IContext7OpenApiClientUtil"/>
public sealed class Context7OpenApiClientUtil : IContext7OpenApiClientUtil
{
    private readonly AsyncSingleton<ClientState> _client;

    public Context7OpenApiClientUtil(IContext7OpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<ClientState>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient);

            return new ClientState(new Context7OpenApiClient(requestAdapter), requestAdapter);
        });
    }

    public async ValueTask<Context7OpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        ClientState state = await _client.Get(cancellationToken).NoSync();
        return state.Client;
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }

    private sealed class ClientState : IDisposable
    {
        private readonly HttpClientRequestAdapter _requestAdapter;

        public Context7OpenApiClient Client { get; }

        public ClientState(Context7OpenApiClient client, HttpClientRequestAdapter requestAdapter)
        {
            Client = client;
            _requestAdapter = requestAdapter;
        }

        public void Dispose()
        {
            _requestAdapter.Dispose();
        }
    }
}
