using Assets.Scripts.Enums;
using Assets.Scripts.Services;
using BattleTanks.Messages;
using BattleTanks.Messages.Dtos;
using BattleTanks.Messages.Events;
using BattleTanks.Networking.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankManagement : MonoBehaviour
{
    public PlayerColor Color { get; set; }

    [SerializeField]
    GameObject redTank, blueTank, yellowTank, greenTank;
    GameObject playerTank;
    [SerializeField]
    GameObject bulletPrefab;
    private UserLobbyObject userLobbyObject;
    private GameObject networkManager;
    private IMessageProcessor messageProcessor;
    private INetworkConnector networkConnector;
    private GameService gameService;
    private void Start()
    {
        networkManager = GameObject.Find("NetworkManager");

        networkConnector = networkManager.GetComponent<MonoTcpNetworkConnector>();
        messageProcessor = networkManager.GetComponent<MonoClientMessageProcessor>();
        userLobbyObject = networkManager.GetComponent<UserLobbyObject>();

        int number = userLobbyObject.GetJoinedLobby().Users.FindIndex(x => x.Name == userLobbyObject.GetLoggedInUser().Name);
        gameService = new GameService(networkConnector, messageProcessor, userLobbyObject);
        setPlayerGameObject(number);

        setPlayerScripts();
    }

    public void Update()
    {
        MovementToServerAsync();
        MovementToServerAsync();
    }
    private void setPlayerGameObject(int playerNum)
    {
        switch (playerNum)
        {
            case 0:
                playerTank = redTank;
                break;
            case 1:
                playerTank = blueTank;
                break;
            case 2:
                playerTank = yellowTank;
                break;
            case 3:
                playerTank = greenTank;
                break;
        }
    }

    public void setPlayerScripts()
    {
        OpponentMovement script;
        GameObject canon;
        GameObject bulletSpawnObj;

        //add keyboard input script
        script = playerTank.GetComponent<OpponentMovement>();
        DestroyImmediate(script, true);
        playerTank.AddComponent<TankMovement>();
        //Change tag to player
        //playerTank.gameObject.tag = "Player";

        //Find canon in tank object and add rotation script
        canon = playerTank.transform.Find("Top").gameObject;
        canon.AddComponent<CanonRotation>();

        //Add shooting script
        //Set bullet spawn and bullet prefab
        playerTank.AddComponent<Shooting>();
        playerTank.GetComponent<Shooting>().setBulletPrefab(bulletPrefab);
        bulletSpawnObj = playerTank.transform.Find("Top/Canon/BulletSpawn").gameObject;
        playerTank.GetComponent<Shooting>().setBulletSpawn(bulletSpawnObj.GetComponent<Transform>());

    }

    public async void MovementToServerAsync()
    {
        BattleTanks.Domain.Entities.Tank tank = new BattleTanks.Domain.Entities.Tank(userLobbyObject.GetLoggedInUser().Id, (int)Math.Round(playerTank.transform.position.x), (int)Math.Round(playerTank.transform.position.y), (int)Math.Round(playerTank.transform.position.z), (int)Math.Round(playerTank.transform.rotation.x), (int)Math.Round(playerTank.transform.position.y));
        
        await gameService.MoveTankAsync(tank);
    }
    public async void MovementFromServerAsync()
    {
        TankMovementEvent tankMovementEvent = await gameService.ReceiveMoveEventAsync();
        

        int number = userLobbyObject.GetJoinedLobby().Users.FindIndex(x => x.Id == tankMovementEvent.Tank.PlayerId);
        
        switch(number){
            case 0:
                redTank.transform.position = new Vector3(tankMovementEvent.Tank.XPosition, tankMovementEvent.Tank.YPosition, tankMovementEvent.Tank.ZPosition);
                break;
            case 1:
                blueTank.transform.position = new Vector3(tankMovementEvent.Tank.XPosition, tankMovementEvent.Tank.YPosition, tankMovementEvent.Tank.ZPosition);
                break;
            case 2:
                yellowTank.transform.position = new Vector3(tankMovementEvent.Tank.XPosition, tankMovementEvent.Tank.YPosition, tankMovementEvent.Tank.ZPosition);
                break;
            case 3:
                greenTank.transform.position = new Vector3(tankMovementEvent.Tank.XPosition, tankMovementEvent.Tank.YPosition, tankMovementEvent.Tank.ZPosition);
                break;
        }
    }
}
