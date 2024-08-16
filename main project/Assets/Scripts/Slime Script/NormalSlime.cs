using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class NormalSlime : basicslime
{
    public static int minX = 20;
    public static int minY = 20;
    public static int maxX = 50;
    public static int maxY = 50;
    public static int slimeId = 0;
    public static int mass = 1;
    public static int drag = 4;
    public static float minMoveTime = 1f;
    public static float maxMoveTime = 3f;

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
        Invoke("move", Random.Range(1f, 3f));
    }

    override public void OnDrop(PointerEventData eventData)
    {
        GameObject core = Resources.Load<GameObject>("Core_0");
        GameObject d = Instantiate(core, (Vector3)slimeRigidbody.position + Vector3.back, Quaternion.identity, GameObject.Find("Basic Canvas").transform);
    }
}
