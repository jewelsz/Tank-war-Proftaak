using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BattleTanks.Networking.Interfaces;
using BattleTanks.Domain.Entities;
using BattleTanks.Messages;

namespace BattleTanks.Networking.NetworkAwareObjects
{
    public class NetworkAwareLobby
    {
        private readonly ConcurrentDictionary<int, INetworkConnector> _networkAwareUsers;
        private readonly CancellationTokenSource _cancellationTokenSource;
        private readonly List<User> _users;
        private const int Capacity = 4;
        public Game Game { get; }
        public IReadOnlyList<User> Users => _users;
        public string Name { get; private set;  }

        public NetworkAwareLobby(string lobbyName, User user, INetworkConnector networkConnector)
        {
            Name = lobbyName;
            _users = new List<User>(Capacity) { user };
            _networkAwareUsers = new ConcurrentDictionary<int, INetworkConnector>();
            _networkAwareUsers.TryAdd(user.Id, networkConnector);
            _cancellationTokenSource = new CancellationTokenSource();
            Game = new Game(new[]
            {
                new Tank(0, -1, -1 , -1, -1, -1),
                new Tank(1, -1, -1 , -1, -1, -1),
                new Tank(2, -1, -1 , -1, -1, -1),
                new Tank(3, -1, -1 , -1, -1, -1)
            });
            Console.WriteLine("I pretty much created this object");
        }

        public Task EmitEvent<TEvent>(TEvent @event, int excludeUserId) where TEvent : IEvent
        {
            return Task.Run(() =>
            {
                foreach (KeyValuePair<int, INetworkConnector> item in _networkAwareUsers)
                {
                    if (item.Key != excludeUserId)
                        _ = item.Value.SendMessageAsync(@event, _cancellationTokenSource.Token);
                }
            });
        }

        public bool AddUser(User user, INetworkConnector networkConnector)
        {
            if (_networkAwareUsers.Count == Capacity)
                return false;
            _networkAwareUsers.TryAdd(user.Id, networkConnector);
            _users.Add(user);
            // TODO: Broadcast?
            return true;
        }

        public bool TryRemoveUser(int userId)
        {
            KeyValuePair<int, INetworkConnector> userConnectorKeyValuePair = _networkAwareUsers.SingleOrDefault(val => val.Key == userId);
            if (userConnectorKeyValuePair.Equals(default))
                return false;
            User user = _users.SingleOrDefault(u => u.Id == userId);
            if (user.Equals(default))
                return false;
            if (_users.Remove(user) && _networkAwareUsers.TryRemove(userConnectorKeyValuePair.Key, out _))
            {
                // TODO: Broadcast?
                return true;
            }
            return false;
        }
    }
}
