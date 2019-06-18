using System.Collections.Generic;

namespace BattleTanks.Messages.Dtos
{
    public struct GameInfoDto
    {
        public int GameId { get; set; }
        public IEnumerable<int> UserIds { get; set; }

        public GameInfoDto(int gameId, IEnumerable<int> userIds)
        {
            GameId = gameId;
            UserIds = userIds;
        }
    }
}
