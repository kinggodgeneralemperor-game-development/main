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
    public void CheckGold()
    {
        if(price > GoldManager.GetcurrentGold())
        {
           errorUI.SetActive(true);
        }
        else 
        {
            GoldManager.UpdateGold(price * -1);
            SlimeManager.GetComponent<SlimeManager>().addSlime();
        }
    }
}
