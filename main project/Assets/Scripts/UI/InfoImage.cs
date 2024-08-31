using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Info UI Sprite Array
public class InfoImage : MonoBehaviour
{
    public Sprite[] slime;
    public Sprite[] farm;
    public Image infoimage;
    void Start()
    {
        infoimage = GetComponent<Image>();
    }
}
