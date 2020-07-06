#region snippet2
using System;
using System.Net.Http;
using System.Threading.Tasks;
using GrpcGreeter;
using Grpc.Net.Client;
using Newtonsoft.Json;

namespace GrpcGreeterClient
{
    class Program
    {
        #region snippet
        static async Task Main(string[] args)
        {
            // The port number(5001) must match the port of the gRPC server.
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(new HelloRequest { Name = "GreeterClient" });
            var reply2 = await client.SayHelloNewAsync(new HelloRequest { Name = "GreeterClientNew" });
            var reply3 = await client.SayIntAsync(new RPCRequest { Query = "20", Count = 1 });
            var replyJson = JsonConvert.SerializeObject(reply3);

            Console.WriteLine("Greeting: " + reply.Message);
            Console.WriteLine("Greeting: " + reply2.Message);
            Console.WriteLine("Greeting: " + replyJson);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
        #endregion
    }
}
#endregion
