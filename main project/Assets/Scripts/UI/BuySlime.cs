using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuySlime : MonoBehaviour
{
    public GameObject slimepre;
    public GameObject errorUI;
    private int price = 10;

    public void CheckGold()
    {
        if(price > GoldManager.GetcurrentGold())
        {
           errorUI.SetActive(true);
        }
        else 
        {
            GoldManager.UpdateGold(price * -1);
            GameObject slime = Instantiate(slimepre);
            slime.transform.position = Vector3.zero;
            slime.transform.localScale = new Vector3(10, 10, 1);
            slime.AddComponent<basicslime>();
        }
    }
}
