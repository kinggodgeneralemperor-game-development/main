using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    private static int currentGold;
    // Start is called before the first frame update
    void Start()        //currentGold�� ���̺����� ���� �ٲٱ�
    {
        currentGold = 0;
    }

    public static void UpdateGold(int inputGold)    //��带 ���ϰų� ��
    {
        currentGold += inputGold;
    }

    public static int GetcurrentGold()      //���� ��带 �޾ƿ�
    {
        return currentGold;
    }
}
