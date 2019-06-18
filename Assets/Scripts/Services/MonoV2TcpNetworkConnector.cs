using BattleTanks.Messages;
using BattleTanks.Networking;
using BattleTanks.Networking.Interfaces;
using System;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Assets.Scripts.Services
{
    public class MonoV2TcpNetworkConnector : BaseNetworkConnector, INetworkConnector
    {
        private readonly TcpClient _tcpClient;
        private const string Host = "localhost";
        private const int Port = 9999;

        public MonoV2TcpNetworkConnector(IMessageSerializer messageSerializer, IMessageProcessor messageProcessor) : base(messageSerializer, messageProcessor)
        {
            _tcpClient = new TcpClient();
        }

        public override bool IsConnected => _tcpClient.Connected;

        public override ValueTask ConnectAsync(CancellationToken cancellationToken)
        {
            Connect();
            return default;
        }

        public void Connect()
        {
            _tcpClient.Connect(Host, Port);
        }
        protected override Task<int> ReceivePacketAsync(Memory<byte> memory, CancellationToken cancellationToken)
        {
            if (!MemoryMarshal.TryGetArray(memory, out ArraySegment<byte> segment))
                throw new ArgumentException("Cannot get ArraySegment<byte> from Memory<byte> memory");
            return _tcpClient.Client.ReceiveAsync(segment, SocketFlags.None);
        }
        protected override async Task SendPacketAsync(ReadOnlyMemory<byte> packet, CancellationToken cancellationToken)
        {
            if (!MemoryMarshal.TryGetArray(packet, out var segment))
                throw new ArgumentException("Cannot get ArraySegment<byte> from ReadOnlyMemory<byte> packet");
            await _tcpClient.Client.SendAsync(segment, SocketFlags.None);
        }
    }
}
