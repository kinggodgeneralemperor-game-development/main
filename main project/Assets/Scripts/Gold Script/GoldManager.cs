using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    private static int currentGold;
    void Start()        //currentGold를 세이브파일 따라서 바꾸기
    {
        currentGold = 1000000;
    }

    public static void UpdateGold(int inputGold)    //골드를 더하거나 뺌
    {
        currentGold += inputGold;
    }

    public static int GetcurrentGold()      //현재 골드를 받아옴
    {
        return currentGold;
    }
    public static bool CheckGold(int input)
    {
        if (input <= currentGold)
            return true;
        else
            return false;
    }
}
