using System.Collections.Generic;

namespace BattleTanks.Domain.Entities
{
    public struct GameInfo
    {
        public IEnumerable<int> UserIds { get; }

        public GameInfo(IEnumerable<int> userIds)
        {
            UserIds = userIds;
        }
    }
}
