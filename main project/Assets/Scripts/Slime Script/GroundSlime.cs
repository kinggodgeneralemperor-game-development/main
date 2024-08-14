using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class GroundSlime : basicslime
{
    public static int minX = 10;
    public static int minY = 10;
    public static int maxX = 40;
    public static int maxY = 40;
    public static int slimeId = 2;
    public static int mass = 1;
    public static int drag = 4;
    public static float minMoveTime = 2f;
    public static float maxMoveTime = 5f;

    private new void Start()
    {
        ((basicslime)this).Start();
        slimeRigidbody.mass = mass;
        slimeRigidbody.drag = drag;
        move();
    }

    override public void move()
    {
        if (boolmove == false)
            return;
        Vector2 f;
        f = RandomVector2(minX, minY, maxX, maxY);
        slimeRigidbody.AddForce(f);
        Invoke("move", Random.Range(2f, 5f));
    }
    override public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("‡G");
    }
}
