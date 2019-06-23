using BattleTanks.Messages.Dtos;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserLobbyObject : MonoBehaviour
{
    private static UserDto loggedInUser;
    private static LobbyDto joinedLobby;

    public void SetLoggedInUser(UserDto userDto)
    {
        loggedInUser = userDto;
    }
    public void SetJoinedLobby(LobbyDto lobbyDto)
    {
        joinedLobby = lobbyDto;
    }
    public UserDto GetLoggedInUser()
    {
        return loggedInUser;
    }
    public LobbyDto GetJoinedLobby()
    {
        return joinedLobby;
    }
}
