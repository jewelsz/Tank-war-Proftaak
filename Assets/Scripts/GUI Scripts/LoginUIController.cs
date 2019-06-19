using Assets.Scripts.Enums;
using Assets.Scripts.Services;
using BattleTanks.Messages.Responses;
using BattleTanks.Networking.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class LoginUIController : MonoBehaviour
{
    [SerializeField] private GameObject failMessageBox;
    [SerializeField] private GameObject quitMessageBox;
    [SerializeField] private SceneHandler scene;
    [SerializeField] private MonoTcpNetworkConnector networkConnector;
    [SerializeField] private MonoClientMessageProcessor monoClientMessageProcessor;
    [SerializeField] private InputField usernameInputField;
    [SerializeField] private InputField passwordInputField;
    private LoginResponse loginResponse;

    public async void LoginClicked()
    {   
        
        string username = usernameInputField.text;
        string password = passwordInputField.text;

        loginResponse = await LoginAsync();

        Debug.Log("Loginresponse :" + loginResponse.IsSuccess);
        //Klopt, change naar lobby
        scene.ChangeScene(Scenes.LOBBY);

        //Fail
        //failMessageBox.SetActive(true);

    }

    private async Task<LoginResponse> LoginAsync()
    {
        AuthenticationService authenticationService = new AuthenticationService(networkConnector, monoClientMessageProcessor);
        return await authenticationService.LoginAsync(usernameInputField.text, passwordInputField.text);
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
