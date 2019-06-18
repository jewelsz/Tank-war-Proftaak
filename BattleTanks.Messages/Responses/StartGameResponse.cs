using System;
using System.Collections.Generic;

namespace BattleTanks.Messages.Responses
{
    public struct StartGameResponse : IResponse
    {
        public Guid Id { get; set; }
        public Guid RequestId { get; set; }
        public IEnumerable<int> UserIds { get; set; }
        public bool Success { get; set; }

        public StartGameResponse(Guid id, Guid requestId, IEnumerable<int> userIds, bool success)
        {
            Id = id;
            RequestId = requestId;
            UserIds = userIds;
            Success = success;
        }
    }
}
