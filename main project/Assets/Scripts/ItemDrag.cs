using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject DraggedIcon;
    public static CanvasGroup CanvasGroup;
    public int expPoint;
    public int hungryPoint;
    public Sprite foodSprite;

    Vector3 startposition;

    private void Start()
    {
        expPoint = 5;
        hungryPoint = 10;
    }
    private void Awake()
    {
        CanvasGroup = GetComponent<CanvasGroup>();
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
