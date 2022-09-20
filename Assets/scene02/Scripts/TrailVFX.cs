using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;
using UnityEngine.VFX;

public class TrailVFX : MonoBehaviour
{
    [SerializeField] VisualEffect trailVFX;
    [SerializeField] GameObject previewObject;
    [SerializeField] float speed = 10.0f;
    void Start()
    {
        
    }

    void Update()
    {
        var t = Time.realtimeSinceStartup * speed;
        var theta = t * Mathf.Deg2Rad;
        var r = 1.0f;
        var pos = new Vector3(r * Mathf.Cos(theta), 0.0f, r * Mathf.Sin(theta));


        Vector3 offset = new Vector3(1233.0f, 231.0f, 553.0f);
        float x = Mathf.PerlinNoise(t + offset.x, t) * 2.0f - 1.0f;
        float y = Mathf.PerlinNoise(t + offset.y, t) * 2.0f - 1.0f;
        float z = Mathf.PerlinNoise(t + offset.z, t) * 2.0f - 1.0f;
        pos = new Vector3(x, y, z);
        previewObject.transform.position = pos;
        trailVFX.SetVector3("SpherePos", pos);
    }
}
