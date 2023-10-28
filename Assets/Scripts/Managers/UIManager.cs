using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Sprite bg1, bg2, bg3, bg4, bg5, bg6, bg7, bg8, selectedBG;
    public GameObject background;
    // gold miktarimizi gosteren textmeshpro
    [SerializeField] private TextMeshProUGUI TMP_goldAmount;
    // tum avatarlari depoledigimiz yer
    public GameObject[] avatars;
    // awake'te tmp componenti ne erisiyorujz
    public void Awake()
    {
        TMP_goldAmount = GameObject.FindGameObjectWithTag("TMP_GoldAmount").GetComponent<TextMeshProUGUI>();
    }
    public void Start()
    {
        int totalUnlockedCivilizationItems = PlayerPrefs.GetInt("UnlockedCivilizations", 1);
        if (totalUnlockedCivilizationItems >= 3)
        {
            selectedBG = bg2;
        }
        else if (totalUnlockedCivilizationItems >= 6)
        {
            selectedBG = bg3;
        }
        else if (totalUnlockedCivilizationItems >= 9)
        {
            selectedBG = bg4;
        }
        else if (totalUnlockedCivilizationItems >= 12)
        {
            selectedBG = bg5;
        }
        else if (totalUnlockedCivilizationItems >= 15)
        {
            selectedBG = bg6;
        }
        else if (totalUnlockedCivilizationItems >= 18)
        {
            selectedBG = bg7;
        }
        else if (totalUnlockedCivilizationItems >= 21)
        {
            selectedBG = bg8;
        }
        else
        {
            selectedBG = bg1;
        }
        if (background != null)
        {
            background.GetComponent<Image>().sprite = selectedBG;
        }
        

        AssignAvatar();
    }

    public void AssignAvatar()
    {
        // avatarlarin hepsini kapat playerprefstekini ac.
        if (avatars.Length != 0)
        {
            foreach (GameObject avatar in avatars)
            {
                avatar.SetActive(false);
            }

            int selectedAvatarIndex = PlayerPrefs.GetInt("SelectedAvatar", 4);
            avatars[selectedAvatarIndex].SetActive(true);

        }
        // para miktarimizi guncelle
        MoneyManager.instance.UpdateGoldAmount(TMP_goldAmount);
    }
}
