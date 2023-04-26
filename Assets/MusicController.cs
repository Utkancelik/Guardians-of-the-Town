using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static MusicController instance;
    GameObject musicObj;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
        musicObj = GameObject.FindGameObjectWithTag("Music");
        HighVolume();
    }

    public void VolumeOff()
    {
        musicObj.GetComponent<AudioSource>().volume = .0f;
    }

    public void LowVolume()
    {
        musicObj.GetComponent<AudioSource>().volume = .05f;
    }

    public void MidVolume()
    {
        musicObj.GetComponent<AudioSource>().volume = .3f;
    }
    public void HighVolume()
    {
        musicObj.GetComponent<AudioSource>().volume = .8f;
    }
}
