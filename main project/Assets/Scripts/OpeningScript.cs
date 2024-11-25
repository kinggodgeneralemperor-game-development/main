using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpeningScript : MonoBehaviour
{
    [SerializeField] GameObject[] list;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(triggerOpeningsquare());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator triggerOpeningsquare()
    {

        for(int i = 0; i < 4; i++)
        {
            for(float j = 0; j <= 10; j++)
            {
                Color temp = list[i].GetComponent<Image>().color;
                temp.a = j / (float)10;
                list[i].GetComponent<Image>().color = temp;
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(2.5f);
        }
        SceneChange.ChangeMainScene();
    }
}
