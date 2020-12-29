using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using Packets;

namespace Server
{
    class Server
    {
        private TcpListener m_TcpListener;
        private ConcurrentDictionary<int, Client> m_Clients;
        private ConcurrentDictionary<int, String> m_Names;
        public Packet m_RecievedPacket;
        private UdpClient m_UdpListener;
        private BinaryFormatter m_Formatter;

        private void UDP_Listen()
        {
            //process server response
            try
            {
                var endPoint = new IPEndPoint(IPAddress.Any, 0);

                while (true)
                {
                    byte[] bytes = m_UdpListener.Receive(ref endPoint);

                    MemoryStream memStream = new MemoryStream(bytes);
                    m_RecievedPacket = m_Formatter.Deserialize(memStream) as Packet; //deserialize data

                    foreach (KeyValuePair<int, Client> entry in m_Clients) //iterate over every entry in dictionary
                    {
                        if (endPoint.ToString() == entry.Value.m_IPEndPoint.ToString())
                        {
                            // handle packet
                        }
                    }
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("Client UDP read method exception: " + e.Message);
            }
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

                        try
                        {
                            string name1 = m_Names[Index];
                            chatPacket.m_Message = name1 + ": " + chatPacket.m_Message;
                            
                            for (int i = 0; i < m_Clients.Count; i++)
                            {
                                m_Clients[i].Send(chatPacket);
                            }
                            
                            
                        }
                        catch
                        {
                            chatPacket.m_Message = "set a nickname";
                            client.Send(chatPacket);
                        }              
                        break;
                    case PacketType.ClientName: // Private message

                        PrivateMessage privateMessage = (PrivateMessage)recievedPacket; //cast packet as private message

                        string destination = privateMessage.m_Destination;
                        string sender = privateMessage.m_Sender;
                        string message = privateMessage.m_Message;

                        var privateMessageSend = new ChatMessagePacket(message);
                        privateMessageSend.m_Message = "From " + sender + ": " + message;
                        var key = m_Names.FirstOrDefault(i => i.Value == destination).Key;
                        m_Clients[key].Send(privateMessageSend);

                        break;
                    case PacketType.PrivateMessage: //client name
                        break;
                    case PacketType.Login: //login

                        Console.WriteLine("Login packet recieved");

                        LoginPacket loginPacket = (LoginPacket)recievedPacket; // cast packet as login packet                     
                        m_Clients[Index].m_IPEndPoint = loginPacket.m_EndPoint;  //set clients IP Endpoint to one stored inpacket

                        foreach (KeyValuePair<int, Client> entry in m_Clients) //iterate over every entry in dictionary
                        {
                            MemoryStream memStream = new MemoryStream(); //used to store binary data
                            m_RecievedPacket = recievedPacket;
                            m_Formatter.Serialize(memStream, m_RecievedPacket);
                            byte[] buffer = memStream.GetBuffer();
                            m_UdpListener.Send(buffer, buffer.Length, entry.Value.m_IPEndPoint); // send data back to client
                        }
                        break;

                    case PacketType.Encrypt: //encrypt packet
                        EncryptPacket encryptPacket = (EncryptPacket)recievedPacket; //cast packet as encrypt packet
                        m_Clients[Index].M_ClientKey = encryptPacket.m_PublicKey;

                        Console.WriteLine("client key recieved: " + m_Clients[Index].M_ClientKey);

                        break;
                    case PacketType.SetNickName:
                        SetNickName setNickName = (SetNickName)recievedPacket; // cast packet as nickname packet
                        string name = setNickName.m_NickName;
                        m_Names.TryAdd(Index, name);

                        Console.WriteLine("Added nickname: " + name);

                        break;

                    case PacketType.localGameUpdate:
                        LocalGameUpdate localGameUpdate = (LocalGameUpdate)recievedPacket;
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

            m_Formatter = new BinaryFormatter();
     


            var thread = new Thread(() => { UDP_Listen(); }); // start udp listen thread
            thread.Start();

        }

        public void Start()
        {
            // start method
            m_Clients = new ConcurrentDictionary<int, Client>();
            m_Names = new ConcurrentDictionary<int, string>();
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
