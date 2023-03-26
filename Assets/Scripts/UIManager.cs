using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtUsername, txtLevel, txtGoldAmount;

    public GameObject[] avatars;
    private void Start()
    {
        txtUsername.text = PlayerPrefs.GetString("Username");

        foreach (GameObject avatar in avatars)
        {
            avatar.SetActive(false);
        }

        int selectedAvatarIndex = PlayerPrefs.GetInt("SelectedAvatar");
        avatars[selectedAvatarIndex].SetActive(true);
    }
}
