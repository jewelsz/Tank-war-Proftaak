using System;
using YamlDotNet.Serialization;

namespace BattleTanks.Messages.Requests
{
    public struct LoginRequest : IRequest
    {
        [YamlMember(Alias = "id")]
        public Guid Id { get; set; }
        [YamlMember(Alias = "username")]
        public string Username { get; set; }
        [YamlMember(Alias = "password")]
        public string Password { get; set; }

        public LoginRequest(Guid id, string username, string password)
        {
            Id = id;
            Username = username;
            Password = password;
        }
    }
}
