using BattleTanks.Utilities.Concurrent;
using BattleTanks.Utilities.Observer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BattleTanks.Client
{
    public class MessageListener<T> : IObserver, IDisposable
    {
        private readonly AsyncConcurrentQueue<object> _messageQueue = new AsyncConcurrentQueue<object>();
        private IDisposable _unsubscriber;

        public virtual void Subscribe(IObservable provider)
        {
            _unsubscriber = provider.Subscribe(typeof(T), this);
        }

        public virtual void Unsubscribe()
        {
            Dispose();
        }

        public virtual void OnError()
        {
            Console.WriteLine($"{GetType().FullName} OnError.");
        }

        public virtual void OnNext(object value) // , Type type
        {
            _messageQueue.Enqueue(value);
        }

        public virtual async Task<T> ReceiveMessageAsync()
        {
            return (T)await _messageQueue.DequeueAsync(CancellationToken.None);
        }

        public void Dispose()
        {
            _unsubscriber?.Dispose();
        }
    }
}
