using Assets.Scripts.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public void ChangeScene(Scenes scene)
    {
        Debug.Log("scene change!!!!");
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
}
