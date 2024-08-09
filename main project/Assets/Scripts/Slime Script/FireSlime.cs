using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSlime : basicslime
{
    const int minX = 40;
    const int minY = 40;
    const int maxX = 90;
    const int maxY = 90;
    override public void move()
    {
        if (boolmove == false)
            return;
        Vector2 f;
        f = RandomVector2(minX, minY, maxX, maxY);
        slimeRigidbody.AddForce(f);
        Invoke("move", Random.Range(0.5f, 2f));
    }
}
