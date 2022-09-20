using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Scene02
{
    public class LightController : MonoBehaviour
    {
        [SerializeField] GameObject[] lights;

        int num;
        void Start()
        {
            num = lights.Length;
        }

        void Update()
        {
            var snare = OSCReciever.Snare;
            if (snare == 1.0f)
            {
                var rand = Random.Range(0, num);

                for (int i = 0; i < num; i++){
                    if(i == rand)
                    {
                        lights[i].SetActive(true);
                    }
                    else
                    {
                        lights[i].SetActive(false);
                    }
                }
            }
        }
    }
}