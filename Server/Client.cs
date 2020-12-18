using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


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

        }

        public void Close()
        {
            m_Socket.Close();
            m_NetworkStream.Close();
            m_Reader.Close();
            m_Writer.Close();
        }

        public Packets.Packet Read()
        {
          
            lock(m_ReadLock) //lock that allows only one thread to access   
            {
                int numberOfBytes = m_Reader.ReadInt32();
                if (numberOfBytes != -1)
                {
                    byte[] buffer = (m_Reader.ReadBytes(numberOfBytes));
                    MemoryStream memStream = new MemoryStream(buffer);
                    return m_Formatter.Deserialize(memStream) as Packets.Packet; //deserialize data                    
                }
                else throw new ArgumentException("Something went wrong");
            }         
        }

        public void Send(Packets.Packet message)
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
    }
}
