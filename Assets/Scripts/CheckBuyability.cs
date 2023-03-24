using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBuyability : MonoBehaviour
{
    ShopCostum shopCostum;
    private GameObject Dark, Lock, Cost;
    private void Start()
    {
        shopCostum  = GetComponentInParent<ShopCostum>();
        Dark = transform.Find("Dark").gameObject;
        Lock = transform.Find("Lock").gameObject;
        Cost = transform.Find("Cost").gameObject;

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
