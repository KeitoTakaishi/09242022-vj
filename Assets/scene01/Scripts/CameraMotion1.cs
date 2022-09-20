using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Scene01
{
    public class CameraMotion1 : MonoBehaviour
    {
        [SerializeField]NoiseForce noiseForce;
        [SerializeField] float timeSpeed;
        [SerializeField] float noisePower;
        [SerializeField] GameObject lookat;

        void Start()
        {

        }

        void Update()
        {

            var t = Time.realtimeSinceStartup * timeSpeed;
            var nx = Mathf.PerlinNoise(t, t) * 2.0f - 1.0f;
            var ny = Mathf.PerlinNoise(t + 412, t + 31) * 2.0f - 1.0f;
            var nz = Mathf.PerlinNoise(t + 553, t + 62) * 2.0f - 1.0f;
            var noise = new Vector3(nx, ny, nz) * 3.0f;
            this.transform.position = noiseForce.centerPos + noise * noisePower;

            this.transform.LookAt(lookat.transform);


        }
    }
}