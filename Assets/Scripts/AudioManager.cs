using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip CastleGameClip_TR, CastleGameClip_FIN;
    //public bool gameStarted = 


    //[SerializeField] private AudioSource audioSourceIntroduction;
    //[SerializeField] private AudioSource[] audioSources;

    //[SerializeField] private AudioSource castleGameAudioSource, blacksmithGameAudioSource;
    
    private void Start()
    {
        instance = this;

        
        //if(audioSourceIntroduction != null)
        //    StartCoroutine(PlayAudio(audioSourceIntroduction));

        //if (audioSources != null && SceneManager.GetActiveScene().name == "Scene_8.0_MillGameLevel1")
        //    StartCoroutine(PlayAllAudios());

        //if (audioSources != null && SceneManager.GetActiveScene().name == "Scene_8.1_CastleGameLevel1")
        //    castleGameAudioSource.Play();

        //if (audioSources != null && SceneManager.GetActiveScene().name == "Scene_8.2_BlacksmithGameLevel1")
        //    blacksmithGameAudioSource.Play();

    }

    private IEnumerator PlayAudio(AudioSource audioSource)
    {
        //audioSource.Play();
        yield return null;
    }

    private IEnumerator PlayAllAudios()
    {
        //for (int i = 0; i < audioSources.Length; i++)
        //{
        //    if (audioSources[i] != null)
        //    {
        //        StartCoroutine(PlayAudio(audioSources[i]));
        //        yield return new WaitForSeconds(audioSources[i].clip.length);
        //    }
        //}
        //gameStarted = true;
        yield return null;
    }


    
}
