using Assets.Scripts.Enums;
using Assets.Scripts.Services;
using BattleTanks.Messages;
using BattleTanks.Messages.Dtos;
using BattleTanks.Messages.Requests;
using BattleTanks.Messages.Responses;
using BattleTanks.Networking.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class LobbyUIController : MonoBehaviour
{
    [SerializeField] private SceneHandler scene;
    [SerializeField] private ScrollRect allPlayersView;
    [SerializeField] private GameObject allPlayersContent;
    [SerializeField] private Text playerTextPrefab;
    private UserLobbyObject userLobbyObject;
    private GameObject networkManager;
    private IMessageProcessor messageProcessor;
    private INetworkConnector networkConnector;  

    public void Start()
    {
        networkManager = GameObject.Find("NetworkManager");

        networkConnector = networkManager.GetComponent<MonoTcpNetworkConnector>();
        messageProcessor = networkManager.GetComponent<MonoClientMessageProcessor>();
        userLobbyObject = networkManager.GetComponent<UserLobbyObject>();
        GetAllPlayers();
        Debugger.Break();
        SubscribeToStartGame();
    }
    public void GetAllPlayers()
    {
        foreach (UserDto user in userLobbyObject.GetJoinedLobby().Users)
        {
              Text playerText = Instantiate(playerTextPrefab);

              playerText.transform.SetParent(allPlayersContent.transform, false);
              playerText.text = user.Name;
        }
    }
    private async void SubscribeToStartGame()
    {
        MessageListener<StartGameResponse> startGameResponseListener = new MessageListener<StartGameResponse>();
        startGameResponseListener.Subscribe(messageProcessor);
        await startGameResponseListener.ReceiveMessageAsync();
        scene.ChangeScene(Scenes.GAME);
        startGameResponseListener.Unsubscribe();
    }

    public async void StartGame()
    {
        StartGameRequest startGameRequest = new StartGameRequest();
        await networkConnector.SendMessageAsync(startGameRequest, CancellationToken.None);
        scene.ChangeScene(Scenes.GAME);
    }

    public void BackToLogin()
    {
        scene.ChangeScene(Scenes.LOGIN);
    }
}
