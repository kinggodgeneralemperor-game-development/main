using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeSO", menuName = "ScriptableObjects/UpgradeSO", order = 4)]
public class UpgradeSO : ScriptableObject
{
    [SerializeField] private UpgradeInfoSO UpgradeInfo;
    [SerializeField] private int slimeMaxLV;
    [SerializeField] private int hungerCooldownLV;
    [SerializeField] private int growSpeedLV;

    public int SlimeMaxLV { set { slimeMaxLV = value; if(OnChanged != null) OnChanged.Invoke(this, EventArgs.Empty); } get { return slimeMaxLV; } }
    public int HungerCooldownLV { set { hungerCooldownLV = value; if (OnChanged != null) OnChanged.Invoke(this, EventArgs.Empty); } get { return hungerCooldownLV; } }
    public int GrowSpeedLV { set { growSpeedLV = value; if (OnChanged != null) OnChanged.Invoke(this, EventArgs.Empty); } get { return growSpeedLV; } }
    public int SlimeMax { get { return UpgradeInfo.SlimeMax[slimeMaxLV]; } }
    public int SlimeMaxPrice { get { return UpgradeInfo.SlimeMaxPrice[slimeMaxLV]; } }

    public void slimeMaxlevelup() { if (SlimeMaxLV < UpgradeInfo.SlimeMax.Count) SlimeMaxLV++;}

    public event EventHandler OnChanged;
}
