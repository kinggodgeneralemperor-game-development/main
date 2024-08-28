using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public abstract class basicslime : MonoBehaviour, IDropHandler, IPointerClickHandler
{
    public int minX;
    public int minY;
    public int maxX;
    public int maxY;
    public float minMoveTime;
    public float maxMoveTime;
    public int slimeId;
    public int mass;
    public int drag;
    public float maxHungry;
    public float hungryindex;
    public float angleIndex = 30.0f;    
    public Rigidbody2D slimeRigidbody;
    public bool boolmove;
    public SpriteRenderer slimespriteRenderer;
    public Sprite[] sprites;
    public static GameObject SlimeUI;
    public Slider hungryslider;
    public GameObject core;
    public string slimename;
    public string slimeinfo;
    // Start is called before the first frame update
    public void Start()
    {
        SlimeUI = GameObject.Find("Main Canvas").transform.Find("SlimeInfo").gameObject;
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
        hungryslider.value = hungryindex / maxHungry;
        if (hungryindex > 20.0f)
            hungryindex -= (Time.deltaTime * 2);
        else
            hungryindex -= Time.deltaTime;

        if (hungryindex < 0)
        {
            Debug.Log("슬라임 하나가 농장을 탈출했습니다.");
            Destroy(gameObject);
        }
    }


    // get Degree -180 to 180
    float GetAngle(Vector2 force)
    {
        float theta;
        theta = MathF.Atan2(force.y, force.x);
        return theta * Mathf.Rad2Deg;
    }

    //Sprite Motion
    public void DoAnimation(Vector2 force)
    {
        float theta = GetAngle(force);

        //flipX
        if (MathF.Abs(theta) > 90) slimespriteRenderer.flipX = true;
        else slimespriteRenderer.flipX = false;

        //Change Sprite
        if (theta > -angleIndex && theta <= angleIndex) slimespriteRenderer.sprite = sprites[3];
        else if (theta > angleIndex && theta <= 90 - angleIndex) slimespriteRenderer.sprite = sprites[1];
        else if (theta > 90 - angleIndex && theta <= 90 + angleIndex) slimespriteRenderer.sprite = sprites[0];
        else if (theta > 90 + angleIndex && theta <= 180 - angleIndex) slimespriteRenderer.sprite = sprites[1];
        else if (theta > -90 + angleIndex && theta <= -angleIndex) slimespriteRenderer.sprite = sprites[5];
        else if (theta > -90 - angleIndex && theta <= -90 + angleIndex) slimespriteRenderer.sprite = sprites[4];
        else if (theta > -180 + angleIndex && theta <= -90 - angleIndex) slimespriteRenderer.sprite = sprites[5];
        else slimespriteRenderer.sprite = sprites[3];
    }

    public static Vector2 RandomVector2(int minX, int minY, int maxX, int maxY)
    {
        int x = UnityEngine.Random.Range(minX, maxX);
        int y = UnityEngine.Random.Range(minY, maxY);
        int invx = UnityEngine.Random.Range(-1, 3);
        int invy = UnityEngine.Random.Range(-1, 3);
        if(invx <= 0) { x *= -1; }
        if (invy <= 0) { y *= -1; }

        return new Vector2(x, y);
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.tag != "Food")
            return;
        if (hungryindex < maxHungry - 20)
        {
            hungryindex += 20;
            Debug.Log("냠");

            GameObject d = Instantiate(core, (Vector3)slimeRigidbody.position + Vector3.back, Quaternion.identity);
        }
        else Debug.Log("배부름");
    }
    public void movetrue() { if (boolmove != true) { boolmove = true; move(); } }
    public void movefalse() { if (boolmove != false) { boolmove = false; } }

    public void move()
    {
        if (boolmove == false)
            return;
        Vector2 f;
        f = RandomVector2(minX, minY, maxX, maxY);
        DoAnimation(f);
        slimeRigidbody.AddForce(f);
        Invoke("move", UnityEngine.Random.Range(minMoveTime, maxMoveTime));
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        SlimeUI.GetComponent<SlimeInfo>().showit();
        SlimeUI.gameObject.GetComponent<SlimeInfo>().Editname(slimename);
        SlimeUI.gameObject.GetComponent<SlimeInfo>().Editinfo(slimeinfo);
    }
    private void OnDestroy()
    {
        SlimeManager.RemoveEmpty();
    }
}
