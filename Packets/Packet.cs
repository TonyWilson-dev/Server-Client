using System;
using System.Net;

namespace Packets
{
    public enum PacketType
    {
        ChatMessage = 0,
        PrivateMessage = 1,
        ClientName = 2,
        Login = 3
    }

    [Serializable]
    public class Packet
    {
        public PacketType m_PacketType;
        public PacketType M_PacketType
        {
            get
            {
                return m_PacketType;
            }
            set
            {
                m_PacketType = value;
            }
        }   
    }

    [Serializable]
    public class ChatMessagePacket: Packet
    {
        public string m_Message;
        public ChatMessagePacket(string message)
        {
            this.m_PacketType = (PacketType)0;
            m_Message = message;
           
        }
    }

    [Serializable]

    public class LoginPacket: Packet
    {
        public IPEndPoint m_EndPoint;


        public LoginPacket (IPEndPoint endPoint)
        {
            this.m_PacketType = (PacketType)3;
            m_EndPoint = endPoint;
        }
    }
}
