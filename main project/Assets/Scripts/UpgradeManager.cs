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
            buttonsText[0].text = string.Format("{0} : {1:00}\n���׷��̵� ���� : {2:000}\n\n\n���� ���� ������ �� :\n{3}���� > {4}����",UpgradeInfoSO.slimeMaxText, UpgradeSO.SlimeMaxLV + 1, UpgradeSO.SlimeMaxPrice, UpgradeInfoSO.SlimeMax[UpgradeSO.SlimeMaxLV], UpgradeInfoSO.SlimeMax[UpgradeSO.SlimeMaxLV + 1]);
        else
            buttonsText[0].text = string.Format("{0} : {0:00}\n���׷��̵� �Ϸ�", UpgradeInfoSO.slimeMaxText, UpgradeSO.SlimeMaxLV + 1);

        if (UpgradeSO.HungerCooldownLV < UpgradeInfoSO.HungerCooldown.Count - 1)
            buttonsText[1].text = string.Format("{0} : {1:00}\n���׷��̵� ���� : {2:000}\n\n\n�������� ���� ��Ÿ�� ���� :\n{3}�� > {4}��", UpgradeInfoSO.hungerCooldownText, UpgradeSO.HungerCooldownLV + 1, UpgradeSO.HungerCooldownPrice, UpgradeInfoSO.HungerCooldown[UpgradeSO.HungerCooldownLV], UpgradeInfoSO.HungerCooldown[UpgradeSO.HungerCooldownLV + 1]);
        else
            buttonsText[1].text = string.Format("{0} : {1:00}\n���׷��̵� �Ϸ�", UpgradeInfoSO.hungerCooldownText, UpgradeSO.HungerCooldownLV + 1);

        if (UpgradeSO.SlimeMaxExpLV < UpgradeInfoSO.SlimeMaxExp.Count - 1)
            buttonsText[2].text = string.Format("{0} : {1:00}\n���׷��̵� ���� : {2:000}\n\n\n���� �������� �ʿ� ���� :\n{3}�� > {4}��", UpgradeInfoSO.slimeMaxExpText, UpgradeSO.SlimeMaxExpLV + 1, UpgradeSO.SlimeMaxExpPrice, UpgradeInfoSO.SlimeMaxExp[UpgradeSO.SlimeMaxExpLV] / 2, UpgradeInfoSO.SlimeMaxExp[UpgradeSO.SlimeMaxExpLV + 1] / 2);
        else
            buttonsText[2].text = string.Format("{0} : {1:00}\n���׷��̵� �Ϸ�", UpgradeInfoSO.slimeMaxExpText,UpgradeSO.SlimeMaxExpLV + 1);

        if (UpgradeSO.AutoCore)
            buttonsText[3].text = string.Format("{0} �۵� ��", UpgradeInfoSO.autoCoreText);
        else
            buttonsText[3].text = string.Format("{0} ����\n���׷��̵� ���� : {1:000}", UpgradeInfoSO.autoCoreText, UpgradeInfoSO.AutoCorePrice);

        if (UpgradeSO.BetterCropsLV < UpgradeInfoSO.BetterCrops.Count - 1)
            buttonsText[4].text = string.Format("{0} : {1:00}\n���׷��̵� ���� : {2:000}\n\n\n�� �� ��Ȯ Ȯ�� : {3}% > {4}%", UpgradeInfoSO.betterCropsText, UpgradeSO.BetterCropsLV + 1, UpgradeSO.BetterCropsPrice, UpgradeInfoSO.BetterCrops[UpgradeSO.BetterCropsLV], UpgradeInfoSO.BetterCrops[UpgradeSO.BetterCropsLV + 1]);
        else
            buttonsText[4].text = string.Format("{0} : {1:00}\n���׷��̵� �Ϸ�", UpgradeInfoSO.betterCropsText, UpgradeSO.BetterCropsLV + 1);

        if (UpgradeSO.FasterCropsGrowLV < UpgradeInfoSO.FasterCropsGrow.Count - 1)
            buttonsText[5].text = string.Format("{0} : {1:00}\n���׷��̵� ���� : {2:000}\n\n\n���� �ӵ� ����:{3}% > {4}%", UpgradeInfoSO.fasterCropsGrowText, UpgradeSO.FasterCropsGrowLV + 1, UpgradeSO.FasterCropsGrowPrice, UpgradeInfoSO.FasterCropsGrow[UpgradeSO.FasterCropsGrowLV], UpgradeInfoSO.FasterCropsGrow[UpgradeSO.FasterCropsGrowLV + 1]);
        else
            buttonsText[5].text = string.Format("{0} : {1:00}\n���׷��̵� �Ϸ�", UpgradeInfoSO.fasterCropsGrowText, UpgradeSO.FasterCropsGrowLV + 1);

        if (UpgradeSO.WetGroundLV < UpgradeInfoSO.WetGround.Count - 2)
            buttonsText[6].text = string.Format("{0} : {1:00}\n���׷��̵� ���� : {2:000}\n\n\n���� ����������� �ð�:\n{3}�� > {4}��", UpgradeInfoSO.wetGroundText, UpgradeSO.WetGroundLV + 1, UpgradeSO.WetGroundPrice, UpgradeInfoSO.WetGround[UpgradeSO.WetGroundLV], UpgradeInfoSO.WetGround[UpgradeSO.WetGroundLV + 1]);
        else if (UpgradeSO.WetGroundLV < UpgradeInfoSO.WetGround.Count - 1)
            buttonsText[6].text = string.Format("{0} : {1:00}\n���׷��̵� ���� : {2:000}\n\n\n������ �ʴ� �� Ȱ��ȭ", UpgradeInfoSO.wetGroundText, UpgradeSO.WetGroundLV + 1, UpgradeSO.WetGroundPrice);
        else
            buttonsText[6].text = string.Format("{0} : {1:00}\n���׷��̵� �Ϸ�", UpgradeInfoSO.wetGroundText, UpgradeSO.WetGroundLV + 1);

        if (UpgradeSO.GroundMaxLV < UpgradeInfoSO.GroundMax.Count - 1)
            buttonsText[7].text = string.Format("{0} : {1:00}\n���׷��̵� ���� : {2:000}\n\n\n���� �� : {3} > {4}", UpgradeInfoSO.groundMaxText, UpgradeSO.GroundMaxLV + 1, UpgradeSO.GroundMaxPrice, UpgradeInfoSO.GroundMax[UpgradeSO.GroundMaxLV], UpgradeInfoSO.GroundMax[UpgradeSO.GroundMaxLV + 1]);
        else
            buttonsText[7].text = string.Format("{0} : {1:00}\n���׷��̵� �Ϸ�", UpgradeInfoSO.groundMaxText, UpgradeSO.GroundMaxLV + 1);

        AchievementManager.UpdateUpgradeAchievement(UpgradeSO.UpgradeLVSum());
    }
    public void Upgrade_Button(int input)
    {
        switch (input)
        {
            case 0: //������ ����
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
            case 1: //����� ��
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
            case 2://���� ���� (������)
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
            case 3://�ھ� ����
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
            case 4: //2�� ���� ��Ȯ
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
            case 5: //���� ���� (����)
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
            case 6: //���ֱ�
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
            case 7: //���� ����
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
