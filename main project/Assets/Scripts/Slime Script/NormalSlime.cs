using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSlime : basicslime
{
    const int minX = 20;
    const int minY = 20;
    const int maxX = 50;
    const int maxY = 50;
    override public void move()
    {

        if (boolmove == false)
            return;
        Vector2 f;
        f = RandomVector2(minX, minY, maxX, maxY);
        slimeRigidbody.AddForce(f);
        Invoke("move", Random.Range(1f, 3f));
    }
}
