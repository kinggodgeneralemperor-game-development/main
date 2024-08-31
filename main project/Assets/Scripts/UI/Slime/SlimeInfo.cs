using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
public class SlimeInfo : BasicUI
{
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI InfoText;
//  int k;
    public void Start()
    {
//      k = 0;
        NameText = transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        InfoText = transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        gameObject.SetActive(false);
    }
    public void Editname(string input)
    {
        NameText.text = string.Format(input);
    }
    public void Editinfo(string input)
    {
        InfoText.text = string.Format(input);
    }    
}
