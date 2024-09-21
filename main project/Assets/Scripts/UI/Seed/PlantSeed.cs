using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSeed : MonoBehaviour
{
    int WherePlant;

    public void ClickFarm(int where)
    {
        WherePlant = where;
    }

    public void PlantIt(int seedNum)
    {
        FieldInfo plant = transform.GetChild(WherePlant).gameObject.GetComponent<FieldInfo>();
        plant.StartTimer(seedNum);
    }
}
