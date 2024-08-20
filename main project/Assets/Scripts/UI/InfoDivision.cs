using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoDivision : MonoBehaviour
{
    public bool Isclick;
    Image image;

    void Awake()
    {
        image = GetComponent<Image>();
    }
    public void ChangeColor()
    {
        if (Isclick == true)
        {
            Isclick = false;
            image.color = new Color(0.2f, 0.2f, 0.2f);
        }
        else
        {
            Isclick = true;
            image.color = new Color(1, 1, 1);
        }
    }
}
