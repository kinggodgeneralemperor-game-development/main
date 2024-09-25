using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SlimeManager : MonoBehaviour
{
    public static List<GameObject> SlimeList;
    public SlimeSO slimeData;
    public GameObject slimeprefab;
    [SerializeField]
    private List<SlimeSO> slimeSOList;
    public void Start()
    {
        if (SlimeList == null)
            SlimeList = new List<GameObject>();
    }

    public SlimeSO RandomSlime()
    {
        int randomslime = Random.Range(0, slimeSOList.Count);
        return slimeSOList[randomslime];
    }
    public void AddSlime()
    {
        GameObject slime = Instantiate(slimeprefab);
        var slimescript = slime.GetComponent<basicslime>();
        slimescript.SO = RandomSlime();
        slime.transform.position = Vector3.zero;
        SlimeList.Add(slime);
    }
    public void OnClick()
    {
        Debug.Log("aa");
    }
    public void Update()
    { 
        Debug.Log(SlimeList.Count);
        RemoveEmpty();
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
