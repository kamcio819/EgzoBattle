using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fleck;
using System;

public class LunaWebsocket : MonoBehaviour
{

    protected LunaWebsocket() { }
   
    private void Awake() {

        WebSocketServer server = new WebSocketServer("ws://192.168.102.59:1235");

        server.Start(socket =>
        {  
            socket.OnOpen = () => Debug.Log("Open!");
            socket.OnClose = () => Debug.Log("Close!");
            socket.OnMessage += RecieveJsonObject;
        });
    }

    private void RecieveJsonObject(string obj)
    {
        Debug.Log(obj);
        //Data xd = JsonUtility.FromJson<Data>(obj);
        //Debug.Log(xd);
    }

    private class Data
    {
        public double value {get;set;}
    }
}
