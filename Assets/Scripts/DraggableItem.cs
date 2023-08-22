using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Language
{
    Turkish,
    Finnish
}
public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    public Language languageOfItem;

    [HideInInspector] public Transform parentAfterDrag, originalParent;
    private Image image;

    [HideInInspector] public AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        image = GetComponent<Image>();
    }
    private void Start()
    {
        string language = PlayerPrefs.GetString("Language");

        gameObject.SetActive(false);

        if (language == "Turkish" && languageOfItem == Language.Turkish)
        {
            gameObject.SetActive(true);   
        }
        else if (language == "Finnish" && languageOfItem == Language.Finnish)
        {
            gameObject.SetActive(true);
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();

        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);

        image.raycastTarget = true;

        if (GameManager.Instance.State == GameStates.MillGame)
        {
            if (MillGameManager.Instance.matchingSlot1.transform.childCount == 1 &&
            MillGameManager.Instance.matchingSlot2.transform.childCount == 1)
            {
                MillGameManager.Instance.CheckSlotItems();
            }
        }
        else if(GameManager.Instance.State == GameStates.CastleGame)
        {
            int childCountSlot1 = CastleGameManager.instance.slots[0].transform.childCount;
            int childCountSlot2 = CastleGameManager.instance.slots[1].transform.childCount;
            int childCountSlot3 = CastleGameManager.instance.slots[2].transform.childCount;
            int childCountSlot4 = CastleGameManager.instance.slots[3].transform.childCount;
            int childCountSlot5 = CastleGameManager.instance.slots[4].transform.childCount;

            if (childCountSlot1 > 0 && childCountSlot2 > 0 && childCountSlot3 > 0 &&
                childCountSlot4 > 0 && childCountSlot5 > 0)
            {
                CastleGameManager.instance.CheckSlotsOrder();
            }

        }
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (GameManager.Instance.State == GameStates.MillGame)
        {
            audioSource.Play();
        }
    }
}
