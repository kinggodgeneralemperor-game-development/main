using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UpgradeManager : MonoBehaviour
{
    [SerializeField] UpgradeSO UpgradeSO;
    [SerializeField] UpgradeInfoSO UpgradeInfoSO;
    [SerializeField] List<TextMeshProUGUI> buttonsText;
    [SerializeField] GameObject errorUI;
    private void Start()
    {
        Upgrade_OnChanged(null, null);
        UpgradeSO.OnChanged += Upgrade_OnChanged;
    }
    void Upgrade_OnChanged(object sender, EventArgs eventArgs)
    {
        if (UpgradeSO.SlimeMaxLV < UpgradeInfoSO.SlimeMax.Count - 1)
            buttonsText[0].text = string.Format("SlimeMaxLV : {0:00}\nUpgrade Price : {1:000}", UpgradeSO.SlimeMaxLV + 1, UpgradeSO.SlimeMaxPrice);
        else
            buttonsText[0].text = string.Format("SlimeMaxLV : {0:00}\n업그레이드 완료", UpgradeSO.SlimeMaxLV + 1);

        if (UpgradeSO.HungerCooldownLV < UpgradeInfoSO.HungerCooldown.Count - 1)
            buttonsText[1].text = string.Format("HungerCoolDownLV : {0:00}\nHungerCoolDown Price : {1:000}", UpgradeSO.HungerCooldownLV + 1, UpgradeSO.HungerCooldownPrice);
        else
            buttonsText[1].text = string.Format("HungerCoolDownLV : {0:00}\n업그레이드 완료", UpgradeSO.HungerCooldownLV + 1);

        if (UpgradeSO.SlimeMaxExpLV < UpgradeInfoSO.SlimeMaxExp.Count - 1)
            buttonsText[2].text = string.Format("SlimeMaxExpLV : {0:00}\nSlimeMaxExp Price : {1:000}", UpgradeSO.SlimeMaxExpLV + 1, UpgradeSO.SlimeMaxExpPrice);
        else
            buttonsText[2].text = string.Format("SlimeMaxExpLV : {0:00}\n업그레이드 완료", UpgradeSO.SlimeMaxExpLV + 1);

        if (UpgradeSO.AutoCore)
            buttonsText[3].text = string.Format("AutoCore enabled");
        else
            buttonsText[3].text = string.Format("AutoCore disabled\nAutoCore Price : {0:000}", UpgradeInfoSO.AutoCorePrice);
        AchievementManager.UpdateUpgradeAchievement(UpgradeSO.UpgradeLVSum());
    }
    public void Upgrade_Button(int input)
    {
        switch (input)
        {
            case 0:
                if (UpgradeSO.SlimeMaxLV >= UpgradeInfoSO.SlimeMax.Count - 1)
                    break;
                if (GoldManager.CheckGold(UpgradeSO.SlimeMaxPrice))
                {
                    GoldManager.UpdateGold(-UpgradeSO.SlimeMaxPrice);
                    UpgradeSO.slimeMaxlevelup();
                }
                else
                    errorUI.SetActive(true);
                break;
            case 1:
                if (UpgradeSO.HungerCooldownLV >= UpgradeInfoSO.HungerCooldown.Count - 1)
                    break;
                if (GoldManager.CheckGold(UpgradeSO.HungerCooldownPrice))
                {
                    GoldManager.UpdateGold(-UpgradeSO.HungerCooldownPrice);
                    UpgradeSO.HungerCooldownlevelup();
                }
                else
                    errorUI.SetActive(true);
                break;
            case 2:
                if (UpgradeSO.SlimeMaxExpLV >= UpgradeInfoSO.SlimeMaxExp.Count - 1)
                    break;
                if (GoldManager.CheckGold(UpgradeSO.SlimeMaxExpPrice))
                {
                    GoldManager.UpdateGold(-UpgradeSO.SlimeMaxExpPrice);
                    UpgradeSO.SlimeMaxExplevelup();
                }
                else
                    errorUI.SetActive(true);
                break;
            case 3:
                if (UpgradeSO.AutoCore)
                    break;
                if (GoldManager.CheckGold(UpgradeInfoSO.AutoCorePrice))
                {
                    GoldManager.UpdateGold(-UpgradeInfoSO.AutoCorePrice);
                    UpgradeSO.AutoCorelevelup();
                }
                else
                    errorUI.SetActive(true);
                break;
        }
    }
}
