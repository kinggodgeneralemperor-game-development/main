using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FieldInfo : MonoBehaviour
{
    [SerializeField] UpgradeSO UpgradeSO;

    public enum Grown
    {
        NotPlanted,
        IsPlanted,
        FullGrown,
        CannotPlant
    }

    private static float[] SeedTime = new float[5];
    private static string[] SeedNames = new string[5];
    private static float[] heightWidth= new float[5];
    RectTransform trans;
    public Sprite[] sprites = new Sprite[5];
    public GameObject MainStorage;
    public Info info;
    int seedNumber;
    TextMeshProUGUI plantName;
    TextMeshProUGUI timer;
    Image plantImage;
    Image fieldImage;

    float watertime;
    static float watering = 3;
    static float additionPlant = 0.0f;
    static float moreFaster = 1.0f;
    float maxTime;
    float plantTime = 0;
    Grown IsPlanted = Grown.CannotPlant;

    public void UpdateWater()
    {
        watering = UpgradeSO.WetGround;
    }
    public void UpdateFaster()
    {
        moreFaster = (100 - UpgradeSO.FasterCropsGrow) * 0.01f;
    }

    public void UpdateAdditionPlant()
    {
        additionPlant = UpgradeSO.BetterCrops * 0.01f;
    }

    public void BuyField()
    {
        plantImage.color = new Color(1, 1, 1, 0);
        plantName.text = string.Format("빈 밭");
        IsPlanted = Grown.NotPlanted;
    }

    void Awake()
    {
        plantName = transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        timer = transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
        plantImage = transform.GetChild(0).gameObject.GetComponent<Image>();
        fieldImage = gameObject.GetComponent<Image>();
        trans = transform.GetChild(0).gameObject.GetComponent<RectTransform>();

        SeedTime[0] = 5;
        SeedTime[1] = 10;
        SeedTime[2] = 15;
        SeedTime[3] = 45;
        SeedTime[4] = 60;

        SeedNames[0] = "수박 자라는 중.";
        SeedNames[1] = "토마토 자라는 중.";
        SeedNames[2] = "콩 자라는 중.";
        SeedNames[3] = "당근 자라는 중.";
        SeedNames[4] = "감자 자라는 중.";

        heightWidth[0] = 19.0f/15.0f;
        heightWidth[1] = 8.0f/11.0f;
        heightWidth[2] = 17.0f/19.0f;
        heightWidth[3] = 11.0f/12.0f;
        heightWidth[4] = 1;
    }
    void Start()
    {
        plantName = transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        timer = transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
        plantImage = transform.GetChild(0).gameObject.GetComponent<Image>();
        fieldImage = gameObject.GetComponent<Image>();
        trans = transform.GetChild(0).gameObject.GetComponent<RectTransform>();
    }

    public void StartTimer(int seedNum)
    {
        IsPlanted = Grown.IsPlanted;
        maxTime = SeedTime[seedNum] * moreFaster;
        seedNumber = seedNum;

        //UI 변경 (이름 변경 추가)
        plantImage.sprite = sprites[seedNum];
        plantImage.color = new Color(1, 1, 1, 1);
        trans.sizeDelta = new Vector2(400.0f, 400.0f * heightWidth[seedNum]);
        timer.text = string.Format("남은 시간 : {0:00}", maxTime - plantTime);
        plantName.text = string.Format(SeedNames[seedNum]);
    }


    public void CheckPlanted()
    {
        if (IsPlanted == Grown.NotPlanted) 
        {
            GameObject.Find("Farm Canvas").transform.GetChild(1).gameObject.GetComponent<OtherUI>().showit();
        }
        else if (IsPlanted == Grown.IsPlanted)
        {
            watertime = watering;
            //UI 살짝 어둡게 변경 : 물 먹은 땅 느낌으로
            fieldImage.color = new Color(0.8f, 0.8f, 0.8f);
        }
        else if(IsPlanted == Grown.FullGrown)
        {
            //채집
            IsPlanted = Grown.NotPlanted;
            plantName.text = string.Format("빈 밭");
            plantImage.color = new Color(1, 1, 1, 0);
            MainStorage.GetComponent<DrawChange>().getFood(seedNumber);

            //랜덤 함수 써서 추가 수확물
            if (UnityEngine.Random.value <= additionPlant)
            {
                MainStorage.GetComponent<DrawChange>().getFood(seedNumber);
            }
            info.IsCollected(seedNumber+6);
        }
    }

    public void Update()
    {
        if (watertime > 0)
        {
            watertime -= Time.deltaTime;
            plantTime += Time.deltaTime;
            timer.text = string.Format("남은 시간 : {0:00}", maxTime - plantTime);
            if (plantTime > maxTime)
            {
                maxTime = 0; plantTime = 0; watertime = 0;
                IsPlanted = Grown.FullGrown;
                FullGrown();
            }
        }
        else fieldImage.color = new Color(1,1,1);
    }

    public void FullGrown()
    {
        //UI변경
        timer.text = string.Empty;
        plantName.text = string.Format("다 자랐습니다!");
    }
}
