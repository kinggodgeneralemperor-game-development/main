using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "SlimeSO", menuName = "ScriptableObjects/SlimeSO", order = 1)]
public class SlimeSO : ScriptableObject
{
    //최대 최소 움직임
    [SerializeField] private int minX;
    [SerializeField] private int minY;
    [SerializeField] private int maxX;
    [SerializeField] private int maxY;

    //움직임 이후 경직 시간
    [SerializeField] private float minMoveTime;
    [SerializeField] private float maxMoveTime;

    //슬라임 정보
    [SerializeField] private int slimeId;
    [SerializeField] private int mass;
    [SerializeField] private int drag;
    [SerializeField] private float maxHungry;
    [SerializeField] private float scale;

    //애니메이션
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private float angleIndex;
    [SerializeField] private GameObject eatEffect;
    //슬라임 코어
    [SerializeField] private CoreSO core;
    [SerializeField] private GameObject basicCore;
    //슬라이더
    [SerializeField] private Image hungryslider;
    [SerializeField] private Slider levelSlider;

    //슬라임 문자열 데이터
    [SerializeField] private static GameObject slimeUI;
    [SerializeField] private string slimename;
    [SerializeField] private string slimeinfo;

    [SerializeField] private int maxLevel;

    [SerializeField] private int hungerCooldown;

    //최대 최소 움직임
    public int MinX { get { return minX; } }
    public int MinY { get { return minY; } }
    public int MaxX { get { return maxX; } }
    public int MaxY { get { return maxY; } }

    //움직임 이후 경직 시간
    public float MinMoveTime { get { return minMoveTime; } }
    public float MaxMoveTime { get { return maxMoveTime; } }

    //슬라임 정보
    public int SlimeId { get { return slimeId; } }
    public int Mass { get { return mass; } }
    public int Drag { get { return drag; } }
    public float MaxHungry { get { return maxHungry; } }
    public float Scale { set { scale = value; OnChanged(this, EventArgs.Empty); } get { return scale; } }

    //애니메이션
    public Sprite[] Sprites { get { return sprites; } }
    public float AngleIndex { get { return angleIndex; } }

    public GameObject EatEffect { get { return eatEffect; } }
    //슬라임 코어
    public CoreSO Core { get { return core; } }
    public GameObject BasicCore { get { return basicCore; } }
    //슬라이더
    public Image Hungryslider { get { return hungryslider; } }
    public Slider LevelSlider { get { return levelSlider; } }

    //슬라임 문자열 데이터
    public static GameObject SlimeUI { get { return slimeUI; } }
    public string Slimename { get { return slimename; } }
    public string Slimeinfo { get { return slimeinfo; } }
    public int MaxLevel { get { return maxLevel; } }

    public event EventHandler OnChanged;
}
