using System;
using System.Collections.Generic;
using BattleTanks.Messages.Dtos;

namespace BattleTanks.Messages.Responses
{
    public struct GetAllLobbiesResponse : IResponse
    {
        public Guid Id { get; set; }
        public Guid RequestId { get; set; }
        public ICollection<LobbyDto> LobbyDtos { get; set; }
        public bool Success { get; set; }

        public GetAllLobbiesResponse(Guid id, Guid requestId, ICollection<LobbyDto> lobbyDtos, bool success)
        {
            Id = id;
            RequestId = requestId;
            LobbyDtos = lobbyDtos;
            Success = success;
        }
    }
}
