using BattleTanks.Domain.Entities;
using System;

namespace BattleTanks.Messages.Commands
{
    public struct TankMovementCommand : ICommand
    {
        public Guid Id { get; set; }
        public string LobbyName { get; set; }
        public Tank Tank { get; set; }
        public int UserId { get; set; }

        public TankMovementCommand(Guid id, string lobbyName, Tank tank, int userId)
        {
            Id = id;
            LobbyName = lobbyName;
            Tank = tank;
            UserId = userId;
        }
    }
}
