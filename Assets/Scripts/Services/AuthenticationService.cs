using BattleTanks.Messages;
using BattleTanks.Messages.Requests;
using BattleTanks.Messages.Responses;
using BattleTanks.Networking.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

public class AuthenticationService
{
    private IMessageProcessor _messageProcessor;
    private Action<string> _log;
    private INetworkConnector _networkConnector;

    public AuthenticationService(INetworkConnector networkConnector, IMessageProcessor messageProcessor, Action<string> log)
    {
        _messageProcessor = messageProcessor;
        _log = log;
        _networkConnector = networkConnector;
    }

    public async Task<LoginResponse> LoginAsync(string username, string password)
    {
        MessageListener<LoginResponse> loginResponseListener = new MessageListener<LoginResponse>();
        loginResponseListener.Subscribe(_messageProcessor);
        LoginRequest loginRequest = new LoginRequest(Guid.NewGuid(), username, password);
        await _networkConnector.SendMessageAsync(loginRequest, CancellationToken.None);
        LoginResponse loginResponse = await loginResponseListener.ReceiveMessageAsync();
        _log.Invoke($"Success: {loginResponse.IsSuccess}, Username: {loginResponse.UserDto.Name}, RequestId: {loginResponse.RequestId}, ResponseId: {loginResponse.Id}");
        loginResponseListener.Unsubscribe();
        return loginResponse;
    }
}
