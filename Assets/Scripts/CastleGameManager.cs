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
    private void Awake()
    {
        instance = this;
        winPanel.SetActive(false);
    }

    public void CheckSlotsOrder()
    {
        

        draggableItem1 = slots[0].transform.GetChild(0).GetComponent<DraggableItem>();
        draggableItem2 = slots[1].transform.GetChild(0).GetComponent<DraggableItem>();
        draggableItem3 = slots[2].transform.GetChild(0).GetComponent<DraggableItem>();
        draggableItem4 = slots[3].transform.GetChild(0).GetComponent<DraggableItem>();
        draggableItem5 = slots[4].transform.GetChild(0).GetComponent<DraggableItem>();

        if (slots[0].transform.GetChild(0).name == "Kus" &&
                    slots[1].transform.GetChild(0).name == "Cay" &&
                    slots[2].transform.GetChild(0).name == "Dis" &&
                    slots[3].transform.GetChild(0).name == "Muz" &&
                    slots[4].transform.GetChild(0).name == "Bal")
        {
            winPanel.SetActive(true);
            PlayerPrefs.SetString("CastleGameLevel1", "true");
        }
        else
        {
            winPanel.SetActive(false);
            StartCoroutine(WrongMatch());
        }
    }

    private IEnumerator WrongMatch()
    {
        yield return new WaitForSeconds(1);
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
        
    }
}
