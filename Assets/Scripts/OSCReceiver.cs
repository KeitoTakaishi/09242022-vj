using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OscJack;


public class OSCReceiver : MonoBehaviour
{
    private OscServer _server;

    private void Start()
    {
        _server = new OscServer(9001); // Port number
        _server.MessageDispatcher.AddCallback(
            "/kick",
            (string address, OscDataHandle data) => {
                Debug.Log(data.GetElementAsFloat(0));
            }
        );
    }

    private void Update()
    {
        
    }
}
