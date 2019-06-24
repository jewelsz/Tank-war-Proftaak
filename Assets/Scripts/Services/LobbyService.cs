using BattleTanks.Messages;
using BattleTanks.Messages.Dtos;
using BattleTanks.Messages.Requests;
using BattleTanks.Messages.Responses;
using BattleTanks.Networking.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class LobbyService
{
    private IMessageProcessor _messageProcessor;
    private INetworkConnector _networkConnector;
    private UserDto _loggedInUser;

    public LobbyService(INetworkConnector networkConnector, IMessageProcessor messageProcessor, UserDto loggedInUser)
    {
        _messageProcessor = messageProcessor;
        _networkConnector = networkConnector;
        _loggedInUser = loggedInUser;
    }

    public async Task<JoinLobbyResponse> JoinLobby(string lobbyName)
    {
        MessageListener<JoinLobbyResponse> joinLobbyResponseListener = new MessageListener<JoinLobbyResponse>();
        joinLobbyResponseListener.Subscribe(_messageProcessor);
        JoinLobbyRequest joinLobbyRequest = new JoinLobbyRequest(Guid.NewGuid(), _loggedInUser, lobbyName);
        await _networkConnector.SendMessageAsync(joinLobbyRequest, CancellationToken.None);
        JoinLobbyResponse joinLobbyResponse = await joinLobbyResponseListener.ReceiveMessageAsync();
        joinLobbyResponseListener.Unsubscribe();
        return joinLobbyResponse;
    }

    public async Task<GetAllLobbiesResponse> GetAllLobbies()
    {
        MessageListener<GetAllLobbiesResponse> getAllLobbiesResponseListener = new MessageListener<GetAllLobbiesResponse>();
        getAllLobbiesResponseListener.Subscribe(_messageProcessor);
        GetAllLobbiesRequest getAllLobbiesRequest = new GetAllLobbiesRequest();
        await _networkConnector.SendMessageAsync(getAllLobbiesRequest, CancellationToken.None);
        GetAllLobbiesResponse getAllLobbiesResponse = await getAllLobbiesResponseListener.ReceiveMessageAsync();
        getAllLobbiesResponseListener.Unsubscribe();
        return getAllLobbiesResponse;
    }

    public async Task<CreateLobbyResponse> CreateLobby(string lobbyName)
    {
        MessageListener<CreateLobbyResponse> createLobbyResponseListener = new MessageListener<CreateLobbyResponse>();
        createLobbyResponseListener.Subscribe(_messageProcessor);
        CreateLobbyRequest createLobbyRequest = new CreateLobbyRequest(Guid.NewGuid(), _loggedInUser, lobbyName);
        await _networkConnector.SendMessageAsync(createLobbyRequest, CancellationToken.None);
        CreateLobbyResponse createLobbyResponse = await createLobbyResponseListener.ReceiveMessageAsync();
        createLobbyResponseListener.Unsubscribe();
        return createLobbyResponse;
    }
    public async Task<StartGameResponse> StartGame(string lobbyName)
    {
        MessageListener<StartGameResponse> startGameResponseListener = new MessageListener<StartGameResponse>();
        startGameResponseListener.Subscribe(_messageProcessor);
        StartGameRequest startGameRequest = new StartGameRequest(Guid.NewGuid(), lobbyName, _loggedInUser.Id);
        await _networkConnector.SendMessageAsync(startGameRequest, CancellationToken.None);
        StartGameResponse startGameResponse = await startGameResponseListener.ReceiveMessageAsync();
        startGameResponseListener.Unsubscribe();
        return startGameResponse;
    }


}
