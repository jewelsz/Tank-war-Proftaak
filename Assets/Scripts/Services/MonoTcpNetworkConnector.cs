using BattleTanks.Networking;
using BattleTanks.Networking.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Services
{
    public class MonoTcpNetworkConnector : MonoBehaviour, INetworkConnector
    {
        private TcpNetworkConnector tcpNetworkConnector;

        public void Awake()
        {
            Debug.Log("MonoTcp");
            this.tcpNetworkConnector = PersistentClass.GetInstance().TcpNetworkConnector;
        }

        public bool IsConnected => ((INetworkConnector)tcpNetworkConnector).IsConnected;

        public bool IsRunning => tcpNetworkConnector.IsRunning;

        public ValueTask ConnectAsync(CancellationToken cancellationToken)
        {
            return ((INetworkConnector)tcpNetworkConnector).ConnectAsync(cancellationToken);
        }

        public Task SendMessageAsync<TMessage>(TMessage message, CancellationToken cancellationToken)
        {
            return ((INetworkConnector)tcpNetworkConnector).SendMessageAsync(message, cancellationToken);
        }

        void INetworkConnector.Start()
        {
            tcpNetworkConnector.Start();
        }

        void INetworkConnector.Stop()
        {
            tcpNetworkConnector.Stop();
        }
    }
}
