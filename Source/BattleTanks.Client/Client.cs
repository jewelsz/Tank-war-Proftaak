using BattleTanks.Messages;
using BattleTanks.Messages.Requests;
using BattleTanks.Messages.Responses;
using BattleTanks.MessageSerializer;
using BattleTanks.Networking;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BattleTanks.Client
{
    public class Client
    {
        private const int Port = 9999;
        private const string Host = "localhost";
        private const int MessageCount = 100_000;
        private const int ClientCount = 10;
        private const int TotalMessages = MessageCount * ClientCount;

        public async Task RunAsync()
        {
            IMessageProcessor messageProcessor = new ClientMessageProcessor();
            IMessageSerializer messageSerializer = new MessagePackMessageSerializer();
            INetworkConnector networkConnector = new TcpNetworkConnector(messageSerializer, messageProcessor, Host, Port);
            await networkConnector.ConnectAsync(CancellationToken.None);
            networkConnector.Start();

            MessageListener<LoginResponse> loginResponseListener = new MessageListener<LoginResponse>();
            loginResponseListener.Subscribe(messageProcessor);
            for (int i = 0; i < MessageCount; i++)
            {
                LoginRequest loginRequest = new LoginRequest(Guid.NewGuid(), "Mario", "password");
                await networkConnector.SendMessageAsync(loginRequest, CancellationToken.None);
                LoginResponse loginResponse = await loginResponseListener.ReceiveMessageAsync();
                //Console.WriteLine($"Success: {loginResponse.IsSuccess}, Username: {loginResponse.UserDto.Name}, RequestId: {loginResponse.RequestId}, ResponseId: {loginResponse.Id}");
            }
            loginResponseListener.Unsubscribe();
        }
    }
}
