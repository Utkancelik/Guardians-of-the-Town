using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSourceIntroduction;
    [SerializeField] private AudioSource[] audioSources;

    private void Start()
    {
        if(audioSourceIntroduction != null)
            StartCoroutine(PlayAudio(audioSourceIntroduction));

        if (audioSources != null)
            StartCoroutine(PlayAllAudios());
        
    }

    private IEnumerator PlayAudio(AudioSource audioSource)
    {
        audioSource.Play();
        yield return null;
    }

    private IEnumerator PlayAllAudios()
    {
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (audioSources[i] != null)
            {
                StartCoroutine(PlayAudio(audioSources[i]));
                yield return new WaitForSeconds(audioSources[i].clip.length);
            }
        }
        yield return null;
    }


    
}
