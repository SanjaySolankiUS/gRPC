using System;
using Grpc.Core;

namespace GRPC_Client
{
    class Program
    {
        const string target = "127.0.0.1:50051";
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Client!");
            try
            {
                Channel channel = new Channel(target, ChannelCredentials.Insecure);
                channel.ConnectAsync().ContinueWith(t =>
                {
                    if (t.Status == System.Threading.Tasks.TaskStatus.RanToCompletion)
                        Console.WriteLine("Connected!!!!");
                });
                var client = new Dummy.DummyService.DummyServiceClient(channel);
                channel.ShutdownAsync().Wait();
                Console.ReadKey();
            }
            catch (Exception ex)
            { }
        }
    }
}
