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

    //���� ��ư Ŭ�� ��, ��� üũ �� ������ ��ȯ
    public void CheckGold()
    {
        if(price > GoldManager.GetcurrentGold())
        {
            //��� ���� ����â
            errorUI.SetActive(true);
        }
        else 
        {
            //������ ��ȯ �� ��� �Ҹ�
            if(SlimeManager.GetComponent<SlimeManager>().AddSlime())
                GoldManager.UpdateGold(price * -1);

        }
    }
}
