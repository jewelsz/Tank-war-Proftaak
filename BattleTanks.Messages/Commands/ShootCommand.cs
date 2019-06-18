using BattleTanks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTanks.Messages.Commands
{
    public struct ShootCommand : ICommand
    {
        public Guid Id { get; set; }
        public string LobbyName { get; set; }
        public Projectile Projectile { get; set; }
        public int UserId { get; set; }

        public ShootCommand(Guid id, string lobbyName, Projectile projectile, int userId)
        {
            Id = id;
            LobbyName = lobbyName;
            Projectile = projectile;
            UserId = userId;
        }
    }
}
