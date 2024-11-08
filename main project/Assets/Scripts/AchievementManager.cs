using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    [SerializeField] UpgradeInfoSO UpgradeInfoSO;
    public static UpgradeInfoSO upgradeInfoSO;
    public Slider AchievementSlider;
    public GameObject CollectionManager;
    public static float UpgradeAchievement;
    public static int CurrentAchievement;
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
    public void UpdateAchievementSlider()
    {
        AchievementSlider.value = UpgradeAchievement * (float)100;
        Debug.Log(UpgradeAchievement);
    }
}
