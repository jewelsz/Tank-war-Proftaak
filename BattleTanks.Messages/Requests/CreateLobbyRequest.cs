using System;
using BattleTanks.Networking.Interfaces;
using BattleTanks.Messages.Dtos;

namespace BattleTanks.Messages.Requests
{
    public struct CreateLobbyRequest : IRequest
    {
        private INetworkConnector _networkConnector;
        public Guid Id { get; set; }
        public UserDto User { get; set; }
        public string LobbyName { get; set; }

        public CreateLobbyRequest(Guid id, UserDto user, string lobbyName)
        {
            Id = id;
            User = user;
            LobbyName = lobbyName;
            _networkConnector = default;
        }

        public void SetNetworkConnector(INetworkConnector networkConnector)
        {
            _networkConnector = networkConnector;
        }

        public INetworkConnector GetNetworkConnector()
        {
            return _networkConnector;
        }
    }
}
