using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlacksmithAudioManager : MonoBehaviour
{
    public AudioSource Tr, Fin;

    public void PlaySound()
    {
        if(PlayerPrefs.GetString("Language") == "Turkish")
        {
            Tr.Play();
        }
        else if(PlayerPrefs.GetString("Language") == "Finnish")
        {
            Fin.Play();
        }
    }
}
