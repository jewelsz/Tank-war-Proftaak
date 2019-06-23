using Assets.Scripts.Enums;
using Assets.Scripts.Services;
using BattleTanks.Messages.Responses;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class RegisterUIController : MonoBehaviour
{
    [SerializeField] private SceneHandler scene;

    [SerializeField] InputField usernameText;
    [SerializeField] InputField emailText;
    [SerializeField] InputField passwordText;
    [SerializeField] InputField confirmPasswordText;

    private GameObject networkManager;
    private MonoTcpNetworkConnector tcpNetworkConnector;
    private MonoClientMessageProcessor monoClientMessageProcessor;

    public void Start()
    {
        networkManager = GameObject.Find("NetworkManager");
        tcpNetworkConnector = networkManager.GetComponent<MonoTcpNetworkConnector>();
        monoClientMessageProcessor = networkManager.GetComponent<MonoClientMessageProcessor>();
    }

    public async void RegisterClicked()
    {
        RegisterResponse registerResponse = await RegisterAsync();

        Debug.Log("RegisterResponse :" + registerResponse.IsSuccess);
    }


    private async Task<RegisterResponse> RegisterAsync()
    {
        AuthenticationService authenticationService = new AuthenticationService(tcpNetworkConnector, monoClientMessageProcessor);
        return await authenticationService.RegisterAsync(emailText.text, usernameText.text, passwordText.text);
    }

    public void Cancel()
    {
        scene.ChangeScene(Scenes.LOGIN);
    }
}
