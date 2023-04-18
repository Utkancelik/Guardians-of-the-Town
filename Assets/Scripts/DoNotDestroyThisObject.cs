using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroyThisObject : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
