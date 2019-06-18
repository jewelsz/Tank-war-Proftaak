using Assets.Scripts.Enums;
using Assets.Scripts.Services;
using BattleTanks.Networking.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginUIController : MonoBehaviour
{
    [SerializeField] private GameObject failMessageBox;
    [SerializeField] private GameObject quitMessageBox;
    [SerializeField] private SceneHandler scene;
    [SerializeField] private MonoTcpNetworkConnector networkConnector;
    [SerializeField] private MonoClientMessageProcessor monoClientMessageProcessor;


    public async void Login()
    {
        //doe inlog checkie
        AuthenticationService authenticationService = new AuthenticationService(networkConnector, monoClientMessageProcessor, Debug.Log);
        string username = "Peter";
        string password = "Jan";
        Debug.Log("Logging in");
        await authenticationService.LoginAsync(username, password);
        //Klopt, change naar lobby
        scene.ChangeScene(Scenes.LOBBY);

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
