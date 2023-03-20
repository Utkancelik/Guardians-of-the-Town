using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MillGameManager : MonoBehaviour
{
    public GameObject matchingSlot1, matchingSlot2;
    public static MillGameManager Instance;

    GameObject slotItem1, slotItem2;
    DraggableItem draggableItem1, draggableItem2;
    private void Awake()
    {
        Instance = this;
    }

    public void CheckSlotItems()
    {
        slotItem1 = matchingSlot1.transform.GetChild(0).gameObject;
        slotItem2 = matchingSlot2.transform.GetChild(0).gameObject;

        draggableItem1 = slotItem1.GetComponent<DraggableItem>();
        draggableItem2 = slotItem2.GetComponent<DraggableItem>();

        if (slotItem1.name[0] == slotItem2.name[0])
        {
            StartCoroutine(DestroyItems());
        }
        else
        {
            StartCoroutine(ReplaceToOriginalPlace());
        }

    }

    private IEnumerator DestroyItems()
    {
        yield return new WaitForSeconds(1);
        Destroy(slotItem1);
        Destroy(slotItem2);
    }

    private IEnumerator ReplaceToOriginalPlace()
    {
        yield return new WaitForSeconds(1);
        draggableItem1.parentAfterDrag = draggableItem1.originalParent;
        draggableItem2.parentAfterDrag = draggableItem2.originalParent;

        draggableItem1.transform.SetParent(draggableItem1.parentAfterDrag);
        draggableItem2.transform.SetParent(draggableItem2.parentAfterDrag);
    }
}
