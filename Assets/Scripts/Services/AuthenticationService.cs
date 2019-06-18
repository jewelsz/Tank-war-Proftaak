﻿using BattleTanks.Messages;
using BattleTanks.Messages.Requests;
using BattleTanks.Messages.Responses;
using BattleTanks.Networking.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

public class AuthenticationService
{
    private IMessageProcessor _messageProcessor;
    private INetworkConnector _networkConnector;

    public AuthenticationService(INetworkConnector networkConnector, IMessageProcessor messageProcessor)
    {
        _messageProcessor = messageProcessor;
        _networkConnector = networkConnector;
    }

    public async Task<LoginResponse> LoginAsync(string username, string password)
    {
        MessageListener<LoginResponse> loginResponseListener = new MessageListener<LoginResponse>();
        loginResponseListener.Subscribe(_messageProcessor);
        LoginRequest loginRequest = new LoginRequest(Guid.NewGuid(), username, password);
        await _networkConnector.SendMessageAsync(loginRequest, CancellationToken.None);
        LoginResponse loginResponse = await loginResponseListener.ReceiveMessageAsync();
        loginResponseListener.Unsubscribe();
        return loginResponse;
    }
}
