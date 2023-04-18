using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CastleGameManager : MonoBehaviour
{
    public static CastleGameManager instance;

    public GameObject[] slots;

    public GameObject winPanel;

    DraggableItem draggableItem1, draggableItem2, draggableItem3, draggableItem4, draggableItem5;

    public AudioSource audioSource_TR, audioSource_FIN, correctSound, wrongSound, endGameSound;
    private void Awake()
    {
        instance = this;
        winPanel.SetActive(false);
    }

    private void Start()
    {
        if (PlayerPrefs.GetString("Language") == "Turkish")
        {
            GameObject.Find("Agac").gameObject.SetActive(false);
            GameObject.Find("Cay").gameObject.SetActive(true);
        }
        else if (PlayerPrefs.GetString("Language") == "Finnish")
        {
            GameObject.Find("Cay").gameObject.SetActive(false);
            GameObject.Find("Agac").gameObject.SetActive(true);
        }
    }
    public void CheckSlotsOrder()
    {
        

        draggableItem1 = slots[0].transform.GetChild(0).GetComponent<DraggableItem>();
        draggableItem2 = slots[1].transform.GetChild(0).GetComponent<DraggableItem>();
        draggableItem3 = slots[2].transform.GetChild(0).GetComponent<DraggableItem>();
        draggableItem4 = slots[3].transform.GetChild(0).GetComponent<DraggableItem>();
        draggableItem5 = slots[4].transform.GetChild(0).GetComponent<DraggableItem>();
        if (PlayerPrefs.GetString("Language") == "Turkish")
        {
            if (slots[0].transform.GetChild(0).name == "Kus" &&
                    slots[1].transform.GetChild(0).name == "Cay" &&
                    slots[2].transform.GetChild(0).name == "Dis" &&
                    slots[3].transform.GetChild(0).name == "Muz" &&
                    slots[4].transform.GetChild(0).name == "Bal")
            {
                endGameSound.Play();
                winPanel.SetActive(true);
                PlayerPrefs.SetString("CastleGameLevel1", "true");
            }
            else
            {
                winPanel.SetActive(false);
                StartCoroutine(WrongMatch());
            }
        }
        else if (PlayerPrefs.GetString("Language") == "Finnish")
        {
            if (slots[0].transform.GetChild(0).name == "Kus" &&
                    slots[1].transform.GetChild(0).name == "Agac" &&
                    slots[2].transform.GetChild(0).name == "Dis" &&
                    slots[3].transform.GetChild(0).name == "Muz" &&
                    slots[4].transform.GetChild(0).name == "Bal")
            {
                endGameSound.Play();
                winPanel.SetActive(true);
                PlayerPrefs.SetString("CastleGameLevel1", "true");
            }
            else
            {
                winPanel.SetActive(false);
                StartCoroutine(WrongMatch());
            }
        }
        
        
    }

    private IEnumerator WrongMatch()
    {
        yield return new WaitForSeconds(1);
        wrongSound.Play();

        draggableItem1.parentAfterDrag = draggableItem1.originalParent;
        draggableItem2.parentAfterDrag = draggableItem2.originalParent;
        draggableItem3.parentAfterDrag = draggableItem3.originalParent;
        draggableItem4.parentAfterDrag = draggableItem4.originalParent;
        draggableItem5.parentAfterDrag = draggableItem5.originalParent;
        

        draggableItem1.transform.SetParent(draggableItem1.parentAfterDrag);
        draggableItem2.transform.SetParent(draggableItem2.parentAfterDrag);
        draggableItem3.transform.SetParent(draggableItem3.parentAfterDrag);
        draggableItem4.transform.SetParent(draggableItem4.parentAfterDrag);
        draggableItem5.transform.SetParent(draggableItem5.parentAfterDrag);

        if (PlayerPrefs.GetString("Language") == "Turkish")
        {
            audioSource_TR.Play();
        }
        else if (PlayerPrefs.GetString("Language") == "Finnish")
        {
            audioSource_FIN.Play();
        }


    }
}
