using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;


namespace Scene03
{
    public class Scene03Manager : MonoBehaviour
    {
        [SerializeField] GameObject reactiveCamera;
        

        [SerializeField] GameObject shortCamera;
        [SerializeField] GameObject reactiveCameraVolume;
        [SerializeField] GameObject shortCameraVolume;


        [SerializeField] GameObject crawlSDFVFXGraphObject;
        [SerializeField] GameObject crawlTrailVFXGraphObject;
        VisualEffect crawlSDFVFXGraph;
        VisualEffect crawlTrailVFXGraph;



        #region vfx
        bool crawlSDFVFXGraphAlive = false;
        bool crawlTrailVFXGraphAlive = false;

        #endregion
        void Start()
        {
            crawlSDFVFXGraph = crawlSDFVFXGraphObject.GetComponent<VisualEffect>();
            crawlTrailVFXGraph = crawlTrailVFXGraphObject.GetComponent<VisualEffect>();
        }

        void Update()
        {
            SwitchVFX();
            SwitchCaemra();
        }

        void SwitchVFX()
        {
            if (OSCReciever.S3Vfxbox > 0.0f) {
                //crawlSDFVFXGraphAlive = !crawlSDFVFXGraphAlive;
                crawlSDFVFXGraphObject.SetActive(true);
                crawlSDFVFXGraph.SetFloat("_Scale", OSCReciever.S3Vfxbox);
            }
            else {
                crawlSDFVFXGraphObject.SetActive(false);
            }

            

            if (OSCReciever.S3Vfxtrail > 0.0f)
            {
                //crawlTrailVFXGraphAlive = !crawlTrailVFXGraphAlive;
                crawlTrailVFXGraphObject.SetActive(true);
                crawlTrailVFXGraph.SetFloat("_Scale", OSCReciever.S3Vfxtrail);
            }
            else
            {
                crawlTrailVFXGraphObject.SetActive(false);
            }
        }


        void SwitchCaemra()
        {
            if(OSCReciever.SReactiveCaemra == 1.0f)
            {
                reactiveCamera.SetActive(true);
                reactiveCameraVolume.SetActive(true);
                shortCamera.SetActive(false);
                shortCameraVolume.SetActive(false);

            }
           

            if (OSCReciever.S3ShortCamera == 1.0f)
            {
                shortCamera.SetActive(true);
                shortCameraVolume.SetActive(true);
                reactiveCamera.SetActive(false);
                reactiveCameraVolume.SetActive(false);
            }
          
        }
    }

}
