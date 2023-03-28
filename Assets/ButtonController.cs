using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonController : MonoBehaviour
{
    private Button levelButton;

    [SerializeField] private TMP_Text buttonText;
    [SerializeField] private GameObject lockIconObject;

    public int buttonValue;
    private bool isComplete;


    private void Start()
    {
        levelButton = GetComponent<Button>();
        levelButton.onClick.AddListener(LoadSelectedScene);
    }


    public void SetLockState()
    {
        isComplete = true;

        if (isComplete)
        {
            buttonText.text = buttonValue.ToString();
            lockIconObject.SetActive(false);
        }
    }



    public void LoadSelectedScene()
    {
        if (isComplete)
        {
            SceneManager.LoadScene(buttonValue);
        }
    }
}