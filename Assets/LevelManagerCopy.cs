using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManagerCopy : MonoBehaviour
{
    public static LevelManagerCopy Instance;


    [SerializeField] private List<Button> buttonList = new List<Button>();

    public int activeLevelIndex = 17;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
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
        Debug.Log("Copy Aktif Level Deðeri: " + activeLevelIndex);
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
        if(GameManager.Instance.State == GameManager.GameStates.MillGame)
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
        
    }




    [ContextMenu("Clear")]
    public void Clear()
    {
        PlayerPrefs.DeleteKey("LevelIndex");
    }
}
