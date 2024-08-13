using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
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
