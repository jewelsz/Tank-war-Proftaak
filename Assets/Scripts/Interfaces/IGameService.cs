using Assets.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interfaces
{
    interface IGameService
    {
        bool startGame(string lobbyID, string userID);
        void tank_Movement(int posX, int posY, int posZ, int rotX, int rotY, int rotZ, string playerID, string gameID);
        void canon_Rotation(int rotX, int rotZ, string playerID, string gameID);
        void shoot(int posX, int posY, int posZ, int rotX, int rotZ, ShotType shotType, string gameID);
        void leaveGame(string lobbyID, string userID);

        void subscribe(/*listener*/);
    }
}
