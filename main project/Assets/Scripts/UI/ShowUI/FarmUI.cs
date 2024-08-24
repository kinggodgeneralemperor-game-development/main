using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmUI : MonoBehaviour
{
    Transform cameraTransform;
    void Awake()
    {
        cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void CameraMove()
    {
        if (cameraTransform.position.x == 20) gameObject.SetActive(true);
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
