using Microsoft.AspNetCore.SignalR.Client;

class Program
{
    static async Task Main(string[] args)
    {
        var hubConnection = new HubConnectionBuilder()
            .WithUrl("https://localhost:7047/locationHub")
            .Build();

        hubConnection.On<string>("ReceiveRequestInfo", (message) =>
        {
            Console.WriteLine($"Request was sent: {message}");
        });

        await hubConnection.StartAsync();
        Console.WriteLine("Connected!");
        
        Console.ReadLine();
        await hubConnection.StopAsync();
    }
}