using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTanks.Messages.Commands
{
    public struct LeaveGameCommand : ICommand
    {
        public Guid Id { get; set; }
        public string LobbyName { get; set; }
        public int PlayerId { get; set; }
        public int UserId { get; set; }

        public LeaveGameCommand(Guid id, string lobbyName, int playerId, int userId)
        {
            Id = id;
            LobbyName = lobbyName;
            PlayerId = playerId;
            UserId = userId;
        }
    }
}
