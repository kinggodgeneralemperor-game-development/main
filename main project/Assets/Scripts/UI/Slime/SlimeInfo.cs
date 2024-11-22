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
    private Slider LevelSlider;
    private TextMeshProUGUI ExpText;
    private Image HungrySlider;
    private TextMeshProUGUI HungryText;
    private Button EvolutionButton;
    private TextMeshProUGUI EatenFoods;
    private GameObject gObj;
    private basicslime gObjS;
    private SlimeManager slimemanager;

//  int k;
    public void Start()
    {
        slimemanager = GameObject.Find("SlimeManager").GetComponent<SlimeManager>();
        if (slimemanager)
            Debug.Log(slimemanager.name);
        NameText = transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        InfoText = transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        LevelText = transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
        InfoSprite = transform.GetChild(3).gameObject.GetComponent<Image>();
        LevelSlider = transform.GetChild(4).gameObject.GetComponent<Slider>();
        ExpText = transform.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>();
        HungrySlider = transform.GetChild(6).gameObject.GetComponent<Image>();
        HungryText = transform.GetChild(7).gameObject.GetComponent<TextMeshProUGUI>();
        EvolutionButton = transform.GetChild(8).gameObject.GetComponent<Button>();
        EatenFoods = transform.GetChild(9).gameObject.GetComponent<TextMeshProUGUI>();
        EvolutionButton.gameObject.SetActive(false);
       
        gameObject.SetActive(false);
    }
    private void Update()
    {
        if (gObj)
        {
            NameText.text = string.Format(gObjS.SO.Slimename);
            InfoText.text = string.Format(gObjS.SO.Slimeinfo);
            LevelText.text = string.Format("Level : " + gObjS.level);
            InfoSprite.sprite = gObjS.SO.Sprites[2];
            LevelSlider.value = gObjS.exp;
            if (gObjS.level < gObjS.SlimeMaxLVinfo())
                ExpText.text = string.Format(gObjS.exp + " / " + gObjS.MaxExp);
            else
                ExpText.text = string.Format("Max Level");
            HungrySlider.fillAmount = gObjS.hungryslider.fillAmount;
            HungryText.text = string.Format("Hungry : {0:0.0} / {1:0}", gObjS.hungryindex, gObjS.MaxHungry);

            string EatenFoodstemp = string.Format("[");
            for (int i = 0; i < 6; i++) {
                EatenFoodstemp += string.Format("{0}", gObjS.Eats[i]);
                if (i != 5)
                    EatenFoodstemp += string.Format(" / ");
                else
                    EatenFoodstemp += string.Format("]");
            
            }
            EatenFoods.text = EatenFoodstemp;
            EvolutionButton.gameObject.SetActive(gObjS.SlimeEvolutionable());
        }
        else
            hideit();
    }
    public void getGameObject(GameObject input)
    {
        gObj = input;
        gObjS = gObj.GetComponent<basicslime>();
    }
    public void Evolutionbutton()
    {
        SlimeSO temp = slimemanager.SelectedSlime(gObjS.SO.SlimeId + 1);
        if (temp)
        {
            gObjS.SlimeEvolutiontrigger();
        }
    }
    public void Editname(string input)
    {
        //NameText.text = string.Format(input);
    }
    public void Editinfo(string input)
    {
        //InfoText.text = string.Format(input);
    }    
    public void Editlevel(int input)
    {
        //LevelText.text = string.Format("Level : " + input);
    }
    public void EditSprite(Sprite input)
    {
        //InfoSprite.sprite = input;
    }
}
