using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class timeManager : MonoBehaviour
{
    public TextMeshProUGUI maintimeText;        //���� �ð� ǥ�� �ؽ�Ʈ
    public TextMeshProUGUI currentGoldText;     //���� ��� ǥ�� �ؽ�Ʈ
    public TextMeshProUGUI currentSlimeText;    //���� ������ �� ǥ�� �ؽ�Ʈ
    void Update()                               //���� ���¸� ������Ʈ ��
    {
        maintimeText.text = string.Format("{0:00} : {1:00}", timedata.Gethour(),timedata.Getminute());
        currentGoldText.text = string.Format("Gold : {0:00}", GoldManager.GetcurrentGold());
        currentSlimeText.text = string.Format("Slime : {0:0}", SlimeManager.GetSlimeNumber());
    }
}
