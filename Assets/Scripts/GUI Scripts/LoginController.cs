using Assets.Scripts.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginController : MonoBehaviour
{
    [SerializeField] private GameObject failMessageBox;
    [SerializeField] private SceneHandler scene;

    public void Login()
    {
        //doe inlog checkie

        //Klopt, change naar lobby
        //scene.ChangeScene(Scenes.LOBBY);

        //Fail
        failMessageBox.SetActive(true);

    }

    public void disableMessagebox()
    {
        failMessageBox.SetActive(false);
    }
}
