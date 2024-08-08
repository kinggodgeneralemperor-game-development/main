using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class timeManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    // Start is called before the first frame update
    void Start()
    {
        timeText.text = string.Format("{0:0.00}", timedata.Gettime());
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = string.Format("{0:00} : {1:00}", timedata.Gethour(),timedata.Getminute());
    }
}
