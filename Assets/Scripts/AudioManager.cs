using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public void VolumeOff()
    {
        MusicController.instance.VolumeOff();
    }

    public void VolumeLow()
    {
        MusicController.instance.LowVolume();
    }
    
}
