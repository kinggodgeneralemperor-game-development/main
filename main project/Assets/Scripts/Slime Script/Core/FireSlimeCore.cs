using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class FireSlimeCore : BasicCore, IPointerClickHandler
{
    public override void CoreClick()
    {
        Debug.Log("fff");
        Destroy(this.gameObject);
        GoldManager.UpdateGold(10);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        CoreClick();
    }
}
