using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtUsername, txtLevel, txtGoldAmount;

    private void Start()
    {
        txtUsername.text = PlayerPrefs.GetString("Username");
    }
}
