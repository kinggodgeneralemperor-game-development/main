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
            buttonsText[0].text = string.Format("{0} : {1:00}\n업그레이드 가격 : {2:000}\n\n\n수용 가능 슬라임 수 :\n{3}마리 > {4}마리",UpgradeInfoSO.slimeMaxText, UpgradeSO.SlimeMaxLV + 1, UpgradeSO.SlimeMaxPrice, UpgradeInfoSO.SlimeMax[UpgradeSO.SlimeMaxLV], UpgradeInfoSO.SlimeMax[UpgradeSO.SlimeMaxLV + 1]);
        else
            buttonsText[0].text = string.Format("{0} : {0:00}\n업그레이드 완료", UpgradeInfoSO.slimeMaxText, UpgradeSO.SlimeMaxLV + 1);

        if (UpgradeSO.HungerCooldownLV < UpgradeInfoSO.HungerCooldown.Count - 1)
            buttonsText[1].text = string.Format("{0} : {1:00}\n업그레이드 가격 : {2:000}\n\n\n슬라임의 먹이 쿨타임 감소 :\n{3}초 > {4}초", UpgradeInfoSO.hungerCooldownText, UpgradeSO.HungerCooldownLV + 1, UpgradeSO.HungerCooldownPrice, UpgradeInfoSO.HungerCooldown[UpgradeSO.HungerCooldownLV], UpgradeInfoSO.HungerCooldown[UpgradeSO.HungerCooldownLV + 1]);
        else
            buttonsText[1].text = string.Format("{0} : {1:00}\n업그레이드 완료", UpgradeInfoSO.hungerCooldownText, UpgradeSO.HungerCooldownLV + 1);

        if (UpgradeSO.SlimeMaxExpLV < UpgradeInfoSO.SlimeMaxExp.Count - 1)
            buttonsText[2].text = string.Format("{0} : {1:00}\n업그레이드 가격 : {2:000}\n\n\n레벨 업까지의 필요 먹이 :\n{3}개 > {4}개", UpgradeInfoSO.slimeMaxExpText, UpgradeSO.SlimeMaxExpLV + 1, UpgradeSO.SlimeMaxExpPrice, UpgradeInfoSO.SlimeMaxExp[UpgradeSO.SlimeMaxExpLV] / 2, UpgradeInfoSO.SlimeMaxExp[UpgradeSO.SlimeMaxExpLV + 1] / 2);
        else
            buttonsText[2].text = string.Format("{0} : {1:00}\n업그레이드 완료", UpgradeInfoSO.slimeMaxExpText,UpgradeSO.SlimeMaxExpLV + 1);

        if (UpgradeSO.AutoCore)
            buttonsText[3].text = string.Format("{0} 작동 중", UpgradeInfoSO.autoCoreText);
        else
            buttonsText[3].text = string.Format("{0} 구매\n업그레이드 가격 : {1:000}", UpgradeInfoSO.autoCoreText, UpgradeInfoSO.AutoCorePrice);

        if (UpgradeSO.BetterCropsLV < UpgradeInfoSO.BetterCrops.Count - 1)
            buttonsText[4].text = string.Format("{0} : {1:00}\n업그레이드 가격 : {2:000}\n\n\n두 배 수확 확률 : {3}% > {4}%", UpgradeInfoSO.betterCropsText, UpgradeSO.BetterCropsLV + 1, UpgradeSO.BetterCropsPrice, UpgradeInfoSO.BetterCrops[UpgradeSO.BetterCropsLV], UpgradeInfoSO.BetterCrops[UpgradeSO.BetterCropsLV + 1]);
        else
            buttonsText[4].text = string.Format("{0} : {1:00}\n업그레이드 완료", UpgradeInfoSO.betterCropsText, UpgradeSO.BetterCropsLV + 1);

        if (UpgradeSO.FasterCropsGrowLV < UpgradeInfoSO.FasterCropsGrow.Count - 1)
            buttonsText[5].text = string.Format("{0} : {1:00}\n업그레이드 가격 : {2:000}\n\n\n성장 속도 증가:{3}% > {4}%", UpgradeInfoSO.fasterCropsGrowText, UpgradeSO.FasterCropsGrowLV + 1, UpgradeSO.FasterCropsGrowPrice, UpgradeInfoSO.FasterCropsGrow[UpgradeSO.FasterCropsGrowLV], UpgradeInfoSO.FasterCropsGrow[UpgradeSO.FasterCropsGrowLV + 1]);
        else
            buttonsText[5].text = string.Format("{0} : {1:00}\n업그레이드 완료", UpgradeInfoSO.fasterCropsGrowText, UpgradeSO.FasterCropsGrowLV + 1);

        if (UpgradeSO.WetGroundLV < UpgradeInfoSO.WetGround.Count - 2)
            buttonsText[6].text = string.Format("{0} : {1:00}\n업그레이드 가격 : {2:000}\n\n\n밭이 마르기까지의 시간:\n{3}초 > {4}초", UpgradeInfoSO.wetGroundText, UpgradeSO.WetGroundLV + 1, UpgradeSO.WetGroundPrice, UpgradeInfoSO.WetGround[UpgradeSO.WetGroundLV], UpgradeInfoSO.WetGround[UpgradeSO.WetGroundLV + 1]);
        else if (UpgradeSO.WetGroundLV < UpgradeInfoSO.WetGround.Count - 1)
            buttonsText[6].text = string.Format("{0} : {1:00}\n업그레이드 가격 : {2:000}\n\n\n마르지 않는 밭 활성화", UpgradeInfoSO.wetGroundText, UpgradeSO.WetGroundLV + 1, UpgradeSO.WetGroundPrice);
        else
            buttonsText[6].text = string.Format("{0} : {1:00}\n업그레이드 완료", UpgradeInfoSO.wetGroundText, UpgradeSO.WetGroundLV + 1);

        if (UpgradeSO.GroundMaxLV < UpgradeInfoSO.GroundMax.Count - 1)
            buttonsText[7].text = string.Format("{0} : {1:00}\n업그레이드 가격 : {2:000}\n\n\n밭의 수 : {3} > {4}", UpgradeInfoSO.groundMaxText, UpgradeSO.GroundMaxLV + 1, UpgradeSO.GroundMaxPrice, UpgradeInfoSO.GroundMax[UpgradeSO.GroundMaxLV], UpgradeInfoSO.GroundMax[UpgradeSO.GroundMaxLV + 1]);
        else
            buttonsText[7].text = string.Format("{0} : {1:00}\n업그레이드 완료", UpgradeInfoSO.groundMaxText, UpgradeSO.GroundMaxLV + 1);

        AchievementManager.UpdateUpgradeAchievement(UpgradeSO.UpgradeLVSum());
    }
    public void Upgrade_Button(int input)
    {
        switch (input)
        {
            case 0: //슬라임 수용
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
            case 1: //배고픔 쿨
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
            case 2://빠른 성장 (슬라임)
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
            case 3://코어 수집
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
            case 4: //2배 음식 수확
                if (UpgradeSO.BetterCropsLV >= UpgradeInfoSO.BetterCrops.Count - 1)
                    break;
                if (GoldManager.CheckGold(UpgradeSO.BetterCropsPrice))
                {
                    GoldManager.UpdateGold(-UpgradeSO.BetterCropsPrice);
                    UpgradeSO.betterCropslevelup();
                }
                else
                    errorUI.SetActive(true);
                break;
            case 5: //빠른 성장 (농장)
                if (UpgradeSO.FasterCropsGrowLV >= UpgradeInfoSO.FasterCropsGrow.Count - 1)
                    break;
                if (GoldManager.CheckGold(UpgradeSO.FasterCropsGrowPrice))
                {
                    GoldManager.UpdateGold(-UpgradeSO.FasterCropsGrowPrice);
                    UpgradeSO.fasterCropsGrowlevelup();
                }
                else
                    errorUI.SetActive(true);
                break;
            case 6: //물주기
                if (UpgradeSO.WetGroundLV >= UpgradeInfoSO.WetGround.Count - 1)
                    break;
                if (GoldManager.CheckGold(UpgradeSO.WetGroundPrice))
                {
                    GoldManager.UpdateGold(-UpgradeSO.WetGroundPrice);
                    UpgradeSO.wetGroundlevelup();
                }
                else
                    errorUI.SetActive(true);
                break;
            case 7: //넓은 농장
                if (UpgradeSO.GroundMaxLV>= UpgradeInfoSO.GroundMax.Count - 1)
                    break;
                if (GoldManager.CheckGold(UpgradeSO.GroundMaxPrice))
                {
                    GoldManager.UpdateGold(-UpgradeSO.GroundMaxPrice);
                    UpgradeSO.groundMaxlevelup();
                }
                else
                    errorUI.SetActive(true);
                break;
        }


    }
}
