using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Scene03
{
    public class Scene03Manager : MonoBehaviour
    {
        [SerializeField] GameObject crawlSDFVFXGraph;
        [SerializeField] GameObject crawlTrailVFXGraph;


        #region vfx
        bool crawlSDFVFXGraphAlive = false;
        bool crawlTrailVFXGraphAlive = false;

        #endregion
        void Start()
        {

        }

        void Update()
        {
            SwitchVFX();
        }

        void SwitchVFX()
        {
            if (Input.GetKeyDown(KeyCode.Q)){
                crawlSDFVFXGraphAlive = !crawlSDFVFXGraphAlive;
                crawlSDFVFXGraph.SetActive(crawlSDFVFXGraphAlive);
            }
            else if (Input.GetKeyDown(KeyCode.W)){
                crawlTrailVFXGraphAlive = !crawlTrailVFXGraphAlive;
                crawlTrailVFXGraph.SetActive(crawlTrailVFXGraphAlive);
            }
        }
    }

}
