using System;

namespace BattleTanks.Messages
{
    public interface IMessageSerializer
    {
        Memory<byte> Serialize(object message);
        T Deserialize<T>(Memory<byte> message);
        object Deserialize(Memory<byte> message, Type type);
    }
}
