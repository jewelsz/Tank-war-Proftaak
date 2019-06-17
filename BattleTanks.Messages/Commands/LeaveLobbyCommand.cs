using System;

namespace BattleTanks.Messages.Commands
{
    public struct LeaveLobbyCommand : ICommand
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public string LobbyName { get; set; }

        public LeaveLobbyCommand(Guid id, string lobbyName, int userId)
        {
            Id = id;
            UserId = userId;
            LobbyName = lobbyName;
        }
    }
}
