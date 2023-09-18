using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WomanAudio : MonoBehaviour, IPointerClickHandler
{
    public AudioClip FirstLetterAudio, LastLetterAudio, RhymeAudio;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        MillGameManager millGameManager = MillGameManager.Instance;

        if (millGameManager != null)
        {
            switch (millGameManager.millGameMode)
            {
                case MillGameModes.FirstLetter:
                    if (!GetComponent<AudioSource>().isPlaying)
                    {
                        GetComponent<AudioSource>().PlayOneShot(FirstLetterAudio);
                    }
                    break;
                case MillGameModes.LastLetter:
                    if (!GetComponent<AudioSource>().isPlaying)
                    {
                        GetComponent<AudioSource>().PlayOneShot(LastLetterAudio);
                    }
                    break;
                case MillGameModes.Rhyme:
                    if (!GetComponent<AudioSource>().isPlaying)
                    {
                        GetComponent<AudioSource>().PlayOneShot(RhymeAudio);
                    }
                    break;
                default:
                    break;
            }
        }
    }

    public void WomanAudioInstruction()
    {
        switch (MillGameManager.Instance.millGameMode)
        {
            case MillGameModes.FirstLetter:
                GetComponent<AudioSource>().PlayOneShot(FirstLetterAudio);
                break;
            case MillGameModes.LastLetter:
                GetComponent<AudioSource>().PlayOneShot(LastLetterAudio);
                break;
            case MillGameModes.Rhyme:
                GetComponent<AudioSource>().PlayOneShot(RhymeAudio);
                break;
            default:
                break;
        }
    }
}
