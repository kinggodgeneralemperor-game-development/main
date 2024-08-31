using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class GroundSlime : basicslime
{
    private new void Start()
    {
        ((basicslime)this).Start();
        slimename = "Ground Slime";
        slimeinfo = "the Heaviest slime in the world";
        hungryindex = 80.0f;
        maxHungry = 100.0f; 
        minX = 10; minY = 10; maxX = 40; maxY = 40; minMoveTime = 2f; maxMoveTime = 5f;
        slimeId = 2; mass = 1; drag = 4;
        core = Resources.Load<GameObject>("Core_2");
        slimeRigidbody.mass = mass;
        slimeRigidbody.drag = drag;
        move();
    }
}