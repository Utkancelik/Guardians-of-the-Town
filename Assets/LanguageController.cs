using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageController : MonoBehaviour
{
    public void Finnish()
    {
        PlayerPrefs.SetString("Language", "Finnish");
    }

    public void Turkish()
    {
        PlayerPrefs.SetString("Language", "Turkish");
    }
}
