using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSlime : basicslime
{
    const int minX = 10;
    const int minY = 10;
    const int maxX = 40;
    const int maxY = 40;
    override public void move()
    {
        if (boolmove == false)
            return;
        Vector2 f;
        f = RandomVector2(minX, minY, maxX, maxY);
        slimeRigidbody.AddForce(f);
        Invoke("move", Random.Range(2f, 5f));
    }
}
