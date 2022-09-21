using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene02Manager : MonoBehaviour
{


    [SerializeField] GameObject upTurbVFXGraph;
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject shortFocusCamera;
    [SerializeField] GameObject mainVolume;
    [SerializeField] GameObject shortFocusVolume;



    #region camera
    bool mainCameraAlive = true;
    bool shortFocusCameraAlive = false;
    bool mainVolumeAlive = true;
    bool shortFocusVolumeAlive = false;
    #endregion

    #region vfx
    bool upTurbVFXGraphAlive = false;
    #endregion



    void Start()
    {
        
    }

    void Update()
    {
        CameraSwitch();
        VFXSwitch();
    }


    void CameraSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            mainCameraAlive = true;
            mainVolumeAlive = true;
            shortFocusCameraAlive = false;
            shortFocusVolumeAlive = false;
        }else if (Input.GetKeyDown(KeyCode.W))
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
    }

    void VFXSwitch()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            upTurbVFXGraphAlive = !upTurbVFXGraphAlive;
            upTurbVFXGraph.SetActive(upTurbVFXGraphAlive);
        }
    }
}
