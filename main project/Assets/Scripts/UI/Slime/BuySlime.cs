using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuySlime : MonoBehaviour
{
    public GameObject errorUI;
    public GameObject SlimeManager;
    private int price = 10;

    public void Start()
    {
        SlimeManager = GameObject.Find("SlimeManager");
    }

    //구매 버튼 클릭 시, 골드 체크 및 슬라임 소환
    public void CheckGold()
    {
        if(price > GoldManager.GetcurrentGold())
        {
            //골드 부족 정보창
            errorUI.SetActive(true);
        }
        else 
        {
            //슬라임 소환 및 골드 소모
            if(SlimeManager.GetComponent<SlimeManager>().AddSlime())
                GoldManager.UpdateGold(price * -1);

        }
    }
}
