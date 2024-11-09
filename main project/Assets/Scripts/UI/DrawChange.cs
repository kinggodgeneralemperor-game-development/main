using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DrawChange : MonoBehaviour
{
    private static TextMeshProUGUI[] Text = new TextMeshProUGUI[5];
    private static string[] Name = new string[5];
    static int[] foodCount = new int[5];

    void Awake()
    {
        for (int i = 0; i < 5; ++i)
            Text[i] = transform.GetChild(i).transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();

        Name[0] = "���� x";
        Name[1] = "�丶�� x";
        Name[2] = "�� x";
        Name[3] = "��� x";
        Name[4] = "���� x";
        foodCount[0] = 5;
    }

    public void getFood(int foodNum)
    {
        foodCount[foodNum]++;
        modifyFoodNumber(foodNum);
        if(ItemDrag.getFoodNum() == foodNum) DrawNum.ModifyFoodNumber(foodCount[foodNum]);
    }

    public static void useFood(int foodNum)
    {
        if (foodCount[foodNum] > 0)
        {
            foodCount[foodNum]--;
            modifyFoodNumber(foodNum);
            DrawNum.ModifyFoodNumber(foodCount[foodNum]);
        }
        else
        {
            //���� ���� �޼���
        }
    }//getFoodCount�� ���� �� üũ �� usdFood �Լ� ���

    static void modifyFoodNumber(int foodNum)
    {
        Text[foodNum].text = string.Format(Name[foodNum] + foodCount[foodNum].ToString());
    }

    public static int getFoodCount(int foodNum)
    {
        return foodCount[foodNum];
    }
}
