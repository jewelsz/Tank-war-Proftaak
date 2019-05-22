using System;
using BattleTanks.Messages.Responses;
using MessagePack;

namespace BattleTanks.Messages
{
    //[Union(0, typeof())]
    public interface ICommand
    {
        Guid Id { get; }
    }
}
