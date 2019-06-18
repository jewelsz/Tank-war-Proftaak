using System;

namespace BattleTanks.Messages.Requests
{
    public struct StartGameRequest : IRequest
    {
        public Guid Id { get; set; }
        public string LobbyName { get; set; }
        public int UserId { get; set; }

        public StartGameRequest(Guid id, string lobbyName, int userId)
        {
            Id = id;
            LobbyName = lobbyName;
            UserId = userId;
        }
    }
}
