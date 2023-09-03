using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBuyability : MonoBehaviour
{
    ExperienceManager experienceManager;
    ShopCostum shopCostum;
    private GameObject Dark, Lock, Cost;
    private void Awake()
    {
        experienceManager = GameObject.FindObjectOfType<ExperienceManager>();
        shopCostum = GetComponentInParent<ShopCostum>();

        Dark = transform.Find("Dark").gameObject;
        Lock = transform.Find("Lock").gameObject;
        Cost = transform.Find("Cost").gameObject;
    }
    private void Start()
    {
        CheckBuyabilityAndLocks();
    }

    private void CheckBuyabilityAndLocks()
    {
        if (shopCostum == null)
        {
            if (shopCostum.experience >= experienceManager.experience)
            {
                shopCostum.buyable = true;
            }
            else
            {
                shopCostum.buyable = false;
            }

            if (shopCostum.buyable)
            {
                Cost.SetActive(true);
                Dark.SetActive(false);
                Lock.SetActive(false);
            }
            else
            {
                Dark.SetActive(true);
                Lock.SetActive(true);
                Cost.SetActive(false);
            }
        }


        
    }
}
