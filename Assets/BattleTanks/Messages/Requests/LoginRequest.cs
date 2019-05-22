using System;
using MessagePack;

namespace BattleTanks.Messages.Requests
{
    [MessagePackObject]
    public readonly struct LoginRequest : IRequest
    {
        [Key(0)]
        public Guid Id { get; }
        [Key(1)]
        public string Username { get; }
        [Key(2)]
        public string Password { get; }

        public LoginRequest(Guid id, string username, string password)
        {
            Id = id;
            Username = username;
            Password = password;
        }
    }
}
