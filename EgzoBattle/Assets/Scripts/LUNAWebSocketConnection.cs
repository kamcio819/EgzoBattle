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

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Start()
    {
        webSocket = new WebSocket ("ws://192.168.102.59:1234");
        webSocket.OnMessage += RecievedMessage;

        webSocket.Connect ();
        

    }

   private void RecievedMessage(object sender, MessageEventArgs e)
   {
        lunaData = JsonUtility.FromJson<LUNAData>(e.Data);
        Debug.Log(lunaData.value);
   }

   /// <summary>
   /// This function is called when the behaviour becomes disabled or inactive.
   /// </summary>
   private void OnDisable()
   {
       webSocket.OnMessage -= RecievedMessage;
   }
}
