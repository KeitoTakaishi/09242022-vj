using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;


namespace Scene03
{
    public class Scene03Manager : MonoBehaviour
    {
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
        }

        void SwitchVFX()
        {
            if (OSCReciever.S3Vfxbox > 0.0f) {
                //crawlSDFVFXGraphAlive = !crawlSDFVFXGraphAlive;
                crawlSDFVFXGraphObject.SetActive(true);
                crawlTrailVFXGraph.SetFloat("_scale", OSCReciever.S3Vfxbox);
            }
            else {
                crawlSDFVFXGraphObject.SetActive(false);
            }

            

            if (OSCReciever.S3Vfxtrail > 0.0f)
            {
                //crawlTrailVFXGraphAlive = !crawlTrailVFXGraphAlive;
                crawlTrailVFXGraphObject.SetActive(true);
                crawlTrailVFXGraph.SetFloat("_scale", OSCReciever.S3Vfxtrail);
            }
            else
            {
                crawlTrailVFXGraphObject.SetActive(false);
            }
        }
    }

}
