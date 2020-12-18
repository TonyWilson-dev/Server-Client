using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {

            var server = new Server("127.0.0.1", 4444);

            Console.WriteLine("Server created");

            server.Start();

            server.Stop();

        }
    }

    

}
