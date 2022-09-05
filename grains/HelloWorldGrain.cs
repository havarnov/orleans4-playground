using grain.fsharp;
using interfaces.fsharp;
using Microsoft.Extensions.Logging;
using Microsoft.FSharp.Core;
using Orleans;
using Orleans.Runtime;
using IHelloWorldGrain = interfaces.IHelloWorldGrain;

namespace grains;

public class HelloWorldGrain : IHelloWorldGrain, IGrainBase
{
    private readonly ILogger<HelloWorldGrain> _logger;
    private readonly interfaces.fsharp.IHelloWorldGrain _impl;

    public HelloWorldGrain(IGrainContext grainContext, ILogger<HelloWorldGrain> logger)
    {
        _logger = logger;
        GrainContext = grainContext;
        _impl = new HelloWorldGrainImpl();
    }

    public Task OnActivateAsync(CancellationToken token)
    {
        _logger.LogInformation("Hello grain {GrainId} was activated", GrainContext.GrainId);
        return Task.CompletedTask;
    }

    public IGrainContext GrainContext { get; }

    public Task<FSharpOption<int>> Hello(FSharpOption<string> name) => _impl.Hello(name);
    public Task<FSharpOption<Foo>> CustomTypes(FSharpOption<Rall> rall) => _impl.CustomTypes(rall);
}
