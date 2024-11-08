using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "UpgradeInfoSO", menuName = "ScriptableObjects/UpgradeInfoSO", order = 3)]

public class UpgradeInfoSO : ScriptableObject
{
    //슬라임 강화
    [SerializeField] private List<int> slimeMax;
    [SerializeField] private List<int> slimeMaxPrice;
    [SerializeField] private List<int> hungerCooldown;
    [SerializeField] private List<int> hungerCooldownPrice;
    [SerializeField] private List<int> slimeMaxExp;
    [SerializeField] private List<int> slimeMaxExpPrice;
    [SerializeField] private int autoFeedingPrice;
    [SerializeField] private int autoCorePrice;
    public List<int> SlimeMax { get { return slimeMax; } }
    public List<int> SlimeMaxPrice { get { return slimeMaxPrice; } }
    public List<int> HungerCooldown { get { return hungerCooldown; } }
    public List<int> HungerCooldownPrice { get { return hungerCooldownPrice; } }
    public List<int> SlimeMaxExp { get { return slimeMaxExp; } }
    public List<int> SlimeMaxExpPrice { get { return slimeMaxExpPrice; } }
    public int AutoFeedingPrice { get { return autoFeedingPrice; } }
    public int AutoCorePrice { get { return autoCorePrice; } }

    public int SlimeUpgradeLVSum()
    {
        return (SlimeMax.Count + HungerCooldown.Count + slimeMaxExp.Count + 1); //1 == autocoreprice
    }
    //작물 강화
    [SerializeField] private List<int> betterCrops;
    [SerializeField] private List<int> betterCropsPrice;
    [SerializeField] private List<int> fasterCropsGrow;
    [SerializeField] private List<int> fasterCropsGrowPrice;
    [SerializeField] private List<int> wetGround;
    [SerializeField] private List<int> wetGroundPrice;
    [SerializeField] private List<int> groundMax;
    [SerializeField] private List<int> groundMaxPrice;
    [SerializeField] private int autoHarvestPrice;

    public List<int> BetterCrops { get { return betterCrops; } }
    public List<int> BetterCropsPrice { get { return betterCropsPrice; } }
    public List<int> FasterCropsGrow { get { return fasterCropsGrow; } }
    public List<int> FasterCropsGrowPrice { get { return fasterCropsGrowPrice; } }
    public List<int> WetGround { get { return wetGround; } }
    public List<int> WetGroundPrice { get { return wetGroundPrice; } }
    public List<int> GroundMax { get { return groundMax; } }
    public List<int> GroundMaxPrice { get { return groundMaxPrice; } }
    public int AutoHarvestPrice { get { return autoHarvestPrice; } }

    public int FarmUpgradeLVSum()
    {
        return (betterCrops.Count + fasterCropsGrow.Count + wetGround.Count + groundMax.Count + 1); //1 == autoharvestprice
    }

    public int UpgradeLVSum()
    {
        return SlimeUpgradeLVSum() + FarmUpgradeLVSum();
    }
}
