using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTanks.Messages.Events
{
    public struct EndGameEvent : IEvent
    {
        public Guid Id { get; set; }
        public Guid RequestId { get; set; }
        public int WinnerPlayerId { get; set; }
        public bool Success { get; set; }

        public EndGameEvent(Guid id, Guid requestId, int winnerPlayerId, bool success)
        {
            Id = id;
            RequestId = requestId;
            WinnerPlayerId = winnerPlayerId;
            Success = success;
        }
    }
}
