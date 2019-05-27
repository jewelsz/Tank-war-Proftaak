using System;
using System.Collections;
using System.Collections.Generic;
using TankWar.Messages.Dtos;
using UnityEngine;

namespace BattleTanks.Messages.Responses
{
    [Serializable]
    public class LoginResponse
    {
        public Guid Id { get; set; }
        public Guid RequestId { get; set; }
        public bool IsSuccess { get; set; }
        public UserDto UserDto { get; set; }
        public LoginResponse(Guid id, Guid requestId, UserDto userDto, bool isSuccess)
        {
            Id = id;
            RequestId = requestId;
            UserDto = userDto;
            IsSuccess = isSuccess;
        }
    }

}
