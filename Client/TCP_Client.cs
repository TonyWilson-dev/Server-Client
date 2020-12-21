using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Packets;
using System.Text.RegularExpressions;

namespace Client
{
    public class TCP_Client
    {
        private TcpClient m_TcpClient;
        private NetworkStream m_NetworkStream;
        private BinaryWriter m_Writer;
        private BinaryReader m_Reader;
        private ClientForm m_ClientForm;
        private BinaryFormatter m_Formatter;
        private MemoryStream m_TCPMemoryStream;
        private MemoryStream m_UDPMemoryStream;
        private Packet recievedPacket;

        private UdpClient m_UdpClient;
        public TCP_Client()
        {
            //constructor
            m_ClientForm = new ClientForm(this);
            m_TcpClient = new TcpClient();
            
            m_Formatter = new BinaryFormatter();           
        }

        public void TCP_SendMessage(Packet packet)
        {
            m_TCPMemoryStream = new MemoryStream();

            m_Formatter.Serialize(m_TCPMemoryStream, packet);
            byte[] buffer = m_TCPMemoryStream.GetBuffer();
            m_Writer.Write(buffer.Length);
            m_Writer.Write(buffer);
            m_Writer.Flush();

            Console.WriteLine("TCP message sent");
        }

        public bool Connect(string ipAdress, int port)
        {
            try
            {
                m_TcpClient.Connect(ipAdress, port); // connect to server
                m_NetworkStream = m_TcpClient.GetStream();
                m_UdpClient = new UdpClient();
                m_UdpClient.Connect(ipAdress, port);
                m_Reader = new BinaryReader(m_NetworkStream, Encoding.UTF8);
                m_Writer = new BinaryWriter(m_NetworkStream, Encoding.UTF8);
                return true;
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return false;
            }
        }

        public void Run()
        {
            Console.WriteLine("Run called");
            Thread thread1 = new Thread(new ThreadStart(TCP_ProcessServerResponse));
            thread1.Start();
            
            Thread thread2 = new Thread(new ThreadStart(UDP_ProcessServerResponse));
            thread2.Start();

            Login();
            m_ClientForm.ShowDialog();         
        }

        public Packet TCP_Read()
        {
            int numberOfBytes = m_Reader.ReadInt32();
            if (numberOfBytes != -1)
            {
                byte[] buffer = (m_Reader.ReadBytes(numberOfBytes));
                MemoryStream memStream = new MemoryStream(buffer);
                return m_Formatter.Deserialize(memStream) as Packet; //deserialize data
            }
            else throw new ArgumentException("Something went wrong");
        }

        private void TCP_ProcessServerResponse()
        {
            Console.WriteLine("TCP Process Server Response called");           
            while (((recievedPacket = TCP_Read()) != null)) //blocking call unitl readline recieves data
            {
                switch (recievedPacket.m_PacketType)
                {
                    case PacketType.ChatMessage: // chat message
                        ChatMessagePacket chatPacket = (ChatMessagePacket)recievedPacket;
                        m_ClientForm.UpdateChatWindow(chatPacket.m_Message);
                        break;
                    case PacketType.ClientName: // Private message
                        break;
                    case PacketType.PrivateMessage: //client name
                        break;                      
                }
            }
        }

        public void Close() //TODO: make this be called at some point 
        {
            m_NetworkStream.Close();
            m_Reader.Close();
            m_Writer.Close();

            m_TcpClient.Close();
            m_UdpClient.Close();
        }

        public void Login()
        {
            //login

            Console.WriteLine("Login called");

            var loginPacket = new LoginPacket((IPEndPoint)m_UdpClient.Client.LocalEndPoint);

            TCP_SendMessage(loginPacket);

            Console.WriteLine("Login packet sent");

        }

        public void UDP_SendMessge(Packet packet)
        {
            // send message
            m_TCPMemoryStream = new MemoryStream();

            m_Formatter.Serialize(m_TCPMemoryStream, packet);
            byte[] buffer = m_TCPMemoryStream.GetBuffer();
            m_UdpClient.Send(buffer, buffer.Length);
            
            
            m_Writer.Flush(); //needed?

            Console.WriteLine("UDP message sent");

        }

        private void UDP_ProcessServerResponse()
        {
            //process server response
            try
            {
                var endPoint = new IPEndPoint(IPAddress.Any, 0);

                while (true)
                {       
                        byte[] bytes = m_UdpClient.Receive(ref endPoint);

                        MemoryStream memStream = new MemoryStream(bytes);
                        recievedPacket = m_Formatter.Deserialize(memStream) as Packet; //deserialize data
                }

            }
            catch(SocketException e)
            {
                Console.WriteLine("Client UDP read method exception: " + e.Message);
            }

        }

    }
}
