open System
open System.Threading.Tasks
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Orleans;
open Orleans.Configuration;
open Orleans.Hosting
open Orleans.Serialization
open interfaces

let builder = Host.CreateDefaultBuilder()

builder.ConfigureServices(Action<IServiceCollection>(fun services ->
    services.AddSerializer(Action<ISerializerBuilder>(fun sb ->
        ()
    )) |> ignore
    services.AddOrleansClient(Action<IClientBuilder>(fun client ->
        client.UseLocalhostClustering() |> ignore
        client.Configure<ClusterOptions>(Action<ClusterOptions>(fun options ->
            options.ClusterId <- "Local";
            options.ServiceId <- "OrleansStarterTemplate"
        )) |> ignore
        ()
    )) |> ignore
    ()
)) |> ignore


let main () = task {
    let host = builder.Build();
    let _ = host.RunAsync()
    let clusterClient = host.Services.GetRequiredService<IClusterClient>();
    do! Task.Delay(1000)

    while true do
        let! res = clusterClient.GetGrain<IHelloWorldGrain>("yo").Hello(Some("yada"))
        printfn "%A" res
        do! Task.Delay(TimeSpan.FromSeconds(5))

    do! host.StopAsync(TimeSpan.FromSeconds(2000));
    return ()
}

(main ()).GetAwaiter().GetResult()

