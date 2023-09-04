using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum MillGameModes
{
    FirstLetter,
    LastLetter,
    Rhyme
}
public class MillGameManager : MonoBehaviour
{
    private TextMeshProUGUI millGameMode_Txt;
    RandomItemGenerator randomItemGenerator;

    // ilk harf, son harf ya da okunus sekli modlarindan birini sececegiz
    public MillGameModes millGameMode;

    public GameObject matchingSlot1, matchingSlot2;
    public static MillGameManager Instance;

    GameObject slotItem1, slotItem2;
    DraggableItem draggableItem1, draggableItem2;

    public int score = 0;
    public GameObject winPanel;

    public AudioSource wrongSound, correctSound, endGameSound;
    private void Awake()
    {
        Instance = this;
        winPanel.SetActive(false);
        randomItemGenerator = GameObject.FindObjectOfType<RandomItemGenerator>();
        millGameMode_Txt = GameObject.FindGameObjectWithTag("MillGameModeTxt").GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        GameMode();
    }

    public void CheckSlotItems()
    {
        slotItem1 = matchingSlot1.transform.GetChild(0).gameObject;
        slotItem2 = matchingSlot2.transform.GetChild(0).gameObject;

        draggableItem1 = slotItem1.GetComponent<DraggableItem>();
        draggableItem2 = slotItem2.GetComponent<DraggableItem>();

        switch (millGameMode)
        {
            case MillGameModes.FirstLetter:
                if (slotItem1.name[0] == slotItem2.name[0])
                    StartCoroutine(TrueMatch());
                else
                    StartCoroutine(WrongMatch());
                break;
            case MillGameModes.LastLetter:
                if (slotItem1.name[^8] == slotItem2.name[^8])
                    StartCoroutine(TrueMatch());
                else
                    StartCoroutine(WrongMatch());
                break;
            case MillGameModes.Rhyme:
                //TODO
                // buraya okunusu ayni olanlari check edecek bir sistem kur.
                //TODO
                if (slotItem1.name.Substring(slotItem1.name.Length - 9, 2) == slotItem2.name.Substring(slotItem2.name.Length - 9, 2))
                    StartCoroutine(TrueMatch());
                else
                    StartCoroutine(WrongMatch());
                break;
            default:
                break;
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

        MoneyManager.instance.money += 125;
        PlayerPrefs.SetInt("Money", MoneyManager.instance.money);
        int experience = PlayerPrefs.GetInt("Experience");
        experience += 3;
        PlayerPrefs.SetInt("Experience", experience);

        //PlayerPrefs.SetString("MillGameLevel1", "true");
        //MoneyManager.instance.money += 125;
    }

    private void GameMode()
    {
        int random = Random.Range(0, 3);
        switch (random)
        {
            case 0:
                millGameMode = MillGameModes.FirstLetter;
                break;
            case 1:
                millGameMode = MillGameModes.LastLetter;
                break;
            case 2:
                millGameMode = MillGameModes.Rhyme;
                break;
            default:
                break;
        }

        randomItemGenerator.CheckLanguageAndDetermineRandomItems();

        millGameMode_Txt.text = millGameMode.ToString();
    }
}
