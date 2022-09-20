using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseForce : MonoBehaviour
{
    [Header("Not Used")]
    [SerializeField] GameObject rbSphere;
    GameObject[] agents;
    [SerializeField] int num;
    [SerializeField] float cohesionCoef;
    [SerializeField] float separaeteCoef;
    [SerializeField] float attractCoef;

    [SerializeField] float separaeteDistance;
    [SerializeField] GameObject targetObject;

    float[] distace;
    Vector3[] cohesionForce;
    Vector3[] separateForce;
    Vector3[] attractForce;
    public Vector3 centerPos;


    [Header("Use")]
    [SerializeField] float timeSpeed;
    [SerializeField] float noiseSpeed;
    [SerializeField] Vector3 noisePower;


    void Start()
    {
        distace = new float[num];
        agents = new GameObject[num];
        cohesionForce = new Vector3[num];
        separateForce = new Vector3[num];
        attractForce = new Vector3[num];


        for (int i = 0; i < num; i++)
        {
            //var n = Mathf.PerlinNoise(i * 10.0f, i * 10.0f) * 2.0f -1.0f;
            //n *= 10.0f;
            var x = Random.Range(-1.0f, 1.0f) * 5.0f;
            var y = Random.Range(-1.0f, 1.0f) * 5.0f;
            var z = Random.Range(-1.0f, 1.0f) * 5.0f;
            Vector3 p = new Vector3(x, y, z);
            agents[i] = Instantiate(rbSphere, p, Quaternion.identity) as GameObject;
        }
    }

    void Update()
    {
        //cohesion();
        //separate();
        attract();
        //motion();
    }


    void motion()
    {
        var t = Time.realtimeSinceStartup * 15.0f;
        var nt = Time.realtimeSinceStartup * noiseSpeed;

        float theta = t * Mathf.Deg2Rad;
        float radius = 15.0f;
        for (int i = 0; i < num; i++)
        {
            var the = theta + i * Mathf.Deg2Rad;

            var nx = Mathf.PerlinNoise(i + nt, nt) * 2.0f - 1.0f;
            var ny = Mathf.PerlinNoise(i + nt + 412, nt + 31) * 2.0f - 1.0f;
            var nz = Mathf.PerlinNoise(i + nt + 553, nt + 62) * 2.0f - 1.0f;
           
            Vector3 p = new Vector3(radius * Mathf.Cos(the) + nx * noisePower.x, ny * noisePower.y, radius * Mathf.Sin(the) + nz * noisePower.z);
            agents[i].transform.position = p;
        }
    }


    void cohesion()
    {
        centerPos = Vector3.zero;
        for (int i = 0; i < num; i++)
        {
            centerPos += agents[i].transform.position;
        }

        centerPos /= num;


        for (int i = 0; i < num; i++)
        {
            var v = centerPos - agents[i].transform.transform.position;
            distace[i] = v.magnitude;
            cohesionForce[i] = cohesionCoef * v.normalized * (distace[i] * distace[i]);
            agents[i].GetComponent<Rigidbody>().AddForce(cohesionForce[i]);
        }

    }


    void separate()
    {
        Vector3 centerPos = Vector3.zero;
        int count = 0;
        for (int i = 0; i < num; i++)
        {
            separateForce[i] = Vector3.zero;
            count = 0;
            for (int j = 0; j < num; j++)
            {
                var v = agents[j].transform.transform.position - agents[i].transform.transform.position;
                distace[i] = v.magnitude;
                if ((distace[i] > 0) && (distace[i] < separaeteDistance))
                {
                    separateForce[i] += v.normalized / distace[i];
                    count++;
                }
                if (count > 0)
                {
                    separateForce[i] /= count;
                    separateForce[i] *= separaeteCoef;

                }
            }
        }


        for (int i = 0; i < num; i++)
        {
            agents[i].GetComponent<Rigidbody>().AddForce(separateForce[i]);
        }

    }


    void attract()
    {
        
        Vector3 attractPos = targetObject.transform.position;

        for (int i = 0; i < num; i++)
        {
            var v = attractPos - agents[i].transform.transform.position;
            distace[i] = v.magnitude;
            attractForce[i] = attractCoef * v.normalized * (distace[i] * distace[i]);

            var coef = (float)(i + 1) / (float)(num);
            attractForce[i] = attractForce[i] ;
            if(attractForce[i].magnitude * Mathf.Pow(coef, 1.0f) > 3.0f)
            {
                attractForce[i] /= 3.0f;

            }

            agents[i].GetComponent<Rigidbody>().AddForce(attractForce[i] * attractCoef);




            var t = Time.realtimeSinceStartup;
            var nx = Mathf.PerlinNoise(i, t) * 2.0f - 1.0f;
            var ny = Mathf.PerlinNoise(i + 412, t + 31) * 2.0f - 1.0f;
            var nz = Mathf.PerlinNoise(i + 553, t + 62) * 2.0f - 1.0f;

            var noise = new Vector3(nx, ny, nz) * 0.1f;
            //agents[i].GetComponent<Rigidbody>().AddForce(noise);
        }

    }
}
