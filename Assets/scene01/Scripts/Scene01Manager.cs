using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

namespace Scene01 { 
    public class Scene01Manager : MonoBehaviour
    {

        [SerializeField] GameObject trailVFXObject;
        VisualEffect trailVFX;

        private void Awake()
        {
            trailVFX = trailVFXObject.GetComponent<VisualEffect>();
        }

        void Start()
        {

        }

        void Update()
        {
            if(OSCReciever.S1Vfxtrail > 0.0f)
            {
                trailVFXObject.SetActive(true);
                trailVFX.SetFloat("_TrailWidth", OSCReciever.S1Vfxtrail);
                trailVFX.SetFloat("_TurbPower", OSCReciever.KickLag);

                
            }
            else
            {
                trailVFXObject.SetActive(false);
            }
        }
    }
}