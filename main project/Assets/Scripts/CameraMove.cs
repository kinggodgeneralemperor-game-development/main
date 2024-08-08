using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    void Awake()
    {
        transform.position = new Vector3(0, 0, -10);
    }

    public void LeftMove()
    {
        if (transform.position.x > -20)
            transform.position = transform.position + new Vector3(-20, 0, 0);
    }
    public void RightMove()
    {
        if (transform.position.x < 20)
            transform.position = transform.position + new Vector3(20, 0, 0);
    }
}
