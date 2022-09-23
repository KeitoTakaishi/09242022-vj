using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scene02
{
    public class AudioReactiveEmitter : MonoBehaviour
    {
        public enum EmitterTrigger
        {
            Kick,
            Snare,
            Rythm
        }

        public EmitterTrigger emitterTriggerType;

        [SerializeField] GameObject srcObject;
        [SerializeField] float emitThreshould = 0.75f;
        [SerializeField] Vector3 initPosition;


        void Start()
        {

        }

        void Update()
        {
            if(emitterTriggerType == EmitterTrigger.Kick)
            {
                if ((OSCReciever.Kick == 1.0f) && (Random.Range(0.0f, 1.0f) > emitThreshould))
                {
                    Instantiate(srcObject, initPosition, Quaternion.identity);
                }
            }else if(emitterTriggerType == EmitterTrigger.Snare)
            {
                if ((OSCReciever.Snare == 1.0f) && (Random.Range(0.0f, 1.0f) > emitThreshould))
                {
                    Instantiate(srcObject, initPosition, Quaternion.identity);
                }
            }
            else if (emitterTriggerType == EmitterTrigger.Rythm)
            {
                if ((OSCReciever.Rythm == 1.0f) && (Random.Range(0.0f, 1.0f) > emitThreshould))
                {
                    Instantiate(srcObject, initPosition, Quaternion.identity);
                }
            }
        }
    }
}