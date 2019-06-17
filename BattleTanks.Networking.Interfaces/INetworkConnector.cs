using System.Threading;
using System.Threading.Tasks;

namespace BattleTanks.Networking.Interfaces
{
    public interface INetworkConnector
    {
        bool IsConnected { get; }
        bool IsRunning { get; }

        ValueTask ConnectAsync(CancellationToken cancellationToken);
        Task SendMessageAsync<TMessage>(TMessage message, CancellationToken cancellationToken);
        void Start();
        void Stop();
    }
}