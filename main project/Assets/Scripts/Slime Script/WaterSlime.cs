using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class WaterSlime : basicslime
{
    public float maxHungry = 100.0f;
    public float hungryindex = 80.0f;
    public static int minX = 30;
    public static int minY = 30;
    public static int maxX = 60;
    public static int maxY = 60;
    public static int slimeId = 1;
    public static int mass = 1;
    public static int drag = 4;
    public static float minMoveTime = 0.5f;
    public static float maxMoveTime = 2f;
    public static string slimename = "Water Slime";
    public static string slimeinfo = "it has strongest surface tension";

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
            Debug.Log("������ �ϳ��� ������ Ż���߽��ϴ�.");
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
        Invoke("move", Random.Range(minMoveTime, maxMoveTime));
    }

    override public void OnDrop(PointerEventData eventData)
    {
        if (hungryindex < maxHungry - 20)
        {
            hungryindex += 20;
            Debug.Log("��");

            GameObject core = Resources.Load<GameObject>("core_1");
            GameObject d = Instantiate(core, (Vector3)slimeRigidbody.position + Vector3.back, Quaternion.identity);
        }
        else Debug.Log("��θ�");


    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        SlimeUI.GetComponent<SlimeInfo>().showit();
        SlimeUI.gameObject.GetComponent<SlimeInfo>().Editname(slimename);
        SlimeUI.gameObject.GetComponent<SlimeInfo>().Editinfo(slimeinfo);
    }
}
