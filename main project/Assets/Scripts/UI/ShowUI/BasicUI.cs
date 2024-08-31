using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicUI : MonoBehaviour
{
    void Start()
    {
        ActiveTrue();
    }
    public void ActiveFalse()
    {
        gameObject.SetActive(false);
    }

    public void ActiveTrue()
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
