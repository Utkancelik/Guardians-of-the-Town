using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UserManager : MonoBehaviour
{
    [SerializeField] private GameObject selectUserScreen, usersMenuScreen, objUser_1;
    [SerializeField] private TMP_InputField newUserInputField;

    private void Start()
    {

    }
    public void OpenUserSelectionMenu()
    {
        string username = PlayerPrefs.GetString("Username");
        if (username.Length >= 1)
        {
            usersMenuScreen.SetActive(false);
            selectUserScreen.SetActive(true);

            Transform text = objUser_1.transform.GetChild(0);
            text.GetComponent<TextMeshProUGUI>().text = username;
        }
    }

    public void SelectUser()
    {
        
    }

    public void NewUser()
    {
        PlayerPrefs.SetString("Username", newUserInputField.text);
        int userCount = PlayerPrefs.GetInt("UserCount");
        PlayerPrefs.SetInt("UserCount", userCount + 1);
    }
}
