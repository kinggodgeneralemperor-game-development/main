using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class NormalSlimeCore : BasicCore, IPointerClickHandler
{
    public override void CoreClick()
    {
        Destroy(this.gameObject);
        GoldManager.UpdateGold(5);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        CoreClick();
    }
}
