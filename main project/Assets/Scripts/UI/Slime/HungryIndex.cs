using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungryIndex : MonoBehaviour
{
    [SerializeField] GameObject S_goPrefab = null;

    List<Transform> S_objectList = new List<Transform>();
    List<GameObject> S_hungryIndexList = new List<GameObject>();

    // Start is called before the first frame update
    public void CheckSlime()
    {
        GameObject[] temp_objects = GameObject.FindGameObjectsWithTag("Slime");
        for(int i = 0; i < temp_objects.Length; i++)
        {
            S_objectList.Add(temp_objects[i].transform);
            GameObject temp_hungrybar = Instantiate(S_goPrefab, temp_objects[i].transform.position, Quaternion.identity, transform);
            S_hungryIndexList.Add(temp_hungrybar);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < S_objectList.Count; i++)
        {
            S_hungryIndexList[i].transform.position = S_objectList[i].position + new Vector3(0, 100, 0); 
        }
    }
}
