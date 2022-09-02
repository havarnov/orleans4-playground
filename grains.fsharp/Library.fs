namespace grain.fsharp

open interfaces

type HelloWorldGrainImpl () =
    interface IHelloWorldGrain with
        member this.Hello name = task {
            return Some(42)
        }
