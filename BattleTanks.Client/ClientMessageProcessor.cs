using BattleTanks.Messages;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using BattleTanks.Networking.Interfaces;
using BattleTanks.Utilities.Observer;

namespace BattleTanks.Client
{
    public class ClientMessageProcessor : IMessageProcessor
    {
        private readonly ConcurrentDictionary<Type, ObserverCollection> _observers; 

        public ClientMessageProcessor()
        {
            _observers = new ConcurrentDictionary<Type, ObserverCollection>();
        }

        public IDisposable Subscribe(Type type, IObserver observer)
        {
            if (!_observers.ContainsKey(type))
            {
                if (!_observers.TryAdd(type, new ObserverCollection(observer)))
                    throw new Exception("Failed to add observer");
            }
            else
                _observers[type].Add(observer);

            return new ObserverUnsubscriber(_observers[type], observer);
        }

        public Task<IResponse> ProcessRequest(Type type, IRequest message, INetworkConnector networkConnector)
        {
            return Task.Run(() =>
            {
                Console.WriteLine("Received IRequest message");
                // ...
                IResponse response = null;
                return Task.FromResult(response);
            });
        }

        public Task ProcessCommand(Type type, ICommand command, INetworkConnector networkConnector)
        {
            return Task.Run(() =>
            {
                Console.WriteLine("Received ICommand message");
                // ...
            });
        }

        public Task ProcessResponse(Type type, IResponse response, INetworkConnector networkConnector)
        {
            return Task.Run(() =>
            {
                Console.WriteLine("Received IResponse message");
                if (_observers.ContainsKey(response.GetType()))
                    _observers[response.GetType()].OnNextAll(response);
                else
                    throw new Exception($"Message Response of type: {type.FullName} not found in listeners.");
            });
        }

        public Task ProcessEvent(Type type, IEvent @event, INetworkConnector baseNetworkConnector)
        {
            return Task.Run(() =>
            {
                Console.WriteLine("Received IEvent message");
                if (_observers.ContainsKey(@event.GetType()))
                    _observers[@event.GetType()].OnNextAll(@event);
                else
                    throw new Exception($"Message Event of type: {type.FullName} not found in listeners.");
            });
        }
    }
}
