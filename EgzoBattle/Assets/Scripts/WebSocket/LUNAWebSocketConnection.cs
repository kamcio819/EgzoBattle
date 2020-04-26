using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using WebSocketSharp;

public class LUNAData
{
    public string key;
    public double value;
}
public class LUNAWebSocketConnection : MonoBehaviour
{
    private WebSocket webSocket;
    public LUNAData lunaData = new LUNAData();
    public static Action<double> valueRecieved;

    public string Address = "ws://192.168.102.59:1234";

    private void Start()
    {
        webSocket = new WebSocket(Address);
        webSocket.OnMessage += RecievedMessage;
        webSocket.Connect();
    }

    private void RecievedMessage(object sender, MessageEventArgs e)
    {
        lunaData = JsonUtility.FromJson<LUNAData>(e.Data);
        valueRecieved(lunaData.value);
    }

    private void OnDisable()
    {
        webSocket.OnMessage -= RecievedMessage;
    }
}
