﻿using Assets.Scripts.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler
{
    public void ChangeScene(Scenes scene)
    {
        switch (scene)
        {
            case Scenes.LOGIN:
                SceneManager.LoadScene("LoginScene", LoadSceneMode.Single);
                break;

            case Scenes.LOBBY:
                SceneManager.LoadScene("LobbyScene", LoadSceneMode.Single);
                break;

            case Scenes.GAME:
                SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
                break;
        }
    }
}
