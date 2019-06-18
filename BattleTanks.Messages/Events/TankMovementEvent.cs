using BattleTanks.Domain.Entities;
using System;

namespace BattleTanks.Messages.Events
{
    public struct TankMovementEvent : IEvent
    {
        public Guid Id { get; set; }
        public Guid RequestId { get; set; }
        public Tank Tank { get; set; }
        public bool Success { get; set; }

        public TankMovementEvent(Guid id, Guid requestId, Tank tank, bool success)
        {
            Id = id;
            RequestId = requestId;
            Tank = tank;
            Success = success;
        }
    }
}
