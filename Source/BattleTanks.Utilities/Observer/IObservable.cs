using System;

namespace BattleTanks.Utilities.Observer
{
    public interface IObservable
    {
        IDisposable Subscribe(Type type, IObserver observer);
    }
}
