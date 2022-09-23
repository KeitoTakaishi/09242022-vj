using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneController : MonoBehaviour
{
    private static SceneController instance = null;

    public static SceneController Instance => instance
        ?? (instance = GameObject.FindWithTag("SceneController").GetComponent<SceneController>());

    private void Awake()
    {
        if (this != Instance)
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        //Debug.Log(SceneManager.GetActiveScene().name);
        if (OSCReciever.SceneID == 1)
        {
            if (SceneManager.GetActiveScene().name != "scene01") ToScene1();
        }
        else if (OSCReciever.SceneID == 2)
        {

            if (SceneManager.GetActiveScene().name != "scene02") ToScene2();
        }

        else if (OSCReciever.SceneID == 3)
        {

            if (SceneManager.GetActiveScene().name != "scene03") ToScene3();
        }

    }



    public static void ToScene1()
    {
        SceneManager.LoadScene("scene01");
    }
    public static void ToScene2()
    {
        SceneManager.LoadScene("scene02");
    }

    public static void ToScene3()
    {
        SceneManager.LoadScene("scene03");
    }

    private void OnDestroy()
    {
        if (this == Instance) instance = null;
    }
}