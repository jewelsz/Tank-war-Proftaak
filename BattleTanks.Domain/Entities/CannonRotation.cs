using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTanks.Domain.Entities
{
    public class CannonRotation
    {
        public int PlayerId { get; set; }
        public int XRotation { get; set; }
        public int YRotation { get; set; }

        public CannonRotation(int playerId, int rotX, int rotZ)
        {
            PlayerId = playerId;
            XRotation = rotX;
            YRotation = rotZ;
        }
    }
}
