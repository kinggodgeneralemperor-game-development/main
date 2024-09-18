using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BasicCore : MonoBehaviour, IPointerClickHandler
{
    public Rigidbody2D coreRigidbody;
    public SpriteRenderer coreSpriteRenderer;
    public Sprite temp;
    public CoreSO SO; 
    public void Start()
    {
        coreRigidbody = GetComponent<Rigidbody2D>();
        coreSpriteRenderer = GetComponent<SpriteRenderer>();
        coreRigidbody.AddForce(new Vector2(20, 80));
        coreRigidbody.drag = 3;
        coreSpriteRenderer.sprite = SO.CoreSprite;
        Invoke("RemoveGravity", 1);
    }
    public void RemoveGravity()
    {
        coreRigidbody.gravityScale = 0;
        coreRigidbody.velocity.Set(0, 0);
    }

    public void CoreDestroy()
    {
        Debug.Log("de");
        Destroy(this.gameObject);
    }

    public void CoreClick()
    {
        Destroy(this.gameObject);
        GoldManager.UpdateGold(SO.CorePrice);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        CoreClick();
    }
}
