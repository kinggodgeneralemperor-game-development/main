using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class FireSlime : basicslime
{
    private new void Start()
    {
        ((basicslime)this).Start();
        slimename = "Fire Slime";
        slimeinfo = "Slime burning brightly, Don't approach it";
        hungryindex = 80.0f;
        maxHungry = 100.0f;
        minX = 40; minY = 40; maxX = 90; maxY = 90; minMoveTime = 0.5f; maxMoveTime = 2f;
        slimeId = 3; mass = 1; drag = 4;
        scale = 20;

        //슬라임 캔버스 크기 조정
        slimeCanvasRectTransform.sizeDelta = new Vector2(scale, scale);

        core = Resources.Load<GameObject>("Core_3");
        slimeRigidbody.mass = mass;
        slimeRigidbody.drag = drag;
        move();
    }
}