namespace interfaces.fsharp

open System.Threading.Tasks
open Orleans

[<Immutable; GenerateSerializer>]
type Rall = {
    [<Id(1us)>] Id: int
    [<Id(2us)>] Name: string
}

[<Immutable; GenerateSerializer>]
type Foo =
    | Bar
    | Rall of Rall

type IHelloWorldGrain =

    inherit IGrainWithStringKey

    abstract member Hello : string option -> Task<int option>
    abstract member CustomTypes : Rall option -> Task<Foo option>
