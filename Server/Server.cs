using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Packets;

namespace Server
{
    class Server
    {
        private TcpListener m_tcplistener;
        private ConcurrentDictionary<int, Client> m_Clients;

        private void ClientMethod(int Index)
        {
            // client method used to read and write to client
            Client client = m_Clients[Index]; // get client from index
            Packets.Packet recievedPacket;

            Console.WriteLine("client method called");

            while (((recievedPacket = client.Read()) != null)) //blocking call unitl readline recieves data
            {               
                switch (recievedPacket.m_PacketType)
                {
                    case PacketType.ChatMessage: // chat message
                        ChatMessagePacket chatPacket = (ChatMessagePacket)recievedPacket;
                        client.Send(chatPacket);
                        break;
                    case PacketType.ClientName: // Private message
                        break;
                    case PacketType.PrivateMessage: //client name
                        break;
                }   
            }
            m_Clients[Index].Close();
            m_Clients.TryRemove(Index, out client);
        }
        public Server(string ipAddress, int port)
        {
            //constructor for sever class
            IPAddress ip = IPAddress.Parse(ipAddress);
            m_tcplistener = new TcpListener(ip, port); // create instance of TcpListener
        }

        public void Start()
        {
            // start method
            m_Clients = new ConcurrentDictionary<int, Client>();
            int clientIndex = 0;
            m_tcplistener.Start();
            Console.WriteLine("Listener started");
            while (clientIndex < 10)
            {
                //accept pending connection
                Socket socket = m_tcplistener.AcceptSocket(); //program will wait here for value to be returned
                Console.WriteLine("Socket accpeted");
                
                var client = new Client(socket);
                int index = clientIndex;
                clientIndex++;

                m_Clients.TryAdd(index, client);

                var thread = new Thread(() => {ClientMethod(index);});
                thread.Start();

                Console.WriteLine("Thread started");
            }
        }
        public void Stop()
        {
            // stop method
            m_tcplistener.Stop(); // do not accept any more connections
        }

    }
}
