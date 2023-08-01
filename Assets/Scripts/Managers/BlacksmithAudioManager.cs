using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlacksmithAudioManager : MonoBehaviour
{
    public AudioSource Tr, Fin;

    private void Start()
    {
        if (PlayerPrefs.GetString("Language") == "Turkish")
        {
            Tr.Play();
        }
        else if (PlayerPrefs.GetString("Language") == "Finnish")
        {
            Fin.Play();
        }
    }
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
