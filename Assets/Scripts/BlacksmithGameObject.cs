using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlacksmithGameObject : MonoBehaviour
{
    public bool isClicked = false;

    public enum Class
    {
        Koy,
        Mutfak,
        Sokak
    }
    public Class type;
}
