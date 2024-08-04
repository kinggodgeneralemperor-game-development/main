using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBasicUI : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(true);
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
