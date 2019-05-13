using System;
using BattleTanks.Messages.Requests;
using MessagePack;

namespace BattleTanks.Messages
{
    [Union(0, typeof(LoginRequest))]
    public interface IRequest
    {
        Guid Id { get; }
    }
}
