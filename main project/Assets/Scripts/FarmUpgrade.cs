using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmUpgrade : MonoBehaviour
{
    public static FarmUpgrade instance;

    int betterSeedLevel = 0;
    int fastGrowLevel = 0;
    int wateringLevel = 0;
    int largeFarmLevel = 0;
    int IsActiveGettingMachine = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
