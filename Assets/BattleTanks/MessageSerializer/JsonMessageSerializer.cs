using System;
using System.Text;
using BattleTanks.Messages;
using Newtonsoft.Json;

namespace BattleTanks.MessageSerializer
{
    public class JsonMessageSerializer : IMessageSerializer
    {
        public Memory<byte> Serialize(object message)
        {
            return new Memory<byte>(Encoding.Default.GetBytes(JsonConvert.SerializeObject(message)));
        }

        public T Deserialize<T>(Memory<byte> message)
        {
            return JsonConvert.DeserializeObject<T>(Encoding.Default.GetString(message.ToArray()));
        }

        public object Deserialize(Memory<byte> message, Type type)
        {
            return JsonConvert.DeserializeObject(Encoding.Default.GetString(message.ToArray()), type);
        }
    }
}
