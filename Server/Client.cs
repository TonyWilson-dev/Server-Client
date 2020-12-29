using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using Packets;


namespace Server
{
    class Client
    {
        private Socket m_Socket;
        private NetworkStream m_NetworkStream;
        private BinaryWriter m_Writer;
        private BinaryReader m_Reader;
        private object m_ReadLock;
        private object m_WriteLock;
        private BinaryFormatter m_Formatter;
        public IPEndPoint m_IPEndPoint;

        //encryption members
        private RSACryptoServiceProvider m_RSAProvider;
        private RSAParameters m_PublicKey;
        private RSAParameters m_PrivateKey;
        private RSAParameters m_ClientKey;
        public RSAParameters M_ClientKey { get; set; }
        public Client (Socket socket)
        {
            // constructor
            m_WriteLock = new object();
            m_ReadLock = new object();
            m_Socket = socket;
            m_Formatter = new BinaryFormatter();
            m_NetworkStream = new NetworkStream(socket, true);
            m_Reader = new BinaryReader(m_NetworkStream, Encoding.UTF8);
            m_Writer = new BinaryWriter(m_NetworkStream, Encoding.UTF8);

            //encryption
            m_RSAProvider = new RSACryptoServiceProvider(1024);
            m_PublicKey = m_RSAProvider.ExportParameters(false);
            m_PrivateKey = m_RSAProvider.ExportParameters(true);

            EncryptPacket encryptPacket = new EncryptPacket(m_PublicKey);

            Console.WriteLine("Encrypt packet sent");

            EncryptPacket sendPacket = (EncryptPacket)encryptPacket; // cast packet as encrypt packet

            Send(sendPacket);

        }

        public void Close()
        {
            m_Socket.Close();
            m_NetworkStream.Close();
            m_Reader.Close();
            m_Writer.Close();
        }

        public Packet Read()
        {
          
            lock(m_ReadLock) //lock that allows only one thread to access   
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
        }

        public void Send(Packet message)
        {
            MemoryStream memStream = new MemoryStream(); //used to store binary data
         
            lock (m_WriteLock) 
            {
                m_Formatter.Serialize(memStream, message);
                byte[] buffer = memStream.GetBuffer();
                m_Writer.Write(buffer.Length);
                m_Writer.Write(buffer);
                m_Writer.Flush();
            }
        }
        public byte[] Encrypt(byte[] data)
        {
            lock (m_RSAProvider)
            {
                m_RSAProvider.ImportParameters(m_ClientKey);
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
