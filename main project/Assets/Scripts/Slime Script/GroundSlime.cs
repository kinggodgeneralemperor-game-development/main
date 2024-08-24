using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class GroundSlime : basicslime
{
    public float maxHungry = 100.0f;
    public float hungryindex = 80.0f;
    public static int minX = 10;
    public static int minY = 10;
    public static int maxX = 40;
    public static int maxY = 40;
    public static int slimeId = 2;
    public static int mass = 1;
    public static int drag = 4;
    public static float minMoveTime = 2f;
    public static float maxMoveTime = 5f;
    public static string slimename = "Ground Slime";
    public static string slimeinfo = "the Heaviest slime in the world";

    private new void Start()
    {
        ((basicslime)this).Start();
        slimeRigidbody.mass = mass;
        slimeRigidbody.drag = drag;
        move();
    }
    private void Update()
    {
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
    override public void move()
    {
        if (boolmove == false)
            return;
        Vector2 f;
        f = RandomVector2(minX, minY, maxX, maxY);
        DoAnimation(f);
        slimeRigidbody.AddForce(f);
        Invoke("move", Random.Range(2f, 5f));
    }
    override public void OnDrop(PointerEventData eventData)
    {
        if (hungryindex < maxHungry - 20)
        {
            hungryindex += 20;
            Debug.Log("냠");

            GameObject core = Resources.Load<GameObject>("Core_2");
            GameObject d = Instantiate(core, (Vector3)slimeRigidbody.position + Vector3.back, Quaternion.identity);
        }
        else Debug.Log("배부름");
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        SlimeUI.GetComponent<SlimeInfo>().showit();
        SlimeUI.gameObject.GetComponent<SlimeInfo>().Editname(slimename);
        SlimeUI.gameObject.GetComponent<SlimeInfo>().Editinfo(slimeinfo);
    }
}
