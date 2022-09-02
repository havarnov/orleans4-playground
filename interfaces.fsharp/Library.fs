namespace interfaces.fsharp

open System.Threading.Tasks
open Orleans;

type IHelloWorldGrain =

    inherit IGrainWithStringKey

    abstract member Hello : string option -> Task<int option>
