 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public abstract class basicslime : MonoBehaviour, IDropHandler, IPointerClickHandler
{
    //�ִ� �ּ� ������
    public int minX;
    public int minY;
    public int maxX;
    public int maxY;

    //������ ���� ���� �ð�
    public float minMoveTime;
    public float maxMoveTime;

    //������ ����
    public int slimeId;
    public int mass;
    public int drag;
    public float maxHungry;
    public float hungryindex;
    public int level;
    public int exp;
    public int maxexp;
    public float scale;
    //�⺻ ����
    public Rigidbody2D slimeRigidbody;
    public SpriteRenderer slimespriteRenderer;
    public RectTransform levelsliderRectTransform;
    public RectTransform hungrysliderRectTransform;
    public RectTransform slimeCanvasRectTransform;
    public Canvas slimeCanvas;
    //temp
    public bool boolmove;

    //�ִϸ��̼�
    public Sprite[] sprites;
    public float angleIndex;

    //������ �ھ�
    public GameObject core;

    //�����̴�
    public Image hungryslider;
    public Slider levelSlider;

    //������ ���ڿ� ������
    public static GameObject SlimeUI;
    public string slimename;
    public string slimeinfo;
    public void Start()
    {
        //������ ��ü �� �ʱ�ȭ
        SlimeUI = GameObject.Find("Main Canvas").transform.Find("SlimeInfo").gameObject;
        boolmove = true;
        angleIndex = 30.0f;
        slimespriteRenderer = GetComponent<SpriteRenderer>();
        slimeRigidbody = GetComponent<Rigidbody2D>();
        slimeRigidbody.mass = 1;
        slimeRigidbody.drag = 4;
        slimeRigidbody.gravityScale = 0;
        hungryindex = 80;
        level = 0;
        maxexp = 100;
        exp = 0;

        //������ ����� �����̴� �߰�
        hungryslider = Resources.Load<Image>("HungrySlider");
        slimeCanvas = Resources.Load<Canvas>("SlimeCanvas");
        levelSlider = Resources.Load<Slider>("LevelSlider");

        levelSlider = Instantiate(levelSlider);
        slimeCanvas = Instantiate(slimeCanvas);
        hungryslider = Instantiate(hungryslider);

        slimeCanvas.transform.SetParent(gameObject.transform);
        hungryslider.transform.SetParent(slimeCanvas.transform);
        levelSlider.transform.SetParent(slimeCanvas.transform);

        //RectTransform ��������
        slimeCanvasRectTransform = slimeCanvas.GetComponent<RectTransform>();
        levelsliderRectTransform = levelSlider.GetComponent<RectTransform>();
        hungrysliderRectTransform = hungryslider.GetComponent<RectTransform>();

        //RectTransform ����
        levelsliderRectTransform.anchoredPosition = new Vector2(0, 0);
        hungrysliderRectTransform.anchoredPosition = new Vector2(0, 0);
        move();
    }

    void Update()
    {
        hungryslider.fillAmount = hungryindex / maxHungry;
        levelSlider.maxValue = maxexp;
        levelSlider.value = exp;
        //Slider UI ��ġ ����
        /*
        float slimeX = (float)Screen.width / 2 + gameObject.transform.position.x * (float)Screen.width / 2 / 9;
        float slimeY = (float)Screen.height / 2 + gameObject.transform.position.y * (float)Screen.height / 2 / 5 + 80;
        sliderRectTransform.position = new Vector2(slimeX, slimeY);
        */
        //����� ��� ��Ÿ��
        if (hungryindex > 20.0f)
            hungryindex -= (Time.deltaTime * 2);
        else
            hungryindex -= Time.deltaTime;

        //���� Ż�� (TEMP)
        if (hungryindex < 0)
        {
            Debug.Log("������ �ϳ��� ������ Ż���߽��ϴ�.");
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
    public void OnDrop(PointerEventData eventData)      //������ ���� �ֱ�
    {
        if (eventData.pointerDrag.tag != "Food") return;

        ItemDrag input = eventData.pointerDrag.GetComponent<ItemDrag>();
        if (hungryindex < maxHungry - input.hungryPoint)
        {
            hungryindex += input.hungryPoint;
            Debug.Log("��");
            exp += input.expPoint;
            GameObject preCore = Instantiate(core, (Vector3)slimeRigidbody.position + Vector3.back, Quaternion.identity);
        }
        else Debug.Log("��θ�");
    }

    //temp
    public void movetrue() { if (boolmove != true) { boolmove = true; move(); } }
    public void movefalse() { if (boolmove != false) { boolmove = false; } }

    public void move()
    {
        if (boolmove == false) return;

        //force ����
        Vector2 f;
        f = RandomVector2(minX, minY, maxX, maxY);
        
        //force�� vector���� ���� �ִϸ��̼�
        DoAnimation(f);
        
        //AddForce
        slimeRigidbody.AddForce(f);
        
        //�ݺ�
        Invoke("move", UnityEngine.Random.Range(minMoveTime, maxMoveTime));
    }
    public void OnPointerClick(PointerEventData eventData)      //������ Ŭ�� �� ����UI ����
    {
        SlimeUI.gameObject.GetComponent<SlimeInfo>().getGameObject(gameObject);
        SlimeUI.GetComponent<SlimeInfo>().showit();
    }
    private void OnDestroy()
    {
    }
}
