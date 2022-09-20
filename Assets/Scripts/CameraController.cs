using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]Transform lookat;
    Camera cam;
    void Start()
    {
        cam = this.GetComponent<Camera>();
    }

    void Update()
    {

        
        transform.LookAt(lookat);
        //this.transform.localEulerAngles = new Vector3(0.0f, 0.0f, OSCReciever.CamRotateZ);
        cam.fieldOfView = 60 - OSCReciever.CamFov;
        //this.transform.position = new Vector3(0.0f, 0.0f, OSCReceiver.CamFov);

    }
}
