using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MatchPlaceSlot : MonoBehaviour, IDropHandler, IPointerClickHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (GameManager.Instance.State == GameStates.MillGame)
        {
            GameObject droppedItem = eventData.pointerDrag;
            DraggableItem draggableItem = droppedItem.GetComponent<DraggableItem>();
            draggableItem.parentAfterDrag = transform;
            draggableItem.audioSource.Play();
        }
        else if(GameManager.Instance.State == GameStates.CastleGame)
        {
            if(transform.childCount == 0)
            {
                GameObject droppedItem = eventData.pointerDrag;
                DraggableItem draggableItem = droppedItem.GetComponent<DraggableItem>();
                draggableItem.parentAfterDrag = transform;
            }
            
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (GameManager.Instance.State == GameStates.BlacksmithGame)
        {
            GameObject clickedItem = eventData.pointerClick;
            BlacksmithGameManager.Instance.CheckSlotContext(clickedItem.transform.GetChild(0).gameObject);
        }
    }
}
