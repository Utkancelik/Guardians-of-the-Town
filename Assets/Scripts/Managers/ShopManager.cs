using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public ExperienceManager experienceManager;
    public static ShopManager instance;

    public GameObject[] shopCostums;
    public GameObject selectedAvatar;
    private void Awake()
    {
        instance = this;

        experienceManager = GameObject.FindObjectOfType<ExperienceManager>();
    }
    private void Start()
    {
        CheckBuyability();

        //AssignAvatar();
    }

    private void CheckBuyability()
    {
        for (int i = 0; i < shopCostums.Length; i++)
        {
            
            if (shopCostums[i].TryGetComponent<ShopCostum>(out var shopCostum))
            {
                

                if (experienceManager.experience >= shopCostum.experience)
                    shopCostum.buyable = true;
                else
                    shopCostum.buyable = false;
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
