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
        private TcpListener m_TcpListener;
        private ConcurrentDictionary<int, Client> m_Clients;

        private UdpClient m_UdpListener;

        private void UDP_Listen()
        {

        }

        private void TCP_ClientMethod(int Index)
        {
            // client method used to read and write to client
            Client client = m_Clients[Index]; // get client from index
            Packet recievedPacket;

            Console.WriteLine("client method called");

            while (((recievedPacket = client.Read()) != null)) //blocking call unitl readline recieves data
            {               
                switch (recievedPacket.m_PacketType)
                {
                    case PacketType.ChatMessage: // chat message
                        ChatMessagePacket chatPacket = (ChatMessagePacket)recievedPacket; // cast packet as chat packet
                        
                        
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
            m_TcpListener = new TcpListener(ip, port); // create instance of TcpListener
            m_UdpListener = new UdpClient(port);

            var thread = new Thread(() => { UDP_Listen(); }); // start udp listen thread
            thread.Start();

        }

        public void Start()
        {
            // start method
            m_Clients = new ConcurrentDictionary<int, Client>();
            int clientIndex = 0;
            m_TcpListener.Start();
            Console.WriteLine("Listener started");
            while (clientIndex < 10)
            {
                //accept pending connection
                Socket socket = m_TcpListener.AcceptSocket(); //program will wait here for value to be returned
                Console.WriteLine("Socket accpeted");
                
                var client = new Client(socket);
                int index = clientIndex;
                clientIndex++;

                m_Clients.TryAdd(index, client);

                var thread = new Thread(() => {TCP_ClientMethod(index);});
                thread.Start();

                Console.WriteLine("Thread started");
            }
        }
        public void Stop()
        {
            // stop method
            m_TcpListener.Stop(); // do not accept any more connections
        }

    }
}
