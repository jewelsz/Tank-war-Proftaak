using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using BattleTanks.Messages;

namespace BattleTanks.Networking
{
    public class TcpNetworkConnector : BaseNetworkConnector, IDisposable
    {
        private readonly TcpClient _tcpClient;
        public string Host { get; }
        public int Port { get; }
        public override bool IsConnected => _tcpClient.Connected;

        public TcpNetworkConnector(IMessageSerializer messageSerializer, IMessageProcessor messageProcessor, string host, int port) : base(messageSerializer, messageProcessor)
        {
            Host = host;
            Port = port;
            _tcpClient = new TcpClient();
        }
        public TcpNetworkConnector(IMessageSerializer messageSerializer, IMessageProcessor messageProcessor, TcpClient tcpClient) : base(messageSerializer, messageProcessor)
        {
            _tcpClient = tcpClient;
            IPEndPoint endPoint = (IPEndPoint) tcpClient.Client.RemoteEndPoint;
            IPHostEntry hostEntry = Dns.GetHostEntry(endPoint.Address);
            Host = hostEntry.HostName;
            Port = endPoint.Port;
        }

        public override ValueTask ConnectAsync(CancellationToken cancellationToken)
        {
            if (IsConnected)
                throw new Exception("Connector is already connected");
            return new ValueTask(Task.Run(async () => await _tcpClient.ConnectAsync(Host, Port), cancellationToken));
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

        public void Dispose()
        {
            _tcpClient?.Dispose();
        }
    }
}
