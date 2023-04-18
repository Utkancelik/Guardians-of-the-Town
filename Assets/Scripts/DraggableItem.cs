using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    [HideInInspector] public Transform parentAfterDrag, originalParent;
    private Image image;

    [HideInInspector] public AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        image = GetComponent<Image>();
        originalParent = transform.parent;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();

        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        transform.SetParent(parentAfterDrag);

        image.raycastTarget = true;

        if (GameManager.Instance.State == GameManager.GameStates.MillGame)
        {
            if (MillGameManager.Instance.matchingSlot1.transform.childCount == 1 &&
            MillGameManager.Instance.matchingSlot2.transform.childCount == 1)
            {
                MillGameManager.Instance.CheckSlotItems();
            }
        }
        else if(GameManager.Instance.State == GameManager.GameStates.CastleGame)
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
        if (GameManager.Instance.State == GameManager.GameStates.MillGame)
        {
            audioSource.Play();
        }
        
    }
}
