using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    private static int currentGold;
    void Start()        //currentGold�� ���̺����� ���� �ٲٱ�
    {
        currentGold = 1000000;
    }

    public static void UpdateGold(int inputGold)    //��带 ���ϰų� ��
    {
        currentGold += inputGold;
    }

    public static int GetcurrentGold()      //���� ��带 �޾ƿ�
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
