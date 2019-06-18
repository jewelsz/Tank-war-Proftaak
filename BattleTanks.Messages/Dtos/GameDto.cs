namespace BattleTanks.Messages.Dtos
{
    public struct GameDto
    {
        public int Id { get; set; }
        public int LobbyId { get; set; }

        public GameDto(int id, int lobbyId)
        {
            Id = id;
            LobbyId = lobbyId;
        }
    }
}
