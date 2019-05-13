using System;
using BattleTanks.Messages.Responses;
using MessagePack;

namespace BattleTanks.Messages
{
    [Union(0, typeof(LoginResponse))]
    public interface IResponse
    {
        Guid Id { get; }
        Guid RequestId { get; }
    }
}
