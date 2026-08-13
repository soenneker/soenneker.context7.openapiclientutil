using Soenneker.Context7.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Context7.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class Context7OpenApiClientUtilTests : HostedUnitTest
{
    private readonly IContext7OpenApiClientUtil _openapiclientutil;

    public Context7OpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<IContext7OpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
