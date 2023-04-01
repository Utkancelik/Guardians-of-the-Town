using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtUsername, txtLevel;

    public GameObject[] avatars;
    private void Start()
    {
        txtUsername.text = PlayerPrefs.GetString("Username");


        if (avatars.Length != 0)
        {
            foreach (GameObject avatar in avatars)
            {
                avatar.SetActive(false);
            }

            int selectedAvatarIndex = PlayerPrefs.GetInt("SelectedAvatar",4);
            avatars[selectedAvatarIndex].SetActive(true);

        }

        MoneyManager.instance.UpdateGoldAmount(GameObject.Find("TxtGoldAmount").GetComponent<TextMeshProUGUI>());
    }
}
