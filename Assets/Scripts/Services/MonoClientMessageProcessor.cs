using BattleTanks.Client;
using BattleTanks.Messages;
using BattleTanks.Networking.Interfaces;
using BattleTanks.Utilities.Observer;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Services
{
    public class MonoClientMessageProcessor : MonoBehaviour, IMessageProcessor
    {
        private ClientMessageProcessor clientMessageProcessor;

        public void Awake()
        {
            Debug.Log("MonoClient");
            this.clientMessageProcessor = PersistentClass.GetInstance().clientMessageSingleton;
        }

        public Task ProcessCommand(Type type, ICommand command, INetworkConnector networkConnector)
        {
            return clientMessageProcessor.ProcessCommand(type, command, networkConnector);
        }

        public Task ProcessEvent(Type type, IEvent eventImplementer, INetworkConnector baseNetworkConnector)
        {
            return clientMessageProcessor.ProcessEvent(type, eventImplementer, baseNetworkConnector);
        }

        public Task<IResponse> ProcessRequest(Type type, IRequest request, INetworkConnector networkConnector)
        {
            return clientMessageProcessor.ProcessRequest(type, request, networkConnector);
        }

        public Task ProcessResponse(Type type, IResponse response, INetworkConnector networkConnector)
        {
            return clientMessageProcessor.ProcessResponse(type, response, networkConnector);
        }

        public IDisposable Subscribe(Type type, IObserver observer)
        {
            return clientMessageProcessor.Subscribe(type, observer);
        }
    }
}
