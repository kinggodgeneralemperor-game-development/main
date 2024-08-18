using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class GroundSlimeCore : BasicCore, IPointerClickHandler
{
    public override void CoreClick()
    {
        Debug.Log("fff");
        Destroy(this.gameObject);
        GoldManager.UpdateGold(20);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        CoreClick();
    }
}
