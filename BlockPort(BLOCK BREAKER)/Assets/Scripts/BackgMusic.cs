using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgMusic : MonoBehaviour
{      
    private void Play()
    {
        GetComponent<AudioSource>().volume = 0.2f;
    }
    private void Update()
    {
        if(PauseMenu.gameIsPaused)
            Play();
        else
            GetComponent<AudioSource>().volume = 0.5f;
    }
}
