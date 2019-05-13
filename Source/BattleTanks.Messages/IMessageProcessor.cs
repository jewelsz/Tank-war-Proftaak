using System;
using System.Threading.Tasks;
using BattleTanks.Utilities.Observer;

namespace BattleTanks.Messages
{
    public interface IMessageProcessor : IObservable
    {
        Task<IResponse> ProcessRequest(Type type, IRequest request);
        Task ProcessCommand(Type type, ICommand command);
        Task ProcessResponse(Type type, IResponse response);
    }
}
