using BattleTanks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTanks.Messages.Commands
{
    public struct CannonRotationCommand : ICommand
    {
        public Guid Id { get; set; }
        public string LobbyName { get; set; }
        public CannonRotation Rotation { get; set; }
        public int UserId { get; set; }

        public CannonRotationCommand(Guid id, string lobbyName, CannonRotation rotation, int userId)
        {
            Id = id;
            LobbyName = lobbyName;
            Rotation = rotation;
            UserId = userId;
        }
    }
}
