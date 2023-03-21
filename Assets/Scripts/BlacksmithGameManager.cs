using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlacksmithGameManager : MonoBehaviour
{
    public static BlacksmithGameManager Instance;
    private int trueSlotNumber = 0;
    public GameObject[] slots;
    public GameObject winPanel;
    private void Awake()
    {
        Instance = this;
        winPanel.SetActive(false);
    }
    public void CheckSlotContext(GameObject obj)
    {
        BlacksmithGameObject blacksmithGameObject = obj.GetComponent<BlacksmithGameObject>();
        
        
        if (blacksmithGameObject.type == BlacksmithGameObject.Class.Koy)
        {
            if (!blacksmithGameObject.isClicked)
            {
                blacksmithGameObject.isClicked = true;
                obj.GetComponent<Image>().color = Color.green;
                trueSlotNumber++;
            }

            if (trueSlotNumber == 3)
            {
                StartCoroutine(TrueSelection());
            }

        }   
        else
        {
            
            StartCoroutine(WrongSelection(obj));
        }
            
    }
    private void Update()
    {
        Debug.Log(trueSlotNumber);
    }
    private IEnumerator WrongSelection(GameObject obj)
    {
        obj.GetComponent<Image>().color = Color.red;
        trueSlotNumber = 0;
        yield return new WaitForSeconds(.5f);
        for (int i = 0; i < slots.Length; i++)
        {
            GameObject g = slots[i].transform.GetChild(0).gameObject;
            g.GetComponent<Image>().color = Color.white;  
            BlacksmithGameObject blacksmith = g.GetComponent<BlacksmithGameObject>();
            blacksmith.isClicked = false;
        }

    }

    private IEnumerator TrueSelection()
    {

        yield return new WaitForSeconds(.5f);
        PlayerPrefs.SetString("BlacksmithGameLevel1", "true");
        winPanel.SetActive(true);

    }

}
