using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class User : MonoBehaviour
{
    public User instance;

    public static string Username;


    private void Awake()
    {
        instance = this;

        DontDestroyOnLoad(this.gameObject);

        Username = PlayerPrefs.GetString("Username");
    }
}
