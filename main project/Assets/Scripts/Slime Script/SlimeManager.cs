using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SlimeManager : MonoBehaviour
{
    [SerializeField] UpgradeSO UpgradeSO;
    public static List<GameObject> SlimeList;
    public SlimeSO slimeData;
    public GameObject slimeprefab;
    public Info info;
    [SerializeField]
    private List<SlimeSO> slimeSOList;
    public void Start()
    {
        if (SlimeList == null)
            SlimeList = new List<GameObject>();
    }
    public SlimeSO SelectedSlime(int input)
    {
        if (input >= slimeSOList.Count)
            return null;
        return slimeSOList[input];
    }
    public SlimeSO RandomSlime()
    {
        int randomslime = Random.Range(0, slimeSOList.Count);
        return slimeSOList[randomslime];
    }
    public bool AddSlime()
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
    public void OnClick()
    {
        Debug.Log("aa");
    }
    public void Update()
    { 
        Debug.Log(SlimeList.Count);
        //RemoveEmpty();
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
            if (SlimeList[i - 1] == null)
                SlimeList.RemoveAt(i - 1);
        }
    }

    public void upgradeScale(int input)
    {
        for (int i = 0; i < slimeSOList.Count; i++)
            slimeSOList[i].Scale += input;
    }
}
