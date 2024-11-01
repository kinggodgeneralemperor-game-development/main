using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmUI : BasicUI
{
    Transform cameraTransform;
    void Awake()
    {
        cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
    public void CameraMove()
    {
        if (cameraTransform.position.x == 20) gameObject.SetActive(true);
        else gameObject.SetActive(false);
    }
}
