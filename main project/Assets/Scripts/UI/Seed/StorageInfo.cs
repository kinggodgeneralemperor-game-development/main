using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StorageInfo : MonoBehaviour
{
    private static Text[] Text = new Text[5];
    private static string[] Name = new string[5];

    void Awake()
    {
        for(int i = 0; i < 5; ++i)
            Text[i] = transform.GetChild(i).transform.GetChild(1).gameObject.GetComponent<Text>();

        Name[0] = "°¨ÀÚ¾¾¾Ñ x";
        Name[1] = "°¨ÀÚ¾¾¾Ñ x";
        Name[2] = "°¨ÀÚ¾¾¾Ñ x";
        Name[3] = "°¨ÀÚ¾¾¾Ñ x";
        Name[4] = "°¨ÀÚ¾¾¾Ñ x";
    }

    public static void modifySeedBag(int seedNumber, int seedCount)
    {
        Text[seedNumber].text = string.Format(Name[seedNumber] + seedCount.ToString());
    }

}
