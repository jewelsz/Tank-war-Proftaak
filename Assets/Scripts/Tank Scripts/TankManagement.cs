using Assets.Scripts.Enums;
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

    private void Start()
    {
        //PlayerColor testColor;
        //SceneHandler sceneHandler = GameObject.FindGameObjectWithTag("Color Select").GetComponent<SceneHandler>();
        //testColor = sceneHandler.playerColor;
        //Debug.Log(testColor);

        Color = PlayerColor.RED;
        setPlayerGameObject();
        setPlayerScripts();
    }

    private void setPlayerGameObject()
    {
        switch (Color)
        {
            case PlayerColor.RED:
                playerTank = redTank;
                break;
            case PlayerColor.BLUE:
                playerTank = blueTank;
                break;
            case PlayerColor.YELLOW:
                playerTank = yellowTank;
                break;
            case PlayerColor.GREEN:
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

    public void movementFromServer(PlayerColor color, Vector3 movement)
    {

    }
}
