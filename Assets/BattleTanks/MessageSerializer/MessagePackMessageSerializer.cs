using System;
using BattleTanks.Messages;
using MessagePack;

namespace BattleTanks.MessageSerializer
{
    public class MessagePackMessageSerializer : IMessageSerializer
    {
        public Memory<byte> Serialize(object message)
        {
            return new Memory<byte>(MessagePackSerializer.Serialize(message));
        }

        public T Deserialize<T>(Memory<byte> message)
        {
            return MessagePackSerializer.Deserialize<T>(message.ToArray());
        }

        public object Deserialize(Memory<byte> message, Type type)
        {
            return MessagePackSerializer.NonGeneric.Deserialize(type, message.ToArray());
        }
    }
}
