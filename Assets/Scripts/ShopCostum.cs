using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopCostum : MonoBehaviour, IPointerClickHandler
{
    // 0 = locked, 1 = unlocked
    public string isUnlockedPref;

    public bool buyable = false;
    public GameObject lockedElements;
    public int costumIndex;
    public int costumCost = 870;
    private void Start()
    {
        if (isUnlockedPref == "Default")
            PlayerPrefs.SetInt(isUnlockedPref, 1);

        if (PlayerPrefs.GetInt(isUnlockedPref) == 1)
            lockedElements.SetActive(false);
        else
            lockedElements.SetActive(true);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject selectedCostum = eventData.pointerClick;

        if (PlayerPrefs.GetInt(isUnlockedPref) == 1)
        {
            Sprite image = selectedCostum.transform.Find("Costum").GetComponent<Image>().sprite;
            ShopManager.instance.selectedAvatar.GetComponent<Image>().sprite = image;
            PlayerPrefs.SetInt("SelectedAvatar", costumIndex);
        }
        else if (PlayerPrefs.GetInt(isUnlockedPref) == 0 && buyable)
        {
            if (MoneyManager.instance.money >= costumCost)
            {
                MoneyManager.instance.money -= costumCost;
                PlayerPrefs.SetInt("Money", MoneyManager.instance.money);

                Sprite image = selectedCostum.transform.Find("Costum").GetComponent<Image>().sprite;
                ShopManager.instance.selectedAvatar.GetComponent<Image>().sprite = image;
                PlayerPrefs.SetInt("SelectedAvatar", costumIndex);

                lockedElements.SetActive(false);
                buyable = false;

                // it is unlocked
                PlayerPrefs.SetInt(isUnlockedPref, 1);
            }
        }
    }
}
