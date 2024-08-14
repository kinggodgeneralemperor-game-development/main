using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class FireSlime : basicslime
{
    public static int minX = 40;
    public static int minY = 40;
    public static int maxX = 90;
    public static int maxY = 90;
    public static int slimeId = 1;
    public static int mass = 1;
    public static int drag = 4;
    public static float minMoveTime = 0.5f;
    public static float maxMoveTime = 2f;

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
        Invoke("move", Random.Range(minMoveTime, maxMoveTime));
    }

    override public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("asdf");
    }
}
