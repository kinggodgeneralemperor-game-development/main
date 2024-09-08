using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SlimeManager : MonoBehaviour
{
    public static List<GameObject> SlimeList;
    public void Start()
    {
        if (SlimeList == null)
            SlimeList = new List<GameObject>();
    }

    public static GameObject RandomSlime()
    {
        GameObject slimepre = null;
        int randomslime = Random.Range(0, 4);
        if (randomslime == 0)
            slimepre = Resources.Load<GameObject>("Normal Slime");
        else if (randomslime == 1)
            slimepre = Resources.Load<GameObject>("Water Slime");
        else if (randomslime == 2)
            slimepre = Resources.Load<GameObject>("Ground Slime");
        else if (randomslime == 3)
            slimepre = Resources.Load<GameObject>("Fire Slime");
        return slimepre;
    }
    public void AddSlime()
    {
        GameObject slime = Instantiate(RandomSlime());
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
}
