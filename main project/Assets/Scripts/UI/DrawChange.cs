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

        Name[0] = "수박 x";
        Name[1] = "토마토 x";
        Name[2] = "콩 x";
        Name[3] = "당근 x";
        Name[4] = "감자 x";
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
            //먹이 부족 메세지

            return false;
        }
    }//true false를 통한 슬라임 먹이 공급 여부

    void modifyFoodNumber(int foodNum)
    {
        Text[foodNum].text = string.Format(Name[foodNum] + foodCount[foodNum].ToString());
    }
}
