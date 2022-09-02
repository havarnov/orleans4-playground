using Microsoft.FSharp.Core;
using Orleans;

namespace interfaces;

public interface IHelloWorldGrain : IGrainWithStringKey
{
    Task<FSharpOption<int>> Hello(FSharpOption<string> name);
}
