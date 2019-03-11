using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interfaces
{
    interface ILobbyService
    {
        Lobby CreateLobby(string userID, string lobbyName);
        Lobby JoinLobby(string userID);
        void LeaveLobby(string userID, string lobbyID);
        List<Lobby> GetAllLobbies();
    }
}
