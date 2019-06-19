using Assets.Scripts.Services;
using BattleTanks.Client;
using BattleTanks.MessageSerializer;
using BattleTanks.Networking;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class NetworkConnector : MonoBehaviour
{
    private const int Port = 9999;
    private const string Host = "localhost";
    public static ClientMessageProcessor clientMessageSingleton { get; private set; }
    public static MonoV2TcpNetworkConnector TcpNetworkConnector { get; private set; }

    private static NetworkConnector persistentClass;

    public static NetworkConnector GetInstance()
    {
        return persistentClass;
    }
    // Start is called before the first frame update
    private void Awake()
    {
        Debug.Log("Awoke Persistent Class");
        if (persistentClass != null && persistentClass != this)
        {
            Debug.Log("Persistent Class already existed");
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            Debug.Log("Persistent Class: Created instances of objects and Started connector");
            persistentClass = this;

            clientMessageSingleton = new ClientMessageProcessor();
            //TcpNetworkConnector = new TcpNetworkConnector(new MessagePackMessageSerializer(), clientMessageSingleton, Host, Port);
            TcpNetworkConnector = new MonoV2TcpNetworkConnector(new JsonMessageSerializer(), clientMessageSingleton);

            TcpNetworkConnector.Connect();
            TcpNetworkConnector.Start();
        }
    }
}
