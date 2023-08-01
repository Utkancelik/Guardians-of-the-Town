using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CivilizationStarManager : MonoBehaviour
{
    public static CivilizationStarManager instance;
    public GameObject[] Improvements;
    public GameObject[] Stars;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {

        CheckStars();    
    }

    public void CheckStars()
    {
        for (int i = 0; i < Improvements.Length; i++)
        {
            int starsNumber = 0;
            for (int j = 0; j < 3; j++)
            {

                GameObject upgrade = Improvements[i].transform.GetChild(j).gameObject;
                CivilizationShopItem civItem = upgrade.GetComponent<CivilizationShopItem>();
                if (civItem.unlocked)
                {
                    starsNumber++;
                }
            }
            Debug.Log(starsNumber);
            Stars[i].transform.GetChild(starsNumber).GetComponent<Image>().enabled = true;
        }
    }
}
