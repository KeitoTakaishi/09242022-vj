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


    #region scene1
    private static float _s1Vfxtrail;
    public static float S1Vfxtrail {
        get { return _s1Vfxtrail; }
    }
    #endregion


    #region scene2
    private static float _s2ZoomCamera;
    private static float _s2ShortCamera;
    private static float _s2Vfxtrail;
    private static float _s2EmitterTriangle;
    private static float _s2EmitterBox;


    public static float S2ZoomCamera
    {
        get { return _s2ZoomCamera; }
    }

    public static float S2ShortCamera
    {
        get { return _s2ShortCamera; }
    }

    public static float S2Vfxtrail
    {
        get { return _s2Vfxtrail; }
    }

    public static float S2EmitterTriangle
    {
        get { return _s2EmitterTriangle; }
    }

    public static float S2EmitterBox
    {
        get { return _s2EmitterBox; }
    }
    #endregion


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



        #region scene1
        server.MessageDispatcher.AddCallback(
           "/s1Vfxtrail",
           (string address, OscDataHandle data) =>
           {
               var _ = data.GetElementAsString(0);
               _s1Vfxtrail = float.Parse(_);
           }
       );
        #endregion


        #region scene2
        server.MessageDispatcher.AddCallback(
           "/s2ZoomCamera",
           (string address, OscDataHandle data) =>
           {
               var _ = data.GetElementAsString(0);
               _s2ZoomCamera = float.Parse(_);
           }
       );

        server.MessageDispatcher.AddCallback(
           "/s2ShortCamera",
           (string address, OscDataHandle data) =>
           {
               var _ = data.GetElementAsString(0);
               _s2ShortCamera = float.Parse(_);
           }
       );
        server.MessageDispatcher.AddCallback(
           "/s2Vfxtrail",
           (string address, OscDataHandle data) =>
           {
               var _ = data.GetElementAsString(0);
               _s2Vfxtrail = float.Parse(_);
           }
       );

        server.MessageDispatcher.AddCallback(
           "/s2EmitterTriangle",
           (string address, OscDataHandle data) =>
           {
               var _ = data.GetElementAsString(0);
               _s2EmitterTriangle = float.Parse(_);
           }
       );
        server.MessageDispatcher.AddCallback(
           "/s2EmitterBox",
           (string address, OscDataHandle data) =>
           {
               var _ = data.GetElementAsString(0);
               _s2EmitterBox = float.Parse(_);
           }
       );
        #endregion



    }
}
