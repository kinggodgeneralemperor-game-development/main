 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class basicslime : MonoBehaviour, IDropHandler, IPointerClickHandler
{
    public SlimeSO SO;
    //최대 최소 움직임
    // minX, minY, maxX, maxY;

    //움직임 이후 경직 시간
    //minMoveTime, maxMoveTime;
    
    //슬라임 정보
    public float hungryindex;
    public int level;
    public int exp;
    public int maxexp;
    //기본 정보
    //slimeid, mass, drag, maxHungry, scale, slimename, slimeinfo
    public Rigidbody2D slimeRigidbody;
    public SpriteRenderer slimespriteRenderer;
    public RectTransform levelsliderRectTransform;
    public RectTransform hungrysliderRectTransform;
    public RectTransform slimeCanvasRectTransform;
    public Canvas slimeCanvas;
    //temp
    public bool boolmove;

    //애니메이션
    public Sprite[] sprites;
    public float angleIndex;

    //슬라이더
    public Image hungryslider;
    public Slider levelSlider;

    //슬라임 기본 코어
    public GameObject corePrefab;

    //슬라임 문자열 데이터
    public static GameObject SlimeUI;
    public void Start()
    {
        //슬라임 객체 값 초기화
        SlimeUI = GameObject.Find("Main Canvas").transform.Find("SlimeInfo").gameObject;
        boolmove = true;
        angleIndex = SO.AngleIndex;
        slimespriteRenderer = GetComponent<SpriteRenderer>();
        slimeRigidbody = GetComponent<Rigidbody2D>();
        slimeRigidbody.mass = SO.Mass;
        slimeRigidbody.drag = SO.Drag;
        slimeRigidbody.gravityScale = 0;
        hungryindex = 30;
        level = 0;
        maxexp = 100;
        exp = 0;
        SO.OnChanged += Slime_OnChanged;
        Resources.Load<UpgradeSO>("UpgradeSO").OnChanged += Slime_OnChanged;
        //슬라임 배고픔 슬라이더 추가
        hungryslider = SO.Hungryslider;
        slimeCanvas = Resources.Load<Canvas>("SlimeCanvas");
        levelSlider = SO.LevelSlider;

        levelSlider = Instantiate(levelSlider);
        slimeCanvas = Instantiate(slimeCanvas);
        hungryslider = Instantiate(hungryslider);

        slimeCanvas.transform.SetParent(gameObject.transform);
        hungryslider.transform.SetParent(slimeCanvas.transform);
        levelSlider.transform.SetParent(slimeCanvas.transform);

        //RectTransform 가져오기
        slimeCanvasRectTransform = slimeCanvas.GetComponent<RectTransform>();
        levelsliderRectTransform = levelSlider.GetComponent<RectTransform>();
        hungrysliderRectTransform = hungryslider.GetComponent<RectTransform>();

        //슬라임 크기 조정
        gameObject.transform.localScale = new Vector2(SO.Scale, SO.Scale);

        //RectTransform 수정
        levelsliderRectTransform.anchoredPosition = new Vector2(0, 0);
        hungrysliderRectTransform.anchoredPosition = new Vector2(0, 0);

        move();
    }

    void Update()
    {
        hungryslider.fillAmount = hungryindex / SO.MaxHungry;
        levelSlider.maxValue = maxexp;
        levelSlider.value = exp;
        //배고픔 요소 쿨타임
        if (hungryindex > 0)
        {
            if (hungryindex > 20.0f)
                hungryindex -= (Time.deltaTime * 2);
            else
                hungryindex -= Time.deltaTime;
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
        if (theta > -angleIndex && theta <= angleIndex) slimespriteRenderer.sprite = SO.Sprites[3];
        else if (theta > angleIndex && theta <= 90 - angleIndex) slimespriteRenderer.sprite = SO.Sprites[1];
        else if (theta > 90 - angleIndex && theta <= 90 + angleIndex) slimespriteRenderer.sprite = SO.Sprites[0];
        else if (theta > 90 + angleIndex && theta <= 180 - angleIndex) slimespriteRenderer.sprite = SO.Sprites[1];
        else if (theta > -90 + angleIndex && theta <= -angleIndex) slimespriteRenderer.sprite = SO.Sprites[5];
        else if (theta > -90 - angleIndex && theta <= -90 + angleIndex) slimespriteRenderer.sprite = SO.Sprites[4];
        else if (theta > -180 + angleIndex && theta <= -90 - angleIndex) slimespriteRenderer.sprite = SO.Sprites[5];
        else slimespriteRenderer.sprite = SO.Sprites[3];
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
    public void OnDrop(PointerEventData eventData)      //슬라임 먹이 주기
    {
        if (eventData.pointerDrag.tag != "Food") return;

        ItemDrag input = eventData.pointerDrag.GetComponent<ItemDrag>();
        if (hungryindex < SO.MaxHungry - input.hungryPoint)
        {
            hungryindex += input.hungryPoint;
            Debug.Log("냠");
            exp += input.expPoint;
            var coreScript = Instantiate(corePrefab, (Vector3)slimeRigidbody.position + Vector3.back, Quaternion.identity).GetComponent<BasicCore>();
            coreScript.SO = SO.Core;
        }
        else Debug.Log("배부름");
    }

    //temp
    public void movetrue() { if (boolmove != true) { boolmove = true; move(); } }
    public void movefalse() { if (boolmove != false) { boolmove = false; } }

    public void move()
    {
        if (boolmove == false) return;

        //force 정의
        Vector2 f;
        f = RandomVector2(SO.MinX, SO.MinY, SO.MaxX, SO.MaxY);
        
        //force의 vector값에 따른 애니메이션
        DoAnimation(f);
        
        //AddForce
        slimeRigidbody.AddForce(f);
        
        //반복
        Invoke("move", UnityEngine.Random.Range(SO.MinMoveTime, SO.MaxMoveTime));
    }
    public void OnPointerClick(PointerEventData eventData)      //슬라임 클릭 시 정보UI 생성
    {
        SlimeUI.gameObject.GetComponent<SlimeInfo>().getGameObject(gameObject);
        SlimeUI.GetComponent<SlimeInfo>().showit();
    }

    //슬라임 이벤트 시그니처
    private void Slime_OnChanged(object sender, EventArgs eventArgs)
    {
        Debug.Log("qkRnla");
        gameObject.transform.localScale = new Vector2(SO.Scale, SO.Scale);
    }
}
