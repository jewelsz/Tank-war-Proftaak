using Assets.Scripts.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneHandler : MonoBehaviour
{
    public PlayerColor playerColor { get; set; }
    [SerializeField] Dropdown ColorDropdown;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void ChangeScene(Scenes scene)
    {
        switch (scene)
        {
            case Scenes.LOGIN:
                SceneManager.LoadScene("LoginScene", LoadSceneMode.Single);
                break;

            case Scenes.GAME:
                SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
                break;

            case Scenes.LOBBY:
                SceneManager.LoadScene("LobbyScene", LoadSceneMode.Single);
                break;

            case Scenes.REGISTER:
                SceneManager.LoadScene("RegisterScene", LoadSceneMode.Single);
                break;
        }
    }

    public void setPlayerColor(PlayerColor playerColor)
    {
        this.playerColor = playerColor;
    }
}
