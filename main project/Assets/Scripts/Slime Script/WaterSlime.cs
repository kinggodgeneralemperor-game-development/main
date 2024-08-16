using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class WaterSlime : basicslime
{
    public static int minX = 30;
    public static int minY = 30;
    public static int maxX = 60;
    public static int maxY = 60;
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
        GameObject core = Resources.Load<GameObject>("core_1");
        GameObject d = Instantiate(core, (Vector3)slimeRigidbody.position + Vector3.back, Quaternion.identity, GameObject.Find("Basic Canvas").transform);
    }
}
