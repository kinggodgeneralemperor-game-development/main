using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "SlimeSO", menuName = "ScriptableObjects/SlimeSO", order = 1)]
public class SlimeSO : ScriptableObject
{
    //�ִ� �ּ� ������
    [SerializeField] private int minX;
    [SerializeField] private int minY;
    [SerializeField] private int maxX;
    [SerializeField] private int maxY;

    //������ ���� ���� �ð�
    [SerializeField] private float minMoveTime;
    [SerializeField] private float maxMoveTime;

    //������ ����
    [SerializeField] private int slimeId;
    [SerializeField] private int mass;
    [SerializeField] private int drag;
    [SerializeField] private float maxHungry;
    [SerializeField] private float scale;

    //�ִϸ��̼�
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private float angleIndex;
    [SerializeField] private GameObject eatEffect;
    //������ �ھ�
    [SerializeField] private CoreSO core;
    [SerializeField] private GameObject basicCore;
    //�����̴�
    [SerializeField] private Image hungryslider;
    [SerializeField] private Slider levelSlider;

    //������ ���ڿ� ������
    [SerializeField] private static GameObject slimeUI;
    [SerializeField] private string slimename;
    [SerializeField] private string slimeinfo;

    [SerializeField] private int maxLevel;

    [SerializeField] private int hungerCooldown;

    //�ִ� �ּ� ������
    public int MinX { get { return minX; } }
    public int MinY { get { return minY; } }
    public int MaxX { get { return maxX; } }
    public int MaxY { get { return maxY; } }

    //������ ���� ���� �ð�
    public float MinMoveTime { get { return minMoveTime; } }
    public float MaxMoveTime { get { return maxMoveTime; } }

    //������ ����
    public int SlimeId { get { return slimeId; } }
    public int Mass { get { return mass; } }
    public int Drag { get { return drag; } }
    public float MaxHungry { get { return maxHungry; } }
    public float Scale { set { scale = value; OnChanged(this, EventArgs.Empty); } get { return scale; } }

    //�ִϸ��̼�
    public Sprite[] Sprites { get { return sprites; } }
    public float AngleIndex { get { return angleIndex; } }

    public GameObject EatEffect { get { return eatEffect; } }
    //������ �ھ�
    public CoreSO Core { get { return core; } }
    public GameObject BasicCore { get { return basicCore; } }
    //�����̴�
    public Image Hungryslider { get { return hungryslider; } }
    public Slider LevelSlider { get { return levelSlider; } }

    //������ ���ڿ� ������
    public static GameObject SlimeUI { get { return slimeUI; } }
    public string Slimename { get { return slimename; } }
    public string Slimeinfo { get { return slimeinfo; } }
    public int MaxLevel { get { return maxLevel; } }

    public event EventHandler OnChanged;
}
