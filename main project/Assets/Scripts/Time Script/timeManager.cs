using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class timeManager : MonoBehaviour
{
    public TextMeshProUGUI maintimeText;        //현재 시간 표시 텍스트
    public TextMeshProUGUI currentGoldText;     //현재 골드 표시 텍스트
    public TextMeshProUGUI currentSlimeText;    //현재 슬라임 수 표시 텍스트
    void Update()                               //현재 상태를 업데이트 함
    {
        maintimeText.text = string.Format("{0:00} : {1:00}", timedata.Gethour(),timedata.Getminute());
        currentGoldText.text = string.Format("Gold : {0:00}", GoldManager.GetcurrentGold());
        currentSlimeText.text = string.Format("Slime : {0:0}", SlimeManager.GetSlimeNumber());
    }
}
