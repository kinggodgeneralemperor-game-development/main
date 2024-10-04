using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawNum : MonoBehaviour
{
    private static Text Text;

    private void Awake()
    {
        Text = GetComponent<Text>();
    }

    public static void ModifyFoodNumber(int foodCount)
    {
        Text.text = string.Format("x " + foodCount.ToString());
    }
}
