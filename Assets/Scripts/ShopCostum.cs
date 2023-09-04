using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public enum CostumLevels
{
    Level1,
    Level2,
    Level3,
    Level4,
}
public class ShopCostum : MonoBehaviour, IPointerClickHandler
{
    public GameObject checkBuyability;
    public ExperienceManager experienceManager;
    public int experience = 0;
    public CostumLevels costumLevel;
    UIManager uiManager;

    // 0 = locked, 1 = unlocked
    public string isUnlockedPref;

    public bool buyable = false;
    public GameObject lockedElements;
    public int costumIndex;
    public int costumCost = 870;
    private void Awake()
    {
        checkBuyability = transform.Find("Off").gameObject;
        experienceManager = GameObject.FindObjectOfType<ExperienceManager>();
        uiManager = GameObject.FindObjectOfType<UIManager>();
    }
    private void Start()
    {
        if (isUnlockedPref == "Default")
            PlayerPrefs.SetInt(isUnlockedPref, 1);

        if (PlayerPrefs.GetInt(isUnlockedPref) == 1)
            lockedElements.SetActive(false);
        else
            lockedElements.SetActive(true);

        if (checkBuyability != null && checkBuyability.activeInHierarchy)
            checkBuyability.GetComponent<CheckBuyability>().CheckBuyabilityAndLocks(); Debug.Log("g");

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject selectedCostum = eventData.pointerClick;
        ShopCostum shopCostum = selectedCostum.GetComponent<ShopCostum>();

        if (PlayerPrefs.GetInt(isUnlockedPref) == 1)
        {
            PlayerPrefs.SetInt("SelectedAvatar", shopCostum.costumIndex);
            uiManager.AssignAvatar();
        }
        else if (PlayerPrefs.GetInt(isUnlockedPref) == 0 && buyable)
        {
            if (MoneyManager.instance.money >= costumCost)
            {
                MoneyManager.instance.money -= costumCost;
                PlayerPrefs.SetInt("Money", MoneyManager.instance.money);


                PlayerPrefs.SetInt("SelectedAvatar", shopCostum.costumIndex);
                uiManager.AssignAvatar();


                shopCostum.lockedElements.SetActive(false);
                shopCostum.buyable = false;

                // it is unlocked
                PlayerPrefs.SetInt(shopCostum.isUnlockedPref, 1);
            }
        }
    }
}
