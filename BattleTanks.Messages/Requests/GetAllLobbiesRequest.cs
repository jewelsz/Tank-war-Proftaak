using System;

namespace BattleTanks.Messages.Requests
{
    public struct GetAllLobbiesRequest : IRequest
    {
        public Guid Id { get; set; }

        public GetAllLobbiesRequest(Guid id)
        {
            Id = id;
        }
    }
}