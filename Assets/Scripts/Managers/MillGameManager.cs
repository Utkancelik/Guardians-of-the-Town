using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MillGameManager : MonoBehaviour
{
    public GameObject matchingSlot1, matchingSlot2;
    public static MillGameManager Instance;

    GameObject slotItem1, slotItem2;
    DraggableItem draggableItem1, draggableItem2;

    public int score = 0;
    public GameObject winPanel;

    public GameObject[] _Tr_Objects;
    public GameObject[] _Fin_Objects;

    public AudioSource wrongSound, correctSound, endGameSound;
    private void Awake()
    {
        Instance = this;
        winPanel.SetActive(false);
    }

    private void Start()
    {
        if (PlayerPrefs.GetString("Language") == "Turkish")
        {
            foreach (GameObject item in _Fin_Objects)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in _Tr_Objects)
            {
                item.SetActive(true);
            }
        }
        else if (PlayerPrefs.GetString("Language") == "Finnish")
        {
            foreach (GameObject item in _Tr_Objects)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in _Fin_Objects)
            {
                item.SetActive(true);
            }
            
        }
    }

    public void CheckSlotItems()
    {
        slotItem1 = matchingSlot1.transform.GetChild(0).gameObject;
        slotItem2 = matchingSlot2.transform.GetChild(0).gameObject;

        draggableItem1 = slotItem1.GetComponent<DraggableItem>();
        draggableItem2 = slotItem2.GetComponent<DraggableItem>();

        if (slotItem1.name[0] == slotItem2.name[0])
        {
            StartCoroutine(TrueMatch());
        }
        else
        {
            StartCoroutine(WrongMatch());
        }

    }

    private IEnumerator TrueMatch()
    {
        yield return new WaitForSeconds(1);
        Destroy(slotItem1);
        Destroy(slotItem2);
        correctSound.Play();
        yield return new WaitForSeconds(.1f);
        int items = GameObject.FindGameObjectsWithTag("Item").Length;

        if (items == 0)
        {
            Win();
        }

    }

    private IEnumerator WrongMatch()
    {
        yield return new WaitForSeconds(1);
        wrongSound.Play();

        draggableItem1.parentAfterDrag = draggableItem1.originalParent;
        draggableItem2.parentAfterDrag = draggableItem2.originalParent;

        draggableItem1.transform.SetParent(draggableItem1.parentAfterDrag);
        draggableItem2.transform.SetParent(draggableItem2.parentAfterDrag);
    }

    private void Win()
    {
        endGameSound.Play();
        winPanel.SetActive(true);
        PlayerPrefs.SetString("MillGameLevel1", "true");
        //MoneyManager.instance.money += 125;
    }
}