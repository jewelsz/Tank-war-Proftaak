using BattleTanks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTanks.Messages.Events
{
    public struct SendMessageEvent : IEvent
    {
        public Guid Id { get; set; }
        public Guid RequestId { get; set; }
        public UserMessage Message { get; set; }
        public bool Success { get; set; }

        public SendMessageEvent(Guid id, Guid requestId, UserMessage message, bool success)
        {
            Id = id;
            RequestId = requestId;
            Message = message;
            Success = success;
        }
    }
}
