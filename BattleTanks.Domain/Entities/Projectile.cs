using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTanks.Domain.Entities
{
    public class Projectile : GameObject
    {
        public Projectile(int playerId, int posX, int posY, int posZ, int rotX, int rotZ) : base(playerId, posX, posY, posZ, rotX, rotZ)
        {
        }
    }
}
