using System;

namespace BattleTanks.Messages.Events
{
    public struct LeaveLobbyEvent : IEvent
    {
        public Guid Id { get; set; }
        public Guid RequestId { get; set; }
        public int PlayerId { get; set; }
        public bool Success { get; set; }

        public LeaveLobbyEvent(Guid id, Guid requestId, int playerId, bool success)
        {
            Id = id;
            RequestId = requestId;
            PlayerId = playerId;
            Success = success;
        }
    }
}
