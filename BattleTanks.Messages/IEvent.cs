using System;

namespace BattleTanks.Messages
{
    public interface IEvent
    {
        Guid Id { get; }
        Guid RequestId { get; }
    }
}
