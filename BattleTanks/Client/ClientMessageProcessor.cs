using BattleTanks.Messages;
using BattleTanks.Utilities.Observer;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BattleTanks.Client
{
    internal class ClientMessageProcessor : IMessageProcessor
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

        public Task<IResponse> ProcessRequest(Type type, IRequest message)
        {
            return Task.Run(() =>
            {
                Console.WriteLine("Received IRequest message");
                // ...
                IResponse response = null;
                return Task.FromResult(response);
            });
        }

        public Task ProcessCommand(Type type, ICommand command)
        {
            return Task.Run(() =>
            {
                Console.WriteLine("Received ICommand message");
                // ...
            });
        }

        public Task ProcessResponse(Type type, IResponse response)
        {
            return Task.Run(() =>
            {
                //Console.WriteLine("Received IResponse message");
                if (_observers.ContainsKey(response.GetType()))
                    _observers[response.GetType()].OnNextAll(response); // , type
                else
                    throw new Exception($"Message of type: {type.FullName} not found in listeners.");
            });
        }
    }
}
