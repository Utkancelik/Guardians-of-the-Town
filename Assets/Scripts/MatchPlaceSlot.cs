using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MatchPlaceSlot : MonoBehaviour, IDropHandler, IPointerClickHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (SceneManager.GetActiveScene().name == "Scene_8.0_MillGameLevel1")
        {
            GameObject droppedItem = eventData.pointerDrag;
            DraggableItem draggableItem = droppedItem.GetComponent<DraggableItem>();
            draggableItem.parentAfterDrag = transform;
            draggableItem.audioSource.Play();
        }
        else if(SceneManager.GetActiveScene().name == "Scene_8.1_CastleGameLevel1")
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
        if (SceneManager.GetActiveScene().name == "Scene_8.2_BlacksmithGameLevel1")
        {
            GameObject clickedItem = eventData.pointerClick;
            BlacksmithGameManager.Instance.CheckSlotContext(clickedItem.transform.GetChild(0).gameObject);
        }
    }
}
