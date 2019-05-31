namespace BattleTanks.Domain.Entities
{
    public class Tank : GameObject
    {
        public Tank(int playerId, int posX, int posY, int posZ, int rotX, int rotZ) : base(playerId, posX, posY, posZ, rotX, rotZ)
        {
        }
    }
}
