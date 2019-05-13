namespace BattleTanks.Utilities.Observer
{
    public interface IObserver
    {
        void Subscribe(IObservable provider);
        void Unsubscribe();
        void OnError();
        void OnNext(object value); //, Type type
    }
}
