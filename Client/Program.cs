﻿using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new Client();

            Console.WriteLine("Client created");

            if (client.Connect("127.0.0.1", 4444))
            {
                Console.WriteLine("Connection successful");
                client.Run();
            }
            else
            {
                Console.WriteLine("Connection unsuccessful");
            }
        }
    }
}