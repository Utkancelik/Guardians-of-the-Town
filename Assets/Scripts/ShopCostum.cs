using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopCostum : MonoBehaviour, IPointerClickHandler
{
    public bool locked = true, buyable = false;
    public GameObject lockedElements;
    public int costumIndex;
    public int costumCost = 870;
    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject selectedCostum = eventData.pointerClick;
        if (!locked)
        {
            Sprite image = selectedCostum.transform.Find("Costum").GetComponent<Image>().sprite;
            ShopManager.instance.selectedAvatar.GetComponent<Image>().sprite = image;
            PlayerPrefs.SetInt("SelectedAvatar", costumIndex);
        }

        if (locked && buyable)
        {
            int goldAmount = ShopManager.instance.goldAmount;
            ShopCostum shopCostum = selectedCostum.GetComponent<ShopCostum>();
            if (goldAmount >= shopCostum.costumCost)
            {
                goldAmount -= shopCostum.costumCost;

            }
        }
    }
}
