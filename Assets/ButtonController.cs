using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class ButtonController : MonoBehaviour
{
    private Button levelButton;

    [SerializeField] private TMP_Text buttonText;
    [SerializeField] private GameObject lockIconObject, starsIconObject, Panel_Indtroduction;

    public int buttonValue, levelTextValue;
    private bool isComplete;


    private void Start()
    {
        Panel_Indtroduction.SetActive(false);
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
        Panel_Indtroduction.SetActive(true);
        yield return new WaitForSeconds(2f);
        if (isComplete)
        {
            SceneManager.LoadScene(buttonValue);
        }
    }
}