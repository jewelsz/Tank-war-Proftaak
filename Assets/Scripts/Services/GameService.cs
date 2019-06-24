using BattleTanks.Domain.Entities;
using BattleTanks.Messages;
using BattleTanks.Messages.Commands;
using BattleTanks.Messages.Dtos;
using BattleTanks.Messages.Events;
using BattleTanks.Networking.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class GameService
{ 
    private IMessageProcessor _messageProcessor;
    private INetworkConnector _networkConnector;
    private UserLobbyObject _userLobbyObject;
    private MessageListener<TankMovementEvent> tankMovementEventListener;
    public GameService(INetworkConnector networkConnector, IMessageProcessor messageProcessor, UserLobbyObject userLobbyObject)
    {
        _messageProcessor = messageProcessor;
        _networkConnector = networkConnector;
        _userLobbyObject = userLobbyObject;
        tankMovementEventListener = new MessageListener<TankMovementEvent>();
        tankMovementEventListener.Subscribe(_messageProcessor);
    }


    public async Task MoveTankAsync(Tank tank)
    {
        TankMovementCommand tankMovementCommand = new TankMovementCommand(Guid.NewGuid(), _userLobbyObject.GetJoinedLobby().Name, tank, _userLobbyObject.GetLoggedInUser().Id);
    
        await _networkConnector.SendMessageAsync(tankMovementCommand, CancellationToken.None);
    }

    public async Task<TankMovementEvent> ReceiveMoveEventAsync()
    {
        return await tankMovementEventListener.ReceiveMessageAsync();
    }
}
