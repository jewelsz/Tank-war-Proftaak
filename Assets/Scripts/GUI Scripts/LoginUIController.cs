using Assets.Scripts.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginUIController : MonoBehaviour
{
    [SerializeField] private GameObject failMessageBox;
    [SerializeField] private GameObject quitMessageBox;
    [SerializeField] private SceneHandler scene;


    public void Login()
    {
        //doe inlog checkie

        //Klopt, change naar lobby
        scene.ChangeScene(Scenes.GAME);

        //Fail
        //failMessageBox.SetActive(true);

    }

    public void failMessageOk()
    {
        failMessageBox.SetActive(false);
    }

    public void loginFail()
    {
        failMessageBox.SetActive(true);
    }

    public void disableMessagebox()
    {
        failMessageBox.SetActive(false);
    }
    
    public void goToRegister()
    {
        scene.ChangeScene(Scenes.REGISTER);
    }

    public void QuitGameCheck()
    {
        quitMessageBox.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void KeepPlaying()
    {
        quitMessageBox.SetActive(false);
    }
}
