using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "UpgradeInfoSO", menuName = "ScriptableObjects/UpgradeInfoSO", order = 3)]

public class UpgradeInfoSO : ScriptableObject
{
    //슬라임 최대 수용치 증가
    [SerializeField] private List<int> slimeMax;
    [SerializeField] private List<int> slimeMaxPrice;
    [SerializeField] private List<int> hungerCooldown;
    [SerializeField] private List<int> hungerCooldownPrice;
    [SerializeField] private List<int> growSpeed;
    [SerializeField] private List<int> growSpeedPrice;
    public List<int> SlimeMax { get { return slimeMax; } }
    public List<int> SlimeMaxPrice { get { return slimeMaxPrice; } }
    public List<int> HungerCooldown { get { return hungerCooldown; } }
    public List<int> HungerCooldownPrice { get { return hungerCooldownPrice; } }
    public List<int> GrowSpeed { get { return growSpeed; } }
    public List<int> GrowSpeedPrice { get { return growSpeedPrice; } }
}
