using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
public class SlimeInfo : BasicUI
{
    private TextMeshProUGUI NameText;
    private TextMeshProUGUI InfoText;
    private TextMeshProUGUI LevelText;
    private Image InfoSprite;
//  int k;
    public void Start()
    {
//      k = 0;
        NameText = transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        InfoText = transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        LevelText = transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
        InfoSprite = transform.GetChild(3).gameObject.GetComponent<Image>();
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
    public void Editlevel(int input)
    {
        LevelText.text = string.Format("Level : " + input);
    }
    public void EditSprite(Sprite input)
    {
        InfoSprite.sprite = input;
    }
}
