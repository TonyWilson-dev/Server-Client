using System;
using System.Net;
using System.Security.Cryptography;

namespace Packets
{
    public enum PacketType
    {
        ChatMessage = 0,
        PrivateMessage = 1,
        ClientName = 2,
        Login = 3,
        Encrypt = 4,
        SetNickName = 5,
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
    [Serializable]
    public class EncryptPacket : Packet
    {
        public RSAParameters m_PublicKey;

        public EncryptPacket(RSAParameters PublicKey)
        {
            this.m_PacketType = (PacketType)4;
            m_PublicKey = PublicKey;
        }
    }

    [Serializable]
    public class SetNickName : Packet
    {
        public string m_NickName;

        public SetNickName(string Nickname)
        {
            this.m_PacketType = (PacketType)5;
            m_NickName = Nickname;
        }
    }

    [Serializable]
    public class PrivateMessage : Packet
    {
        public string m_Destination;
        public string m_Message;
        public string m_Sender;
        public PrivateMessage(string message, string desitnation, string sender)
        {
            m_Message = message;
            m_Destination = desitnation;
            m_Sender = sender;
            this.m_PacketType = (PacketType)1;           
        }
    }


}
