using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MillGameManager : MonoBehaviour
{
    public GameObject slot1, slot2;

    public bool CheckSlots()
    {
        GameObject item1 = slot1.transform.GetChild(0).gameObject;
        GameObject item2 = slot2.transform.GetChild(0).gameObject;

        string name1 = item1.name;
        string name2 = item2.name;

        return name1[0] == name2[0];
    }
}
