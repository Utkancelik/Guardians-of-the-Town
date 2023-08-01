using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;


    [SerializeField] private List<Button> buttonList = new List<Button>();

    public int activeLevelIndex = 17;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
    
    private void Start()
    {
        LoadCompleteLevels();
        CheckAllButtons();
        Debug.Log("Aktif Level Deðeri: " + activeLevelIndex);
    }



    public void CheckAllButtons()
    {
        for (int i = 0; i < buttonList.Count; i++)
        {
            if (activeLevelIndex >= buttonList[i].GetComponent<ButtonController>().buttonValue)
            {
                buttonList[i].GetComponent<ButtonController>().SetLockState();
            }
        }
    }



    public void LoadCompleteLevels()
    {
        if (PlayerPrefs.GetInt("LevelIndex") == 0)
        {
            activeLevelIndex = 17;
        }
        else
        {
            activeLevelIndex = PlayerPrefs.GetInt("LevelIndex");
        }
    }



    public void SaveActiveLevelIndex()
    {
        activeLevelIndex++;
        PlayerPrefs.SetInt("LevelIndex", activeLevelIndex);
    }



    [ContextMenu("Clear")]
    public void Clear()
    {
        PlayerPrefs.DeleteKey("LevelIndex");
    }
}