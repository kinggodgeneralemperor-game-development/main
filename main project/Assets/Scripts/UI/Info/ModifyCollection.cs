using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModifyCollection : MonoBehaviour
{
    //스크롤뷰 컴포넌트와 연결 2개
    [SerializeField]
    public GameObject SlimeObject;
    public GameObject FoodObject;
    public Sprite newSprite;
    public static int UnlockedObjects = 0;
        
    public void ChangeInfoUI(int num)
    {
        //slime
        if (num < 6)
        {
            Image image = SlimeObject.transform.GetChild(num).GetComponent<Image>();
            image.sprite = newSprite;
            if (SlimeObject.transform.GetChild(num).transform.GetChild(0).gameObject.activeSelf == false)
            {
                UnlockedObjects++;
                AchievementManager.UpdateInfoAchievement(UnlockedObjects);
                SlimeObject.transform.GetChild(num).transform.GetChild(0).gameObject.SetActive(true); //slimeImage active
            }
        }

        //food
        else
        {
            Image image = FoodObject.transform.GetChild(num - 6).GetComponent<Image>();
            image.sprite = newSprite;
            if (FoodObject.transform.GetChild(num - 6).transform.GetChild(0).gameObject.activeSelf == false)
            {
                UnlockedObjects++;
                AchievementManager.UpdateInfoAchievement(UnlockedObjects);
                FoodObject.transform.GetChild(num - 6).transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }

}