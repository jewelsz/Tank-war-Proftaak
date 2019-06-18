using System;
using BattleTanks.Messages.Responses;
using MessagePack;

namespace BattleTanks.Messages
{
    [Union(0, typeof(LoginResponse)), 
     Union(1, typeof(RegisterResponse)),
     Union(2, typeof(CreateLobbyResponse)),
     Union(3, typeof(JoinLobbyResponse)),
     Union(4, typeof(GetAllLobbiesResponse))
    ]
    public interface IResponse
    {
        Guid Id { get; }
        Guid RequestId { get; }
    }
}
