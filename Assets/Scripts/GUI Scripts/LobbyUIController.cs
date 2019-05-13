using Assets.Scripts.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyUIController : MonoBehaviour
{
    [SerializeField] private SceneHandler scene;

    public void startGame()
    {
        scene.ChangeScene(Scenes.GAME);
    }

    public void backToLogin()
    {
        scene.ChangeScene(Scenes.LOGIN);
    }
}
