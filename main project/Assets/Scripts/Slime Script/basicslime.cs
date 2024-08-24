using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public abstract class basicslime : MonoBehaviour, IDropHandler, IPointerClickHandler
{
    
    public Rigidbody2D slimeRigidbody;
    public bool boolmove;
    public SpriteRenderer slimespriteRenderer;
    public Sprite[] sprites;
    public static GameObject SlimeUI;
    public Slider hungryslider;
    // Start is called before the first frame update
    public void Start()
    {
        SlimeUI = GameObject.Find("Basic Canvas").transform.Find("SlimeInfo").gameObject;
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
    public abstract void OnDrop(PointerEventData eventData);
    public void movetrue() { if (boolmove != true) { boolmove = true; move(); } }
    public void movefalse() { if (boolmove != false) { boolmove = false; } }

    public abstract void move();
    public abstract void OnPointerClick(PointerEventData eventData);
}
