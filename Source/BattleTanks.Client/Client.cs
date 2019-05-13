using BattleTanks.Messages;
using BattleTanks.Messages.Requests;
using BattleTanks.Messages.Responses;
using BattleTanks.MessageSerializer;
using BattleTanks.Networking;
using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace BattleTanks.Client
{
    //https://github.com/jamesjlinden/unity-decompiled/blob/master/UnityEngine.Networking/NetworkTransform.cs
    //https://github.com/jamesjlinden/unity-decompiled/blob/master/UnityEngine.Networking/NetworkBehaviour.cs
    public class TransformUpdateSender : MonoBehaviour
    {
        [SerializeField]
        private float sendInterval = 0.1f;
        private float lastSentTime;
        private Vector3 lastSentPosition;
        private Quaternion lastSentRotation;

        private void Start()
        {
            lastSentTime = Time.time;
            lastSentPosition = transform.position;
            lastSentRotation = transform.rotation;
        }

        private void FixedUpdate()
        {
            //Process update
        }

        private void Update()
        {
            if (IsConnectedToServer() && HasMoved() && HasPassedSendInterval())
                SendTransform();

            bool IsConnectedToServer() => throw new NotImplementedException(); // TODO: Check if connected
            bool HasPassedSendInterval() => lastSentTime - Time.time > sendInterval;
            bool HasMoved()
            {
                bool hasMoved = false;

                if ((transform.position - lastSentPosition).magnitude > 9.99999974737875E-06)
                    hasMoved = true;
                else if (Quaternion.Angle(transform.rotation, lastSentRotation) > 9.99999974737875E-06)
                    hasMoved = true;

                return hasMoved;
            }
        }

        private void SendTransform()
        {

        }
    }
    public class TransformUpdateReceiver : MonoBehaviour
    {
        private void FixedUpdate()
        {
            //Process update
            //Interpolate
        }

        public void ReceiveUpdate()
        {
            //Update transform
        }
    }

    public class Client
    {
        private const int Port = 9999;
        private const string Host = "localhost";
        private const int MessageCount = 100_000;
        private const int ClientCount = 10;
        private const int TotalMessages = MessageCount * ClientCount;

        public async Task RunAsync()
        {
            IMessageProcessor messageProcessor = new ClientMessageProcessor();
            IMessageSerializer messageSerializer = new MessagePackMessageSerializer();
            INetworkConnector networkConnector = new TcpNetworkConnector(messageSerializer, messageProcessor, Host, Port);
            await networkConnector.ConnectAsync(CancellationToken.None);
            networkConnector.Start();

            MessageListener<LoginResponse> loginResponseListener = new MessageListener<LoginResponse>();
            loginResponseListener.Subscribe(messageProcessor);
            for (int i = 0; i < MessageCount; i++)
            {
                LoginRequest loginRequest = new LoginRequest(Guid.NewGuid(), "Mario", "password");
                await networkConnector.SendMessageAsync(loginRequest, CancellationToken.None);
                LoginResponse loginResponse = await loginResponseListener.ReceiveMessageAsync();
                //Console.WriteLine($"Success: {loginResponse.IsSuccess}, Username: {loginResponse.UserDto.Name}, RequestId: {loginResponse.RequestId}, ResponseId: {loginResponse.Id}");
            }
            loginResponseListener.Unsubscribe();
        }
    }
}
