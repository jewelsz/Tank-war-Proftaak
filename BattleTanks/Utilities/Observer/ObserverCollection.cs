using System.Collections.Generic;

namespace BattleTanks.Utilities.Observer
{
    public sealed class ObserverCollection : List<IObserver>
    {
        public ObserverCollection(IObserver observer)
        {
            Add(observer);
        }

        public void OnNextAll(object obj) // , Type type
        {
            ForEach(observer => observer.OnNext(obj));// , type
        }

        public void OnErrorAll()
        {
            ForEach(observer => observer.OnError());
        }
    }
}
