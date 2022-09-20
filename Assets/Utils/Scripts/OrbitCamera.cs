using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    
    [SerializeField] GameObject target;
    [SerializeField] float speed = 10.0f;
    [SerializeField] float radius = 3.0f;
    [SerializeField] float height = 0.5f;

    [SerializeField] float noiseTimeFreq = 0.1f;
    [SerializeField] float noisePower = 0.1f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.LookAt(target.transform);
        var t = Time.realtimeSinceStartup * speed;
        var theta = t * Mathf.Deg2Rad;
        var pos = new Vector3(radius * Mathf.Cos(theta), height, radius * Mathf.Sin(theta));


        Vector3 offset = new Vector3(1233.0f, 231.0f, 553.0f);
        var noiseT = Time.realtimeSinceStartup * noiseTimeFreq;
        float x = Mathf.PerlinNoise(noiseT + offset.x, noiseT) * 2.0f - 1.0f;
        float y = Mathf.PerlinNoise(noiseT + offset.y, noiseT) * 2.0f - 1.0f;
        float z = Mathf.PerlinNoise(noiseT + offset.z, noiseT) * 2.0f - 1.0f;
        var noise  = new Vector3(x, y, z);


        this.transform.position = pos + noise * noisePower;
    }
}
