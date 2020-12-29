using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using Packets;

namespace Client
{
    public class TCP_Client
    {
        private TcpClient m_TcpClient;
        private NetworkStream m_NetworkStream;
        public BinaryWriter m_Writer;
        private BinaryReader m_Reader;
        private ClientForm m_ClientForm;
        private BinaryFormatter m_Formatter;
        private MemoryStream m_MemoryStream;
        private Packet recievedPacket;
        private UdpClient m_UdpClient;

        //encryption members
        private RSACryptoServiceProvider m_RSAProvider;
        private RSAParameters m_PublicKey;
        private RSAParameters m_PrivateKey;
        private RSAParameters m_ServerKey;
        public RSAParameters M_ServerKey { get; set; }

        //peaches big adventure
        public int m_x;
        public int m_y;

        public TCP_Client()
        {
            //constructor
            m_ClientForm = new ClientForm(this);
            m_TcpClient = new TcpClient();           
            m_Formatter = new BinaryFormatter();
            
            //ENCRYPTION
            m_RSAProvider = new RSACryptoServiceProvider(1024);
            m_PublicKey = m_RSAProvider.ExportParameters(false);
            m_PrivateKey = m_RSAProvider.ExportParameters(true);
        }

        public void TCP_SendMessage(Packet packet)
        {
            m_MemoryStream = new MemoryStream();
            m_Formatter.Serialize(m_MemoryStream, packet);
            byte[] buffer = m_MemoryStream.GetBuffer();
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

                EncryptPacket encryptPacket = new EncryptPacket(m_PublicKey);
                EncryptPacket sendPacket = (EncryptPacket)encryptPacket; // cast packet as chat packet
                TCP_SendMessage(sendPacket);

                Console.WriteLine("Encrypt packet sent");

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

                    case PacketType.Encrypt: //encrypt packet
                        EncryptPacket encryptPacket = (EncryptPacket)recievedPacket; //cast packet as encrypt packet
                        M_ServerKey = encryptPacket.m_PublicKey;
                        Console.WriteLine("client key recieved: " + M_ServerKey);
                        break;

                    case PacketType.localGameUpdate:
                        LocalGameUpdate localGameUpdate = (LocalGameUpdate)recievedPacket;
                        m_x = localGameUpdate.m_x;
                        m_y = localGameUpdate.m_y;
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
            m_MemoryStream = new MemoryStream();
            m_Formatter.Serialize(m_MemoryStream, packet);
            byte[] buffer = m_MemoryStream.GetBuffer();
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

        public byte[] Encrypt(byte[] data)
        {
            lock (m_RSAProvider)
            {
                m_RSAProvider.ImportParameters(m_ServerKey);
                return m_RSAProvider.Encrypt(data, true);
            }
            
        }
        public byte[] Decrypt(byte[] data)
        {
            lock (m_RSAProvider)
            {
                m_RSAProvider.ImportParameters(m_PrivateKey);
                return m_RSAProvider.Decrypt(data, true);
            }
        }
        public byte [] EncryptString(string message)
        {
            return Encrypt( Encoding.UTF8.GetBytes(message) ); //convert strting to bytes, pass to encrypt, return byte array
        }

        public string DecryptString(byte[] data)
        {
            return Encoding.UTF8.GetString(Decrypt(data)); //decrypt data, convert to string and return
        }
    }
}
