using System.Collections.Generic;
using System.Linq;

namespace BattleTanks.Domain.Entities
{
    public struct Lobby
    {
        public string Name { get; }
        public Game Game { get; }
        private readonly List<User> _users;
        public IReadOnlyList<User> Users => _users;

        public Lobby(string lobbyName, User user)
        {
            Name = lobbyName;
            Game = new Game(new[]
            {
                new Tank(0, -1, -1 , -1, -1, -1),
                new Tank(1, -1, -1 , -1, -1, -1),
                new Tank(2, -1, -1 , -1, -1, -1),
                new Tank(3, -1, -1 , -1, -1, -1)
            });
            _users = new List<User>(4) { user };
        }

        public bool AddUser(User user)
        {
            if (_users.Count == _users.Capacity)
                return false;
            _users.Add(user);
            return true;
        }

        public bool TryRemoveUser(int userId)
        {
            User user = _users.SingleOrDefault(u => u.Id == userId);
            return !user.Equals(default) && _users.Remove(user);
        }
    }
}
