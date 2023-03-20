using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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

        if (MillGameManager.Instance.matchingSlot1.transform.childCount == 1 &&
            MillGameManager.Instance.matchingSlot2.transform.childCount == 1)
        {
            MillGameManager.Instance.CheckSlotItems();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        audioSource.Play();
    }
}
