﻿using System;
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

namespace Client
{
    public class Client
    {
        private TcpClient m_tcpClient;
        private NetworkStream m_NetworkStream;
        private BinaryWriter m_Writer;
        private BinaryReader m_Reader;
        private ClientForm m_ClientForm;
        private BinaryFormatter m_Formatter;
        private MemoryStream m_MemoryStream;
        private Packets.Packet recievedPacket;
        public Client()
        {
            //constructor
            m_ClientForm = new ClientForm(this);
            m_tcpClient = new TcpClient();
            m_Formatter = new BinaryFormatter();
            
        }

        public void SendMessage(Packets.Packet message)
        {
            m_MemoryStream = new MemoryStream();

            m_Formatter.Serialize(m_MemoryStream, message);
            byte[] buffer = m_MemoryStream.GetBuffer();
            m_Writer.Write(buffer.Length);
            m_Writer.Write(buffer);
            m_Writer.Flush();

            Console.WriteLine("message sent");
        }

        public bool Connect(string ipAdress, int port)
        {
            try
            {
                m_tcpClient.Connect(ipAdress, port); // connect to server
                m_NetworkStream = m_tcpClient.GetStream();
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
            Thread thread1 = new Thread(new ThreadStart(ProcessServerResponse));
            thread1.Start();
            m_ClientForm.ShowDialog();
        }

        public Packets.Packet Read()
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

        private void ProcessServerResponse()
        {
            Console.WriteLine("Process Server Response called");           
            while (((recievedPacket = Read()) != null)) //blocking call unitl readline recieves data
            {
                switch (recievedPacket.m_PacketType)
                {
                    case PacketType.ChatMessage: // chat message
                        Packets.ChatMessagePacket chatPacket = (ChatMessagePacket)recievedPacket;
                        m_ClientForm.UpdateChatWindow(chatPacket.m_Message);
                        break;
                    case Packets.PacketType.ClientName: // Private message
                        break;
                    case Packets.PacketType.PrivateMessage: //client name
                        break;                      
                }
            }
        }
    }
}