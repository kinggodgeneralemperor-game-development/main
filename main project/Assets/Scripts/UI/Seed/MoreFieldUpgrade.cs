using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreFieldUpgrade : MonoBehaviour
{
    [SerializeField] UpgradeSO UpgradeSO;
    [SerializeField] GameObject[] field = new GameObject[6];

    public void UpdateField()
    {
        FieldInfo info = field[UpgradeSO.GroundMax - 1].GetComponent<FieldInfo>();
        info.BuyField();
    }

    private void Start()
    {
        FieldInfo info = field[0].GetComponent<FieldInfo>();
        info.BuyField();
    }
}
