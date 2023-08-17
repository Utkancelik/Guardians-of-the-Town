using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStates
{
    MillGame,
    CastleGame,
    BlacksmithGame
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameStates State;

    private void Awake()
    {
        Instance = this;

        MusicController.instance.LowVolume();
    }



}
