using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Scene02Manager : MonoBehaviour
{


    [SerializeField] GameObject upTurbVFXGraphObject;
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject shortFocusCamera;
    [SerializeField] GameObject mainVolume;
    [SerializeField] GameObject shortFocusVolume;

    [SerializeField] GameObject emitterTriangle;
    [SerializeField] GameObject emitterBox;


    #region camera
    bool mainCameraAlive = true;
    bool shortFocusCameraAlive = false;
    bool mainVolumeAlive = true;
    bool shortFocusVolumeAlive = false;
    #endregion

    #region vfx
    VisualEffect upTurbVFXGraph;
    #endregion



    void Start()
    {
        upTurbVFXGraph = upTurbVFXGraphObject.GetComponent<VisualEffect>();
    }

    void Update()
    {
        CameraSwitch();
        VFXSwitch();
    }


    void CameraSwitch()
    {
        if (OSCReciever.S2ZoomCamera == 1.0f)
        {
            mainCameraAlive = true;
            mainVolumeAlive = true;
            shortFocusCameraAlive = false;
            shortFocusVolumeAlive = false;
        }else if (OSCReciever.S2ShortCamera == 1.0f)
        {
            mainCameraAlive = false;
            mainVolumeAlive = false;
            shortFocusCameraAlive = true;
            shortFocusVolumeAlive = true;
        }
        mainCamera.SetActive(mainCameraAlive);
        mainVolume.SetActive(mainVolumeAlive);

        shortFocusCamera.SetActive(shortFocusCameraAlive);
        shortFocusVolume.SetActive(shortFocusVolumeAlive);




        if (OSCReciever.S2EmitterTriangle == 1.0f)
        {
            emitterTriangle.SetActive(true);
        }
        else
        {
            emitterTriangle.SetActive(false);
        }

        if (OSCReciever.S2EmitterBox == 1.0f)
        {
            emitterBox.SetActive(true);
        }
        else
        {
            emitterBox.SetActive(false);
        }
    }

    void VFXSwitch()
    {
        if (OSCReciever.S2Vfxtrail > 0.0f)
        {
            upTurbVFXGraphObject.SetActive(true);
            upTurbVFXGraph.SetFloat("_Scale", OSCReciever.S2Vfxtrail);
        }
        else
        {
            upTurbVFXGraphObject.SetActive(false);
        }
    }
}
