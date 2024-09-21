using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private static float[] heightWidth = new float[5];
    public static GameObject DraggedIcon;
    public static CanvasGroup CanvasGroup;
    public int expPoint;
    public int hungryPoint;
    RectTransform rectTrans;
    public Sprite[] foodSprites = new Sprite[5];
    Image image;

    Vector3 startposition;

    private void Start()
    {
        expPoint = 5;
        hungryPoint = 10;
    }
    private void Awake()
    {
        CanvasGroup = GetComponent<CanvasGroup>();
        image = GetComponent<Image>();
        rectTrans = GetComponent<RectTransform>();

        heightWidth[0] = 19.0f / 15.0f;
        heightWidth[1] = 8.0f / 11.0f;
        heightWidth[2] = 17.0f / 19.0f;
        heightWidth[3] = 11.0f / 12.0f;
        heightWidth[4] = 1;
    }

    public void ChangeFoodImage(int foodNum)
    {
        rectTrans.sizeDelta = new Vector2(120, 120*heightWidth[foodNum]);
        image.sprite = foodSprites[foodNum];
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startposition = this.transform.position;
        CanvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        CanvasGroup.blocksRaycasts = true;
        this.transform.position = startposition;
    }

}
