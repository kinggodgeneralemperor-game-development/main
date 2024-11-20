using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingScript : MonoBehaviour
{
    [SerializeField] GameObject[] list;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(triggerEndingsquare());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator triggerEndingsquare()
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
            yield return new WaitForSeconds(3f);
        }
    }
}
