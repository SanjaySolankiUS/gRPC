using System;
using Grpc.Core;

namespace GRPC_Server
{
    class Program
    {
        const int port = 50051;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Server!");
            Server server = null;
            try
            {
                server = new Server()
                {
                    Ports = { new ServerPort("localhost", port, ServerCredentials.Insecure) }
                };
                server.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Message: " + ex.Message);
            }
            finally {
                if (server != null)
                    server.ShutdownAsync().Wait();
            }
        }
    }
}
