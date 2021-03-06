﻿using System;
using System.Linq;
using System.Text;

namespace BattleTanks.Messages
{
    internal class MessageConstructor
    {
        private readonly IMessageSerializer _messageSerializer;

        internal MessageConstructor(IMessageSerializer messageSerializer)
        {
            _messageSerializer = messageSerializer ?? throw new ArgumentNullException(nameof(messageSerializer));
        }

        internal Message ConstructMessage(object messageBody)
        {
            ReadOnlyMemory<byte> body = _messageSerializer.Serialize(messageBody);
            byte[] bodySizeBytes = BitConverter.GetBytes(body.Length);
            byte[] typeNameBytes = Encoding.Default.GetBytes(messageBody.GetType().FullName ?? throw new InvalidOperationException("The FullName of the type cannot be null"));
            byte[] headerSizeBytes = BitConverter.GetBytes(4 + bodySizeBytes.Length + typeNameBytes.Length);
            ReadOnlyMemory<byte> header = headerSizeBytes.Concat(bodySizeBytes).Concat(typeNameBytes).ToArray();
            return new Message(header, body);
        }

        internal object DeconstructMessageBody(Memory<byte> messageBody, Type type)
        {
            return _messageSerializer.Deserialize(messageBody, type);
        }
    }
}
