using System;

namespace BattleTanks.Messages.Commands
{
    public struct SendMessageCommand : ICommand
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public string LobbyName { get; set; }
        public string Message { get; set; }

        public SendMessageCommand(Guid id, string lobbyName, int userId, string message)
        {
            Id = id;
            UserId = userId;
            LobbyName = lobbyName;
            Message = message;
        }
    }
}
