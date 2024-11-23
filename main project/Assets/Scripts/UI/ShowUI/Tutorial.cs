using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] Sprite[] sprites = new Sprite[17];
    Image showImage;
    int SlideNum = 0;
    void Start()
    {
        showImage = GetComponent<Image>();
        showImage.sprite = sprites[SlideNum];
    }



    public void nextSlide()
    {
        if (SlideNum < 16)
        {
            SlideNum++;
            showImage.sprite = sprites[SlideNum];
        }
        else 
        { 
            SceneChange.ChangeMainScene();
        }
    }
    public void prevSlide() 
    { 
        if(SlideNum > 0)
        {
            SlideNum--;
            showImage.sprite = sprites[SlideNum];
        }
    }
}
