using Assets.Scripts.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterController : MonoBehaviour
{
    [SerializeField] private SceneHandler scene;

    [SerializeField] InputField usernameText;
    [SerializeField] InputField emailText;
    [SerializeField] InputField passwordText;
    [SerializeField] InputField confirmPasswordText;

    public void RegisterClicked()
    {
        //Registreer
    }

    public void Cancel()
    {
        scene.ChangeScene(Scenes.LOGIN);
    }
}
