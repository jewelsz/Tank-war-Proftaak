using BattleTanks.Messages.Dtos;
using MessagePack;
using System;

namespace BattleTanks.Messages.Responses
{
    [MessagePackObject]
    public readonly struct LoginResponse : IResponse
    {
        [Key(0)]
        public Guid Id { get; }
        [Key(1)]
        public Guid RequestId { get; }
        [Key(2)]
        public UserDto UserDto { get; }
        [Key(3)]
        public bool IsSuccess { get; }

        public LoginResponse(Guid id, Guid requestId, UserDto userDto, bool isSuccess)
        {
            Id = id;
            RequestId = requestId;
            UserDto = userDto;
            IsSuccess = isSuccess;
        }
    }
}
