using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CivilizationShopItem : MonoBehaviour, IPointerClickHandler
{
    public bool unlocked = false;
    public int cost;
    public string playerPrefsName;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!unlocked)
        {
            if (MoneyManager.instance.money >= cost)
            {
                unlocked = true;
                GameObject g = eventData.pointerClick;
                g.transform.GetChild(0).gameObject.SetActive(false);
                PlayerPrefs.SetInt(playerPrefsName, 1);
                CivilizationStarManager.instance.CheckStars();
                MoneyManager.instance.money -= cost;
                PlayerPrefs.SetInt("Money", MoneyManager.instance.money);
            }
        }
    }

    
}
