using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;
    public int money = 12000;

    private void Awake()
    {
        instance = this;

        DontDestroyOnLoad(gameObject);
    }
}
