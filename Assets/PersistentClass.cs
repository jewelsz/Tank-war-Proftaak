using BattleTanks.Client;
using BattleTanks.MessageSerializer;
using BattleTanks.Networking;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PersistentClass : MonoBehaviour
{
    private const int Port = 9999;
    private const string Host = "localhost";
    public ClientMessageProcessor clientMessageSingleton { get; private set; }
    public TcpNetworkConnector TcpNetworkConnector { get; private set; }

    private static PersistentClass persistentClass;

    public static PersistentClass GetInstance()
    {
        return persistentClass;
    }
    // Start is called before the first frame update
    //void Start()
    //{
    //    DontDestroyOnLoad(this.gameObject);
    //}

    private void Awake()
    {
        if (persistentClass != null && persistentClass != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            persistentClass = this;

            clientMessageSingleton = new ClientMessageProcessor();
            TcpNetworkConnector = new TcpNetworkConnector(new MessagePackMessageSerializer(), clientMessageSingleton, Host, Port);

            TcpNetworkConnector.ConnectAsync(CancellationToken.None).GetAwaiter().GetResult();
            TcpNetworkConnector.Start();
            Debug.Log(TcpNetworkConnector.IsConnected);
        }
    }
}
