using System;
using BattleTanks.Messages.Requests;
using MessagePack;

namespace BattleTanks.Messages
{
    [Union(0, typeof(LoginRequest)), 
     Union(1, typeof(RegisterRequest)),
     Union(2, typeof(CreateLobbyRequest)),
     Union(3, typeof(JoinLobbyRequest)),
     Union(4, typeof(GetAllLobbiesRequest))
    ]
    public interface IRequest
    {
        Guid Id { get; }
    }
}
