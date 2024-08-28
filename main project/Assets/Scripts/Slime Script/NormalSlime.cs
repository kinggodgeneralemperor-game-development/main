using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class NormalSlime : basicslime
{
    private new void Start()
    {
        ((basicslime)this).Start();
        slimename = "Normal Slime";
        slimeinfo = "Basic Slime, it's not special";
        hungryindex = 80.0f;
        maxHungry = 100.0f;
        minX = 20; minY = 20; maxX = 50; maxY = 50; minMoveTime = 1f; maxMoveTime = 3f;
        slimeId = 0; mass = 1; drag = 4;
        core = Resources.Load<GameObject>("Core_0");
        slimeRigidbody.mass = mass;
        slimeRigidbody.drag = drag;
        move();
    }
}
