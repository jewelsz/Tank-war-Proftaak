using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTanks.Domain.Entities
{
    public class GameObject
    {
        public int PlayerId { get; }
        public float XPosition { get; set; }
        public float YPosition { get; set; }
        public float ZPosition { get; set; }
        public float XRotation { get; set; }
        public float ZRotation { get; set; }

        public GameObject(int playerId, float posX, float posY, float posZ, float rotX, float rotZ)
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
