using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawChange : MonoBehaviour
{
    private static Text[] Text = new Text[5];
    private static string[] Name = new string[5];
    int[] foodCount = new int[5];

    void Awake()
    {
        for (int i = 0; i < 5; ++i)
            Text[i] = transform.GetChild(i).transform.GetChild(0).gameObject.GetComponent<Text>();

        Name[0] = "���� x";
        Name[1] = "�丶�� x";
        Name[2] = "�� x";
        Name[3] = "��� x";
        Name[4] = "���� x";
    }

    public void getFood(int foodNum)
    {
        foodCount[foodNum]++;
        modifyFoodNumber(foodNum);
    }

    public bool useFood(int foodNum)
    {
        if (foodCount[foodNum] > 0)
        {
            foodCount[foodNum]--;
            modifyFoodNumber(foodNum);
            return true;
        }
        else
        {
            //���� ���� �޼���

            return false;
        }
    }//true false�� ���� ������ ���� ���� ����

    void modifyFoodNumber(int foodNum)
    {
        Text[foodNum].text = string.Format(Name[foodNum] + foodCount[foodNum].ToString());
    }
}
