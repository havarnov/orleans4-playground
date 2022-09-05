namespace grain.fsharp

open interfaces.fsharp

type HelloWorldGrainImpl () =
    interface IHelloWorldGrain with
        member this.Hello name = task {
            return Some(42)
        }

        member this.CustomTypes rall = task {
            return
                match rall with
                | Some rall ->
                    Some (Foo.Rall rall)
                | None ->
                    Some Foo.Bar
        }
