using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;
using UnityEngine.VFX;

public class VFX2_2 : MonoBehaviour
{
    [SerializeField] VisualEffect graph;
    void Start()
    {
        
    }

    void Update()
    {
        graph.SetFloat("TurbIntensity", OSCReciever.KickLag * 3.0f);
    }
}
