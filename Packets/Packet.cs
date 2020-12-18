using System;

namespace Packets
{
    public enum PacketType
    {
        ChatMessage = 0,
        PrivateMessage = 1,
        ClientName = 2
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
            m_Message = message;
           
        }
    }
}
