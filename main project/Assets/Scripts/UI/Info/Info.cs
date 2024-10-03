using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Info : MonoBehaviour
{
    static int[] isNew = new int[11]; //6 slime + 5 food
    //ShowCelebrateUI ShowCelebrateUI;
    public ModifyCollection Modify;

    public void IsCollected(int num)
    {
        //새로운 수집
        if (isNew[num] == 0)
        {
            isNew[num] = 1;

            //ShowCelebrateUI.CelebrateUI(num);
            Modify.ChangeInfoUI(num);
        }
    }

    public bool CheckCollected(int num)
    {
        return isNew[num] == 1;
    }
}