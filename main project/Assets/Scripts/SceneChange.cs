using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public static void ChangeMainScene()
    {
        SceneManager.LoadScene("main_scene");
    }
    public static void ChangeEndingScene()
    {
        SceneManager.LoadScene("EndingScene");
    }
}
