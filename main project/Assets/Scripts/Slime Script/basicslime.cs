using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicslime : MonoBehaviour
{
    
    Rigidbody2D slimeRigidbody;
    SpriteRenderer slimespriteRenderer;
    Sprite[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        slimespriteRenderer = GetComponent<SpriteRenderer>();
        slimeRigidbody = GetComponent<Rigidbody2D>();
        slimeRigidbody.mass = 1;
        slimeRigidbody.drag = 4;
        slimeRigidbody.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            slimeRigidbody.AddForce(new Vector2(0, 1));
        }
        if (Input.GetKey(KeyCode.S))
        {
            slimeRigidbody.AddForce(new Vector2(0, -1));
        }
        if (Input.GetKey(KeyCode.A))
        {
            slimeRigidbody.AddForce(new Vector2(-1, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            slimeRigidbody.AddForce(new Vector2(1, 0));
        }
    }

    void move()
    {
        Vector2 f;
        f = new Vector2(3, 3);
        slimeRigidbody.AddForce(f);
    }
}
