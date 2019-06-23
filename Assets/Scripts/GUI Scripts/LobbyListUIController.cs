using Assets.Scripts.Enums;
using Assets.Scripts.Services;
using BattleTanks.Messages.Dtos;
using BattleTanks.Messages.Responses;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyListUIController : MonoBehaviour
{
    [SerializeField] private SceneHandler scene;
    [SerializeField] private ScrollRect allLobbiesView;
    [SerializeField] private GameObject allLobbiesContent;
    [SerializeField] private GameObject lobbyButtonPrefab;
    [SerializeField] private InputField lobbyName;
    private LobbyService lobbyService;

    private GameObject networkManager;
    private MonoTcpNetworkConnector networkConnector;
    private MonoClientMessageProcessor monoClientMessageProcessor;
    private UserDto loggedInUser; 
    public void Awake()
    {
        networkManager = GameObject.Find("NetworkManager");
        NetworkConnector network = networkManager.GetComponent<NetworkConnector>();
       
        networkConnector = networkManager.GetComponent<MonoTcpNetworkConnector>();
        monoClientMessageProcessor = networkManager.GetComponent<MonoClientMessageProcessor>();
        loggedInUser = networkManager.GetComponent<UserLobbyObject>().GetLoggedInUser();
        lobbyService = new LobbyService(networkConnector, monoClientMessageProcessor, loggedInUser);

        GetAllLobbies();
    }
    public async void GetAllLobbies()
    {
        GetAllLobbiesResponse getAllLobbiesResponse = await lobbyService.GetAllLobbies();

        foreach(LobbyDto lobby in getAllLobbiesResponse.LobbyDtos)
        {
            GameObject lobbyButtonObject = Instantiate(lobbyButtonPrefab);
            lobbyButtonObject.GetComponent<Button>().onClick.AddListener(() => JoinLobby(lobby.Name));

            lobbyButtonObject.transform.SetParent(allLobbiesContent.transform, false);
            lobbyButtonObject.transform.Find("Text").gameObject.GetComponent<Text>().text = lobby.Name;
        }
    }

    public async void CreateNewLobby()
    {
        CreateLobbyResponse createNewLobbyResponse = await lobbyService.CreateLobby(lobbyName.text);
        if (createNewLobbyResponse.IsSuccess)
        {
            networkManager.GetComponent<UserLobbyObject>().SetJoinedLobby(createNewLobbyResponse.LobbyDto);
            scene.ChangeScene(Scenes.LOBBY);
        }
    }

    public async void JoinLobby(string lobbyName)
    {
        JoinLobbyResponse joinLobbyResponse = await lobbyService.JoinLobby(lobbyName);
        if (joinLobbyResponse.IsSuccess)
        {
            networkManager.GetComponent<UserLobbyObject>().SetJoinedLobby(joinLobbyResponse.LobbyDto);
            scene.ChangeScene(Scenes.LOBBY);
        }

    }
}
