using System;
using BattleTanks.Messages.Dtos;

namespace BattleTanks.Messages.Responses
{
    public struct CreateLobbyResponse : IResponse
    {
        public Guid Id { get; set; }
        public Guid RequestId { get; set; }
        public LobbyDto LobbyDto { get; set; }
        public bool IsSuccess { get; set; }

        public CreateLobbyResponse(Guid id, Guid requestId, LobbyDto lobbyDto, bool isSuccess)
        {
            Id = id;
            RequestId = requestId;
            IsSuccess = isSuccess;
            LobbyDto = lobbyDto;
        }
    }
}
