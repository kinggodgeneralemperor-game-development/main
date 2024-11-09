using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeSO", menuName = "ScriptableObjects/UpgradeSO", order = 4)]
public class UpgradeSO : ScriptableObject
{
    [SerializeField] private UpgradeInfoSO UpgradeInfo;

    //슬라임 강화
    [SerializeField] private int slimeMaxLV;
    [SerializeField] private int hungerCooldownLV;
    [SerializeField] private int slimeMaxExpLV;
    [SerializeField] private bool autoFeeding;
    [SerializeField] private bool autoCore;
    public int SlimeMaxLV { set { slimeMaxLV = value; if(OnChanged != null) OnChanged.Invoke(this, EventArgs.Empty);} get { return slimeMaxLV; } }
    public int HungerCooldownLV { set { hungerCooldownLV = value; if (OnChanged != null) OnChanged.Invoke(this, EventArgs.Empty);} get { return hungerCooldownLV; } }
    public int SlimeMaxExpLV { set { slimeMaxExpLV = value; if (OnChanged != null) OnChanged.Invoke(this, EventArgs.Empty); } get { return slimeMaxExpLV; } }
   

    public int SlimeMax { get { return UpgradeInfo.SlimeMax[slimeMaxLV]; } }
    public int SlimeMaxPrice { get { return UpgradeInfo.SlimeMaxPrice[slimeMaxLV]; } }
    public int HungerCooldown { get { return UpgradeInfo.HungerCooldown[hungerCooldownLV]; } }
    public int HungerCooldownPrice { get { return UpgradeInfo.HungerCooldownPrice[hungerCooldownLV]; } }
    public int SlimeMaxExp { get { return UpgradeInfo.SlimeMaxExp[slimeMaxExpLV]; } }
    public int SlimeMaxExpPrice { get { return UpgradeInfo.SlimeMaxExpPrice[slimeMaxExpLV]; } }
    public bool AutoFeeding { set { autoFeeding = value; if (OnChanged != null) OnChanged.Invoke(this, EventArgs.Empty); } get { return autoFeeding; } }
    public bool AutoCore { set { autoCore = value; if (OnChanged != null) OnChanged.Invoke(this, EventArgs.Empty); } get { return autoCore; } }

    public void slimeMaxlevelup() { if (SlimeMaxLV < UpgradeInfo.SlimeMax.Count-1) SlimeMaxLV++; }
    public void HungerCooldownlevelup() { if (HungerCooldownLV < UpgradeInfo.HungerCooldown.Count-1) HungerCooldownLV++; }
    public void SlimeMaxExplevelup() { if (SlimeMaxExpLV < UpgradeInfo.SlimeMaxExp.Count-1) SlimeMaxExpLV++; }
    public void AutoFeedinglevelup() { AutoFeeding = true; }
    public void AutoCorelevelup() { AutoCore = true; }


    //작물 강화
    [SerializeField] private int betterCropsLV;
    [SerializeField] private int fasterCropsGrowLV;
    [SerializeField] private int wetGroundLV;
    [SerializeField] private int groundMaxLV;
    [SerializeField] private bool autoHarvest;

    public int BetterCropsLV { set { betterCropsLV = value; if (OnChanged != null) OnChanged.Invoke(this, EventArgs.Empty); } get { return betterCropsLV; } }
    public int FasterCropsGrowLV { set { fasterCropsGrowLV = value; if (OnChanged != null) OnChanged.Invoke(this, EventArgs.Empty); } get { return fasterCropsGrowLV; } }
    public int WetGroundLV { set { wetGroundLV = value; if (OnChanged != null) OnChanged.Invoke(this, EventArgs.Empty); } get { return wetGroundLV; } }
    public int GroundMaxLV { set { groundMaxLV = value; if (OnChanged != null) OnChanged.Invoke(this, EventArgs.Empty); } get { return groundMaxLV; } }
    public bool AutoHarvest { set { autoHarvest = value; if (OnChanged != null) OnChanged.Invoke(this, EventArgs.Empty); } get { return autoHarvest; } }

    public int BetterCrops { get { return UpgradeInfo.BetterCrops[betterCropsLV]; } }
    public int BetterCropsPrice { get { return UpgradeInfo.BetterCropsPrice[betterCropsLV]; } }
    public int FasterCropsGrow { get { return UpgradeInfo.FasterCropsGrow[fasterCropsGrowLV]; } }
    public int FasterCropsGrowPrice { get { return UpgradeInfo.FasterCropsGrowPrice[fasterCropsGrowLV]; } }
    public int WetGround { get { return UpgradeInfo.WetGround[WetGroundLV]; } }
    public int WetGroundPrice { get { return UpgradeInfo.WetGroundPrice[WetGroundLV]; } }
    public int GroundMax { get { return UpgradeInfo.GroundMax[GroundMaxLV]; } }
    public int GroundMaxPrice { get { return UpgradeInfo.GroundMaxPrice[GroundMaxLV]; } }


    public void betterCropslevelup() { if(BetterCropsLV < UpgradeInfo.BetterCrops.Count-1) BetterCropsLV++; }
    public void fasterCropsGrowlevelup() { if (fasterCropsGrowLV < UpgradeInfo.FasterCropsGrow.Count - 1) fasterCropsGrowLV++; }
    public void wetGroundlevelup() { if (wetGroundLV < UpgradeInfo.WetGround.Count - 1) wetGroundLV++; }
    public void groundMaxlevelup() { if (groundMaxLV < UpgradeInfo.GroundMax.Count - 1) groundMaxLV++; }


    public event EventHandler OnChanged;
}
