using System;
using System.Threading.Tasks;
using BattleTanks.Networking.Interfaces;
using BattleTanks.Utilities.Observer;

namespace BattleTanks.Messages
{
    public interface IMessageProcessor : IObservable
    {
        Task<IResponse> ProcessRequest(Type type, IRequest request, INetworkConnector networkConnector);
        Task ProcessCommand(Type type, ICommand command, INetworkConnector networkConnector);
        Task ProcessResponse(Type type, IResponse response, INetworkConnector networkConnector);
        Task ProcessEvent(Type type, IEvent eventImplementer, INetworkConnector baseNetworkConnector);
    }
}
