using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreFieldUpgrade : MonoBehaviour
{
    [SerializeField] UpgradeSO UpgradeSO;
    [SerializeField] GameObject[] field = new GameObject[6];

    public void UpdateField()
    {
        if (field[UpgradeSO.GroundMax - 1] == null) Debug.Log("field is null");
        FieldInfo info = field[UpgradeSO.GroundMax - 1].GetComponent<FieldInfo>();
        if (info == null) Debug.Log("info is null");
        info.BuyField();
    }

    private void Start()
    {
        FieldInfo info = field[0].GetComponent<FieldInfo>();
        if (field[0] == null) Debug.Log("field is null");
        if (info == null) Debug.Log("info is null");
        info.BuyField();
    }
}
