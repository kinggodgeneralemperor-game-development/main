 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class basicslime : MonoBehaviour, IDropHandler, IPointerClickHandler
{
    public SlimeSO SO;
    public UpgradeSO UpgradeSO;
    //�ִ� �ּ� ������
    // minX, minY, maxX, maxY;

    //������ ���� ���� �ð�
    //minMoveTime, maxMoveTime;
    
    //������ ����
    public float hungryindex;
    public int level;
    public int exp;
    //�⺻ ����
    //slimeid, mass, drag, maxHungry, scale, slimename, slimeinfo
    public Rigidbody2D slimeRigidbody;
    public SpriteRenderer slimespriteRenderer;
    public RectTransform levelsliderRectTransform;
    public RectTransform hungrysliderRectTransform;
    public RectTransform slimeCanvasRectTransform;
    public Canvas slimeCanvas;
    private int[] Eats = new int[6];

    //UpgradeSO�� ���� ���ؼ� �ִ밪�� ���
    private const int MaxHungryValue = 100;
    private const int MaxExpValue = 10;
    public int MaxHungry;
    public int MaxExp;

    //temp
    public bool boolmove;

    //�ִϸ��̼�
    public Sprite[] sprites;
    public float angleIndex;

    //�����̴�
    public Image hungryslider;
    public Slider levelSlider;

    //������ �⺻ �ھ�
    public GameObject corePrefab;

    //������ ���ڿ� ������
    public static GameObject SlimeUI;

    //��� �����Ǿ����� Ȯ��
    public bool isdeleted = false;
    public void Start()
    {
        //������ ��ü �� �ʱ�ȭ
        SlimeUI = GameObject.Find("Main Canvas").transform.Find("SlimeInfo").gameObject;
        boolmove = true;
        angleIndex = SO.AngleIndex;
        slimespriteRenderer = GetComponent<SpriteRenderer>();
        slimeRigidbody = GetComponent<Rigidbody2D>();
        slimeRigidbody.mass = SO.Mass;
        slimeRigidbody.drag = SO.Drag;
        slimeRigidbody.gravityScale = 0;
        hungryindex = 0;
        level = 1;
        exp = 0;
        SO.OnChanged += Slime_OnChanged;
        UpgradeSO = Resources.Load<UpgradeSO>("UpgradeSO");
        UpgradeSO.OnChanged += Slime_OnChanged;
        //������ ����� �����̴� �߰�
        hungryslider = SO.Hungryslider;
        slimeCanvas = Resources.Load<Canvas>("SlimeCanvas");
        levelSlider = SO.LevelSlider;

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

        //������ ũ�� ����
        gameObject.transform.localScale = new Vector2(SO.Scale, SO.Scale);

        //RectTransform ����
        levelsliderRectTransform.anchoredPosition = new Vector2(0, 0);
        hungrysliderRectTransform.anchoredPosition = new Vector2(0, 0);

        move();
    }

    void Update()
    {
        MaxHungry = MaxHungryValue;
        MaxExp = MaxExpValue * UpgradeSO.SlimeMaxExp;

        hungryslider.fillAmount = hungryindex / MaxHungry;
        levelSlider.maxValue = MaxExp;
        levelSlider.value = exp;
        //����� ��� ��Ÿ��
        if (hungryindex > 0)
        {
            hungryindex -= (Time.deltaTime * UpgradeSO.HungerCooldown);
        }
        if(exp >= MaxExp)
        {
            SlimeLevelup(1);
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
    public void OnDrop(PointerEventData eventData)      //������ ���� �ֱ�
    {
        if (eventData.pointerDrag.tag != "Food") return;
        if(DrawChange.getFoodCount(ItemDrag.getFoodNum()) <=0) return;

        if (SO.SlimeId == 0 || ItemDrag.getFoodNum() + 1 == SO.SlimeId)
        {
            ItemDrag input = eventData.pointerDrag.GetComponent<ItemDrag>();
            if (hungryindex < MaxHungry - input.hungryPoint)
            {
                hungryindex += input.hungryPoint;
                Debug.Log("��");
                if (!(level >= SO.MaxLevel))
                    exp += input.expPoint;
                var coreScript = Instantiate(corePrefab, (Vector3)slimeRigidbody.position + Vector3.back, Quaternion.identity).GetComponent<BasicCore>();
                coreScript.SO = SO.Core;
                coreScript.CoreLV = level;
                DrawChange.useFood(ItemDrag.getFoodNum());
                Eats[ItemDrag.getFoodNum()]++;
            }
            else Debug.Log("��θ�");
        }
    }

    //temp
    public void movetrue() { if (boolmove != true) { boolmove = true; move(); } }
    public void movefalse() { if (boolmove != false) { boolmove = false; } }

    public void move()
    {
        if (boolmove == false) return;

        //force ����
        Vector2 f;
        f = RandomVector2(SO.MinX, SO.MinY, SO.MaxX, SO.MaxY);
        
        //force�� vector���� ���� �ִϸ��̼�
        DoAnimation(f);
        
        //AddForce
        slimeRigidbody.AddForce(f);
        
        //�ݺ�
        Invoke("move", UnityEngine.Random.Range(SO.MinMoveTime, SO.MaxMoveTime));
    }
    public void OnPointerClick(PointerEventData eventData)      //������ Ŭ�� �� ����UI ����
    {
        SlimeUI.gameObject.GetComponent<SlimeInfo>().getGameObject(gameObject);
        SlimeUI.GetComponent<SlimeInfo>().showit();
    }

    //������ �̺�Ʈ �ñ״�ó
    private void Slime_OnChanged(object sender, EventArgs eventArgs)
    {
        gameObject.transform.localScale = new Vector2(SO.Scale, SO.Scale);
        if (hungryindex >= MaxHungry) hungryindex = MaxHungry;
    }

    private void SlimeLevelup(int input)
    {
        level += input;
        exp = 0;
    }

    public bool SlimeEvolutionable()
    {

        if (level >= SO.MaxLevel)
            return true;

        return false;
    }

    public void SlimeEvolutiontrigger()
    {
        isdeleted = true;
        Destroy(gameObject);
        SlimeManager.RemoveEmpty();
        SlimeManager.AddSlime(SO.SlimeId + 1);
        
    }
    public int SlimeMaxLVinfo()
    {
        return SO.MaxLevel;
    }
    private void OnDestroy()
    {
        SO.OnChanged -= Slime_OnChanged;
        UpgradeSO.OnChanged -= Slime_OnChanged;
    }
}
