using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarsManager : MonoBehaviour
{
    public GameObject[] stars;

    private void OnEnable()
    {
        if (stars != null && SceneManager.GetActiveScene().name == "Scene_6.0_Easy_MillGameLevels")
        {
            if (PlayerPrefs.GetString("MillGameLevel1") == "true")
                stars[0].SetActive(true);
            if (PlayerPrefs.GetString("MillGameLevel2") == "true")
                stars[1].SetActive(true);
            if (PlayerPrefs.GetString("MillGameLevel3") == "true")
                stars[2].SetActive(true);
            if (PlayerPrefs.GetString("MillGameLevel4") == "true")
                stars[3].SetActive(true);
            if (PlayerPrefs.GetString("MillGameLevel5") == "true")
                stars[4].SetActive(true);
            if (PlayerPrefs.GetString("MillGameLevel6") == "true")
                stars[5].SetActive(true);
            if (PlayerPrefs.GetString("MillGameLevel7") == "true")
                stars[6].SetActive(true);
        }
        else if(stars != null && SceneManager.GetActiveScene().name == "Scene_6.1_Easy_CastleGameLevels")
        {
            if (PlayerPrefs.GetString("CastleGameLevel1") == "true")
                stars[0].SetActive(true);
            if (PlayerPrefs.GetString("CastleGameLevel2") == "true")
                stars[1].SetActive(true);
            if (PlayerPrefs.GetString("CastleGameLevel3") == "true")
                stars[2].SetActive(true);
            if (PlayerPrefs.GetString("CastleGameLevel4") == "true")
                stars[3].SetActive(true);
            if (PlayerPrefs.GetString("CastleGameLevel5") == "true")
                stars[4].SetActive(true);
            if (PlayerPrefs.GetString("CastleGameLevel6") == "true")
                stars[5].SetActive(true);
            if (PlayerPrefs.GetString("CastleGameLevel7") == "true")
                stars[6].SetActive(true);
        }
        else if (stars != null && SceneManager.GetActiveScene().name == "Scene_6.2_Easy_BlacksmithGameLevels")
        {
            if (PlayerPrefs.GetString("BlacksmithGameLevel1") == "true")
                stars[0].SetActive(true);
            if (PlayerPrefs.GetString("BlacksmithGameLevel2") == "true")
                stars[1].SetActive(true);
            if (PlayerPrefs.GetString("BlacksmithGameLevel3") == "true")
                stars[2].SetActive(true);
            if (PlayerPrefs.GetString("BlacksmithGameLevel4") == "true")
                stars[3].SetActive(true);
            if (PlayerPrefs.GetString("BlacksmithGameLevel5") == "true")
                stars[4].SetActive(true);
            if (PlayerPrefs.GetString("BlacksmithGameLevel6") == "true")
                stars[5].SetActive(true);
            if (PlayerPrefs.GetString("BlacksmithGameLevel7") == "true")
                stars[6].SetActive(true);
        }
    }
}
