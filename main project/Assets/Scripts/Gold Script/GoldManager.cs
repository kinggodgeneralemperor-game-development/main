using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    private static int currentGold;
    // Start is called before the first frame update
    void Start()        //currentGold를 세이브파일 따라서 바꾸기
    {
        currentGold = 0;
    }

    public static void UpdateGold(int inputGold)    //골드를 더하거나 뺌
    {
        currentGold += inputGold;
    }

    public static int GetcurrentGold()      //현재 골드를 받아옴
    {
        return currentGold;
    }
}
