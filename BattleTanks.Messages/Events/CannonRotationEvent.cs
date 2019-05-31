using BattleTanks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTanks.Messages.Events
{
    public struct CannonRotationEvent : IEvent
    {
        public Guid Id { get; set; }
        public Guid RequestId { get; set; }
        public CannonRotation Rotation { get; set; }
        public bool Success { get; set; }

        public CannonRotationEvent(Guid id, Guid requestId, CannonRotation rotation, bool success)
        {
            Id = id;
            RequestId = requestId;
            Rotation = rotation;
            Success = success;
        }
    }
}
