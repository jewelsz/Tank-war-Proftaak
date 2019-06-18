using BattleTanks.Messages.Dtos;
using MessagePack;
using System;
using YamlDotNet.Serialization;

namespace BattleTanks.Messages.Responses
{
    public struct LoginResponse : IResponse
    {
        [YamlMember(Alias = "id")]
        public Guid Id { get; set; }
        [YamlMember(Alias = "requestId")]
        public Guid RequestId { get; set; }
        [YamlMember(Alias = "userDto")]
        public UserDto UserDto { get; set; }
        [YamlMember(Alias = "success")]
        public bool IsSuccess { get; set; }

        public LoginResponse(Guid id, Guid requestId, UserDto userDto, bool isSuccess)
        {
            Id = id;
            RequestId = requestId;
            UserDto = userDto;
            IsSuccess = isSuccess;
        }
    }
}
