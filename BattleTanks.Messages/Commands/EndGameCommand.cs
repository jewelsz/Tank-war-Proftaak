using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTanks.Messages.Commands
{
    public struct EndGameCommand : ICommand
    {
        public Guid Id { get; set; }
        public string LobbyName { get; set; }
        public int WinnerPlayerId { get; set; }
        public int UserId { get; set; }

        public EndGameCommand(Guid id, string lobbyName, int winnerPlayerId, int userId)
        {
            Id = id;
            LobbyName = lobbyName;
            WinnerPlayerId = winnerPlayerId;
            UserId = userId;
        }
    }
}
