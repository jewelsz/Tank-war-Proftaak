using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using BattleTanks.Messages.Requests;
using BattleTanks.Messages.Responses;
using UnityEngine;

public class NetworkConnector : MonoBehaviour
{
    private const string host = "localhost";
    private const int port = 9999;

    public void Start()
    {
        TcpClient tcpClient = new TcpClient();
        tcpClient.Connect(host, port);

        LoginRequest loginRequest = new LoginRequest(Guid.NewGuid(), "Raphael", "password");


        (byte[] header, byte[] body) = ConstructMessage(loginRequest);

        // send to server
        tcpClient.Client.Send(header);
        tcpClient.Client.Send(body);

        // receive from server
        byte[] headerBuffer = new byte[2048];
        tcpClient.Client.Receive(headerBuffer);
        (string typeName, int bodySize) = CreateHeader(headerBuffer);
        byte[] bodyBuffer = new byte[bodySize];

        string json = Encoding.Default.GetString(bodyBuffer);
        LoginResponse loginResponse = (LoginResponse)JsonUtility.FromJson(json, typeof(LoginResponse));
    }

    private static (string typeName, int bodySize) CreateHeader(byte[] buffer)
    {
        int headerSize = BitConverter.ToInt32(buffer, 0);
        int bodySize = BitConverter.ToInt32(buffer, 4);
        return (Encoding.Default.GetString(buffer, 8, headerSize - 8), bodySize);
    }
    private static (byte[] header, byte[] body) ConstructMessage(object messageBody)
    {
        string json = JsonUtility.ToJson(messageBody);
        Debug.Log(json);
        byte[] body = Encoding.Default.GetBytes(json);
        byte[] bodySizeBytes = BitConverter.GetBytes(body.Length);
        byte[] typeNameBytes = Encoding.Default.GetBytes(messageBody.GetType().FullName);
        byte[] headerSizeBytes = BitConverter.GetBytes(4 + bodySizeBytes.Length + typeNameBytes.Length);
        byte[] header = headerSizeBytes.Concat(bodySizeBytes).Concat(typeNameBytes).ToArray();
        return (header, body);
    }
}
