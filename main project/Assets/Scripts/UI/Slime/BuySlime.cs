using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuySlime : MonoBehaviour
{
    public GameObject errorUI;
    private int price = 10;

    public void Start()
    {
    }

    //���� ��ư Ŭ�� ��, ��� üũ �� ������ ��ȯ
    public void CheckGold()
    {
        if(!GoldManager.CheckGold(price))
        {
            //��� ���� ����â
            errorUI.SetActive(true);
        }
        else 
        {
            //������ ��ȯ �� ��� �Ҹ�
            if(SlimeManager.AddSlime())
                GoldManager.UpdateGold(price * -1);

        }
    }
}
