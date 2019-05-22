using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace BattleTanks.Utilities.Concurrent
{
    public class AsyncConcurrentQueue<T>
    {
        private readonly BlockingCollection<T> _blockingCollection = new BlockingCollection<T>();

        public void Enqueue(T item)
        {
            _blockingCollection.Add(item);
        }

        public Task<T> DequeueAsync(CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                while (true)
                    if (_blockingCollection.TryTake(out var item, -1, cancellationToken))
                        return item;
            }, cancellationToken);
        }
    }
}
