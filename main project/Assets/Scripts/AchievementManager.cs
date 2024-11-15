using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    [SerializeField] UpgradeInfoSO UpgradeInfoSO;
    [SerializeField] GameObject EndingButton;
    public static UpgradeInfoSO upgradeInfoSO;
    public Slider AchievementSlider;
    public static float UpgradeAchievement = 0;
    public static float InfoAchievement = 0;
    public static int CurrentAchievement;

    public GameObject errorui;
    private void Start()
    {
        upgradeInfoSO = UpgradeInfoSO;
    }
    private void Awake()
    {
    }
    private void Update()
    {
        UpdateAchievementSlider();
    }
    public static void UpdateUpgradeAchievement(int input)
    {
        UpgradeAchievement = (float)input / (float)(upgradeInfoSO.UpgradeLVSum());
        Debug.Log(UpgradeAchievement);
    }

    public static void UpdateInfoAchievement(int input)
    {
        InfoAchievement = (float)input / (float)11;
    }
    public void UpdateAchievementSlider()
    {
        AchievementSlider.value = (UpgradeAchievement + InfoAchievement) * (float)100 / (float)2;
        if (AchievementSlider.value >= 100)
            EndingButton.SetActive(true);
        else
            EndingButton.SetActive(false);
        Debug.Log(UpgradeAchievement);
    }

    public void PayAchievement()
    {
        if (GoldManager.CheckGold(1000000))
        {
            GoldManager.UpdateGold(-1000000);
            //¿£µù
        }
        else
        {
            errorui.SetActive(true);
        }
    }
}
