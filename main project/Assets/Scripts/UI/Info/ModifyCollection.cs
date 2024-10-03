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
    public void ChangeInfoUI(int num)
    {
        //slime
        if (num < 6)
        {
            Image image = SlimeObject.transform.GetChild(num).GetComponent<Image>();
            image.sprite = newSprite;
            SlimeObject.transform.GetChild(num).transform.GetChild(0).gameObject.SetActive(true); //slimeImage active
        }

        //food
        else
        {
            Image image = FoodObject.transform.GetChild(num - 6).GetComponent<Image>();
            image.sprite = newSprite;
            FoodObject.transform.GetChild(num - 6).transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}