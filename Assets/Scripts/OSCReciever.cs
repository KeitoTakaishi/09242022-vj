using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OscJack;


public class OSCReciever : MonoBehaviour
{
    private static OSCReciever instance = null;
    public static OSCReciever Instance => instance
       ?? (instance = GameObject.FindWithTag("OSCRecieveController").GetComponent<OSCReciever>());

    [SerializeField] int port;
    OscServer server;

    private static float _kick;
    private static float _kickLag;
    private static float _snare;
    private static float _snareLag;
    private static float _rythm;
    private static float _rythmLag;
    private static float _camFov;
    private static float _camRotateZ;

    private static int _sceneID;


    public static float Kick
    {
        get { return _kick; }
    }

    public static float KickLag
    {
        get { return _kickLag; }
    }

    public static float Snare
    {
        get { return _snare; }
    }

    public static float SnareLag
    {
        get { return _snareLag; }
    }

    public static float Rythm
    {
        get { return _rythm; }
    }

    public static float RythmLag
    {
        get { return _rythmLag; }
    }

    public static float CamFov
    {
        get { return _camFov; }
    }

    public static float CamRotateZ
    {
        get { return _camRotateZ; }
    }



    public static int SceneID
    {
        get { return _sceneID; }
    }


    private void Awake()
    {
        if (this != Instance)
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void OnEnable()
    {
        server = new OscServer(port);

        server.MessageDispatcher.AddCallback(
            "/kick",
            (string address, OscDataHandle data) => {
                var _ = data.GetElementAsString(0);
                _kick = float.Parse(_);
                //Debug.Log(_kick);
            }
        );

        server.MessageDispatcher.AddCallback(
            "/kickLag",
            (string address, OscDataHandle data) => {
                var _ = data.GetElementAsString(0);
                _kickLag = float.Parse(_);
                //Debug.Log(_kick);
            }
        );

        server.MessageDispatcher.AddCallback(
           "/snare",
           (string address, OscDataHandle data) => {
               var _ = data.GetElementAsString(0);
               _snare = float.Parse(_);

           }
       );

        server.MessageDispatcher.AddCallback(
           "/snareLag",
           (string address, OscDataHandle data) => {
               var _ = data.GetElementAsString(0);
               _snareLag = float.Parse(_);

           }
       );

        server.MessageDispatcher.AddCallback(
           "/rythm",
           (string address, OscDataHandle data) => {
               var _ = data.GetElementAsString(0);
               _rythm = float.Parse(_);

           }
       );

        server.MessageDispatcher.AddCallback(
           "/rythmLag",
           (string address, OscDataHandle data) =>
           {
               var _ = data.GetElementAsString(0);
               _rythmLag = float.Parse(_);

           }
       );

        server.MessageDispatcher.AddCallback(
           "/camFov",
           (string address, OscDataHandle data) =>
           {
               var _ = data.GetElementAsString(0);
               _camFov = float.Parse(_);

           }
       );

        server.MessageDispatcher.AddCallback(
          "/camRotateZ",
          (string address, OscDataHandle data) =>
          {
              var _ = data.GetElementAsString(0);
              _camRotateZ = float.Parse(_);

          }
      );

        server.MessageDispatcher.AddCallback(
           "/sceneID",
           (string address, OscDataHandle data) =>
           {
               var _ = data.GetElementAsString(0);
               _sceneID = int.Parse(_);

           }
       );
    }
}
