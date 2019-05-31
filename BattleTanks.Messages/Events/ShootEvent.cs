using BattleTanks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTanks.Messages.Events
{
    public struct ShootEvent : IEvent
    {
        public Guid Id { get; set; }
        public Guid RequestId { get; set; }
        public Projectile Projectile { get; set; }
        public bool Success { get; set; }

        public ShootEvent(Guid id, Guid requestId, Projectile projectile, bool success)
        {
            Id = id;
            RequestId = requestId;
            Projectile = projectile;
            Success = success;
        }
    }
}
