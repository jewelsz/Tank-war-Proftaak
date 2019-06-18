namespace BattleTanks.Domain.Entities
{
    public struct SpawnPoint
    {
        public int SpawnIndex { get; }

        public SpawnPoint(int spawnIndex)
        {
            SpawnIndex = spawnIndex;
        }
    }
}
