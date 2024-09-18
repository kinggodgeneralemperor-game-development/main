using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CoreSO", menuName = "ScriptableObjects/CoreSO", order = 2)]
public class CoreSO : ScriptableObject
{
    [SerializeField] private int corePrice;
    [SerializeField] private Sprite coreSprite;
    public int CorePrice { get { return corePrice; } }
    public Sprite CoreSprite { get { return coreSprite; } }
}
