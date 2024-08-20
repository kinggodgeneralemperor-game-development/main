using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class BasicCore : MonoBehaviour
{
    public Rigidbody2D coreRigidbody;
    public void Awake()
    {
        coreRigidbody = GetComponent<Rigidbody2D>();
        coreRigidbody.AddForce(new Vector2(20, 80));
        coreRigidbody.drag = 3;
        Invoke("RemoveGravity", 1);
    }
    public void RemoveGravity()
    {
        coreRigidbody.gravityScale = 0;
        coreRigidbody.velocity.Set(0, 0);
    }

    public void CoreDestroy()
    {
        Debug.Log("de");
        Destroy(this.gameObject);
    }

    public abstract void CoreClick();
}
