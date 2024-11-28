using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SlimeManager : MonoBehaviour
{
    [SerializeField] UpgradeSO _UpgradeSO;
    public Info _info;
    [SerializeField] GameObject _slimeprefab;
    [SerializeField] List<SlimeSO> _SlimeSOList;
    static UpgradeSO UpgradeSO;
    public static List<GameObject> SlimeList;
    public SlimeSO slimeData;
    public static GameObject slimeprefab;
    public static Info info;
    public static List<SlimeSO> SlimeSOList;
    public void Start()
    {
        info = _info;
        UpgradeSO = _UpgradeSO;
        slimeprefab = _slimeprefab;
        SlimeSOList = _SlimeSOList;
        if (SlimeList == null)
            SlimeList = new List<GameObject>();
    }
    public SlimeSO SelectedSlime(int input)
    {
        if (input >= SlimeSOList.Count)
            return null;
        return SlimeSOList[input];
    }
    public static SlimeSO RandomSlime()
    {
        //int randomslime = Random.Range(0, SlimeSOList.Count);
        int randomslime = 1;
        return SlimeSOList[randomslime];
    }
    public static bool AddSlime()
    {
        if(SlimeList.Count >= UpgradeSO.SlimeMax)
        {
            Debug.Log("슬라임이 너무 많습니다");
            return false;
        }
        GameObject slime = Instantiate(slimeprefab);
        var slimescript = slime.GetComponent<basicslime>();
        slimescript.SO = RandomSlime();
        slime.transform.position = Vector3.zero;
        SlimeList.Add(slime);
        info.IsCollected(slimescript.SO.SlimeId);

        return true;
    }
    public bool AddSlime(SlimeSO input)
    {
        if (SlimeList.Count >= UpgradeSO.SlimeMax)
        {
            Debug.Log("슬라임이 너무 많습니다");
            return false;
        }
        if (!input)
        {
            Debug.Log("슬라임이 없습니다");
            return false;
        }
        GameObject slime = Instantiate(slimeprefab);
        var slimescript = slime.GetComponent<basicslime>();
        slimescript.SO = input;
        slime.transform.position = Vector3.zero;
        SlimeList.Add(slime);
        info.IsCollected(slimescript.SO.SlimeId);

        return true;
    }
    public static bool AddSlime(int input)
    {
        if (SlimeList.Count >= UpgradeSO.SlimeMax)
        {
            Debug.Log("슬라임이 너무 많습니다");
            return false;
        }
        if (input >= SlimeSOList.Count)
        {
            Debug.Log("슬라임이 없습니다");
            return false;
        }
        GameObject slime = Instantiate(slimeprefab);
        var slimescript = slime.GetComponent<basicslime>();
        slimescript.SO = SlimeSOList[input];
        slime.transform.position = Vector3.zero;
        SlimeList.Add(slime);
        info.IsCollected(slimescript.SO.SlimeId);

        return true;
    }
    public void OnClick()
    {
        Debug.Log("aa");
    }
    public void Update()
    { 
        Debug.Log(SlimeList.Count);
        //RemoveEmpty();
    }
    public int GetSlimeId()
    {
        return slimeData.SlimeId;
    }
    public static int GetSlimeNumber()
    {
        return SlimeList.Count;
    }
    public static void RemoveEmpty()
    {
        Debug.Log(SlimeList.Count);
        for (int i = SlimeList.Count; i > 0; i--)
        {
            if (!(SlimeList[i - 1]) || SlimeList[i-1].GetComponent<basicslime>().isdeleted)
            {
                SlimeList.RemoveAt(i - 1);
            }
        }
    }

    public void upgradeScale(int input)
    {
        for (int i = 0; i < SlimeSOList.Count; i++)
            SlimeSOList[i].Scale += input;
    }
}
