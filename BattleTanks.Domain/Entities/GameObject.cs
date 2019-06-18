using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTanks.Domain.Entities
{
    public class GameObject
    {
        public int PlayerId { get; }
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public int ZPosition { get; set; }
        public int XRotation { get; set; }
        public int ZRotation { get; set; }

        public GameObject(int playerId, int posX, int posY, int posZ, int rotX, int rotZ)
        {
            PlayerId = playerId;
            XPosition = posX;
            YPosition = posY;
            ZPosition = posZ;
            XRotation = rotX;
            ZRotation = rotZ;
        }
    }
}
