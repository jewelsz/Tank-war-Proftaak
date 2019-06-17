using System;
using System.Text;
using BattleTanks.Messages;
using YamlDotNet.Serialization;

namespace BattleTanks.MessageSerializer
{
    public class YamlMessageSerializer : IMessageSerializer
    {
        private readonly Serializer _yamlSerializer = new Serializer();
        private readonly Deserializer _yamlDeserializer = new Deserializer();

        public Memory<byte> Serialize(object message)
        {
            return new Memory<byte>(Encoding.Default.GetBytes(_yamlSerializer.Serialize(message)));
        }

        public T Deserialize<T>(Memory<byte> message)
        {
            return _yamlDeserializer.Deserialize<T>(Encoding.Default.GetString(message.ToArray()));
        }

        public object Deserialize(Memory<byte> message, Type type)
        {
            return _yamlDeserializer.Deserialize(Encoding.Default.GetString(message.ToArray()), type);
        }
    }
}
