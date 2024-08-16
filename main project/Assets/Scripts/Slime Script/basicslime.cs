using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class basicslime : MonoBehaviour, IDropHandler
{
    
    public Rigidbody2D slimeRigidbody;
    public bool boolmove;
    public SpriteRenderer slimespriteRenderer;
    public Sprite[] sprites;
    // Start is called before the first frame update
    public void Start()
    {
        boolmove = true;
        slimespriteRenderer = GetComponent<SpriteRenderer>();
        slimeRigidbody = GetComponent<Rigidbody2D>();
        slimeRigidbody.mass = 1;
        slimeRigidbody.drag = 4;
        slimeRigidbody.gravityScale = 0;

        move();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            movefalse();
        }
        else
        {
            movetrue();
        }
    }

    public static Vector2 RandomVector2(int minX, int minY, int maxX, int maxY)
    {
        int x = Random.Range(minX, maxX);
        int y = Random.Range(minY, maxY);
        int invx = Random.Range(-1, 3);
        int invy = Random.Range(-1, 3);
        if(invx <= 0) { x *= -1; }
        if (invy <= 0) { y *= -1; }
        return new Vector2(x, y);
    }
    public virtual void move() { }
    virtual public void OnDrop(PointerEventData eventData){}
    public void movetrue() { if (boolmove != true) { boolmove = true; move(); } }
    public void movefalse() { if (boolmove != false) { boolmove = false; } }

}
