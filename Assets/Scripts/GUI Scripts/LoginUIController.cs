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
    [SerializeField] private MonoTcpNetworkConnector tcpNetworkConnector;
    [SerializeField] private MonoClientMessageProcessor monoClientMessageProcessor;
    [SerializeField] private InputField usernameInputField;
    [SerializeField] private InputField passwordInputField;
    private LoginResponse loginResponse;

    public async void LoginClicked()
    {     
        string username = usernameInputField.text;
        string password = passwordInputField.text;

        loginResponse = await LoginAsync();
        if (!loginResponse.IsSuccess)
        {
            LoginFail();
            return;
        }

        GameObject networkManager = GameObject.Find("NetworkManager");
        networkManager.GetComponent<UserLobbyObject>().SetLoggedInUser(loginResponse.UserDto);

        scene.ChangeScene(Scenes.LOBBYLIST);
    }

    private async Task<LoginResponse> LoginAsync()
    {
        AuthenticationService authenticationService = new AuthenticationService(tcpNetworkConnector, monoClientMessageProcessor);
        return await authenticationService.LoginAsync(usernameInputField.text, passwordInputField.text);
    }

    public void FailMessageOk()
    {
        failMessageBox.SetActive(false);
    }

    public void LoginFail()
    {
        failMessageBox.SetActive(true);
    }

    public void DisableMessagebox()
    {
        failMessageBox.SetActive(false);
    }
    
    public void GoToRegister()
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
