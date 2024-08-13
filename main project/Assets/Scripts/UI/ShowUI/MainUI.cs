using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    Transform cameraTransform;
    void Awake()
    {
        cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    public void CameraMove()
    {
        if (cameraTransform.position.x == 0) gameObject.SetActive(true);
        else gameObject.SetActive(false);
    }

    public void showit()
    {
        gameObject.SetActive(true);
    }
    public void hideit()
    {
        gameObject.SetActive(false);
    }
}
