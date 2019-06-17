using System;

namespace BattleTanks.Messages.Responses
{
    public struct RegisterResponse : IResponse
    {
        public Guid Id { get; set; }
        public Guid RequestId { get; set; }
        public bool IsSuccess { get; set; }

        public RegisterResponse(Guid id, Guid requestId, bool isSuccess)
        {
            Id = id;
            RequestId = requestId;
            IsSuccess = isSuccess;
        }
    }
}
