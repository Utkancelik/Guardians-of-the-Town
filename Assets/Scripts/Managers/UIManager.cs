using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
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
