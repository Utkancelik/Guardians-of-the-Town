using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilizationShopManager : MonoBehaviour
{
    public GameObject[] upgrades;
    public GameObject firstUpgrade;
    private void Start()
    {
        foreach (GameObject upgrade in upgrades)
        {
            GameObject lockedElements = upgrade.transform.GetChild(0).gameObject;
            CivilizationShopItem civItem = upgrade.GetComponent<CivilizationShopItem>();

            if (PlayerPrefs.GetInt(civItem.playerPrefsName) == 1)
            {
                lockedElements.SetActive(false);
                upgrade.GetComponent<CivilizationShopItem>().unlocked = true;
            }
            else
            {
                lockedElements.SetActive(true);
                upgrade.GetComponent<CivilizationShopItem>().unlocked = false;
            }
        }

        firstUpgrade.SetActive(false);
        firstUpgrade.GetComponentInParent<CivilizationShopItem>().unlocked = true;


        
    }

    
}
