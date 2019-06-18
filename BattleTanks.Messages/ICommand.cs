using System;
using BattleTanks.Messages.Commands;
using MessagePack;

namespace BattleTanks.Messages
{
    [Union(0, typeof(LeaveLobbyCommand))]
    public interface ICommand
    {
        Guid Id { get; }
    }
}
