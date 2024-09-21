using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    public GameObject errorUI;
    static int[] seedPrice = new int[5];
    static int[] storageSeed = new int[5];
    private void Awake()
    {
        seedPrice[0] = 1;
        seedPrice[1] = 5;
        seedPrice[2] = 10;
        seedPrice[3] = 50;
        seedPrice[4] = 100;

    }
    bool CheckGold(int price)
    {
        if (price > GoldManager.GetcurrentGold())
        {
            errorUI.SetActive(true);
            return false;
        }
        else
        {
            GoldManager.UpdateGold(price * -1);
            return true;
        }
    }
    public void buySeed(int seed)
    {
        if (CheckGold(seedPrice[seed]))
        {
            getSeed(seed);
            StorageInfo.modifySeedBag(seed, storageSeed[seed]);
        }
    }
    private static void getSeed(int whatSeed)
    {
        if (storageSeed[whatSeed] == 0)
        {
            //컬러 변환
        }
        storageSeed[whatSeed]++;
    }
    public static void usedSeed(int whatSeed)
    {
        if (storageSeed[whatSeed] > 0)
        {
            storageSeed[whatSeed]--;
            StorageInfo.modifySeedBag(whatSeed, storageSeed[whatSeed]);
            PlantSeed temp = GameObject.Find("Farm Canvas").transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<PlantSeed>();
            temp.PlantIt(whatSeed);
        }
        if (storageSeed[whatSeed] == 0)
        {
            //컬러 변환
        }
    }
}