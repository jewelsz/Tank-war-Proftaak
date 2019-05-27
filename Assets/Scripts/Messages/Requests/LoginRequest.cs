using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BattleTanks.Messages.Requests
{
    [Serializable]
    public struct LoginRequest
    {
        public string Id;
        public string Username;
        public string Password;

        public LoginRequest(Guid id, string username, string password)
        {
            Id = id.ToString();
            Username = username;
            Password = password;
        }
    }

}
