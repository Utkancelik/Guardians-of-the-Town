using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;

    public GameObject[] shopCostums;
    public GameObject selectedAvatar;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        //CheckLocks();

        AssignAvatar();
    }

    private void CheckLocks()
    {
        for (int i = 0; i < shopCostums.Length; i++)
        {
            
            if (shopCostums[i].TryGetComponent<ShopCostum>(out var shopCostum))
            {
                GameObject lockedElements = shopCostum.lockedElements;

                if (PlayerPrefs.GetInt(shopCostum.isUnlockedPref) == 1)
                    lockedElements.SetActive(false);
                else
                    lockedElements.SetActive(true);
            }
            else
                Debug.LogWarning("ShopCostum componentine eriþemedim!.");
        }
    }

    private void AssignAvatar()
    {
        int selectedIndex = PlayerPrefs.GetInt("SelectedAvatar", 4);
        GameObject g = GameObject.Find("Costums").transform.GetChild(selectedIndex).Find("Costum").gameObject;
        selectedAvatar.GetComponent<Image>().sprite = g.GetComponent<Image>().sprite;
    }

}
