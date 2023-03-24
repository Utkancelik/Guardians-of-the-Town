using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;
    public GameObject[] shopCostums;
    public GameObject selectedAvatar;
    public int goldAmount = 12000;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        CheckLocks();

        int selectedIndex = PlayerPrefs.GetInt("SelectedAvatar");
        GameObject g = GameObject.Find("Costums").transform.GetChild(selectedIndex).Find("Costum").gameObject;
        selectedAvatar.GetComponent<Image>().sprite = g.GetComponent<Image>().sprite;
    }

    private void CheckLocks()
    {
        for (int i = 0; i < shopCostums.Length; i++)
        {
            ShopCostum shopCostum = shopCostums[i].GetComponent<ShopCostum>();
            GameObject lockedElements = shopCostum.lockedElements;

            if (!shopCostum.locked)
            {
                lockedElements.SetActive(false);
            }
            else
            {
                lockedElements.SetActive(true);
            }
                

        }
    }

    private void AssignAvatar()
    {
        int selectedIndex = PlayerPrefs.GetInt("SelectedAvatar");
        GameObject g = GameObject.Find("Costums").transform.GetChild(selectedIndex).Find("Costum").gameObject;
        selectedAvatar.GetComponent<Image>().sprite = g.GetComponent<Image>().sprite;
    }

}
