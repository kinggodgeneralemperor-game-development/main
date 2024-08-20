using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenDivision : MonoBehaviour
{
    public bool Isclick;
    public void ChangeActive()
    {
        if (Isclick == true)
        {
            Isclick = false;
            gameObject.SetActive(false);
        }
        else
        {
            Isclick = true;
            gameObject.SetActive(true);

        }
    }
}
