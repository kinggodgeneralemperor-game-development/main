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
            int randomslime = Random.Range(0, 4);
            if(randomslime == 0)
                slimepre = Resources.Load<GameObject>("Normal Slime");
            else if (randomslime == 1)
                slimepre = Resources.Load<GameObject>("Water Slime");
            else if (randomslime == 2)
                slimepre = Resources.Load<GameObject>("Ground Slime");
            else if (randomslime == 3)
                slimepre = Resources.Load<GameObject>("Fire Slime");
            GameObject slime = Instantiate(slimepre);
            slime.transform.position = Vector3.zero;
        }
    }
}
