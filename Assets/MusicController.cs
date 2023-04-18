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

    public void LowVolume()
    {
        musicObj.GetComponent<AudioSource>().volume = .1f;
    }

    public void MidVolume()
    {
        musicObj.GetComponent<AudioSource>().volume = .5f;
    }
    public void HighVolume()
    {
        musicObj.GetComponent<AudioSource>().volume = .9f;
    }
}
