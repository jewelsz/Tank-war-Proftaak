using System.Collections.Generic;
using System.Linq;

namespace BattleTanks.Messages.Dtos
{
    public struct LobbyDto
    {
        public string Name { get; set; }
        public List<UserDto> Users { get; set; }

        public LobbyDto(string name, UserDto user)
        {
            Name = name;
            Users = new List<UserDto>(4) { user };
        }

        public LobbyDto(string name, List<UserDto> users)
        {
            Name = name;
            Users = new List<UserDto>(4);
            Users.AddRange(users);
        }

        public bool AddUser(UserDto user)
        {
            if (Users.Count == Users.Capacity)
                return false;
            Users.Add(user);
            return true;
        }

        public bool TryRemoveUser(int userId)
        {
            UserDto user = Users.SingleOrDefault(u => u.Id == userId);
            return !user.Equals(default) && Users.Remove(user);
        }
    }
}
