using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class ButtonController : MonoBehaviour
{
    private Button levelButton;

    [SerializeField] private TMP_Text buttonText;
    [SerializeField] private GameObject lockIconObject, starsIconObject, Panel_Indtroduction_TR, Panel_Indtroduction_FIN;

    public int buttonValue, levelTextValue;
    private bool isComplete;


    public float delayedLoadSeconds = 10.0f;

    private void Start()
    {
        Panel_Indtroduction_TR.SetActive(false);
        Panel_Indtroduction_FIN.SetActive(false);
        levelButton = GetComponent<Button>();
        levelButton.onClick.AddListener(LoadSelectedScene);
    }


    public void SetLockState()
    {
        isComplete = true;

        if (isComplete)
        {
            buttonText.text = (levelTextValue).ToString();
            lockIconObject.SetActive(false);
            starsIconObject.SetActive(true);
        }
    }



    public void LoadSelectedScene()
    {
        StartCoroutine(DelayedLoad());
    }

    private IEnumerator DelayedLoad()
    {
        if (PlayerPrefs.GetString("Language") == "Turkish")
        {
            Panel_Indtroduction_TR.SetActive(true);
        }
        else if(PlayerPrefs.GetString("Language") == "Finnish")
        {
            Panel_Indtroduction_FIN.SetActive(true);
        }
        yield return new WaitForSeconds(delayedLoadSeconds);
        if (isComplete)
        {
            SceneManager.LoadScene(buttonValue);
        }
    }
}