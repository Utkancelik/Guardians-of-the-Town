using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;
    [SerializeField] private TextMeshProUGUI txtGoldAmount;
    public int money = 12000;

    private void Awake()
    {
        instance = this;

        DontDestroyOnLoad(gameObject);

        
    }

    private void Start()
    {
        UpdateGoldAmount(txtGoldAmount);
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("Money", money);
    }

    public void UpdateGoldAmount(TextMeshProUGUI text)
    {
        money = PlayerPrefs.GetInt("Money", 200);
        text.text = money.ToString();
    }
}