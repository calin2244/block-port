using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMusicPlayer : MonoBehaviour
{
    private void Awake()
    {
        int currentSceneI = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneI == 0 || currentSceneI == 4)
        {
            if (GameObject.FindGameObjectsWithTag("IntroMusic").Length > 1)
                Destroy(this.gameObject);
            DontDestroyOnLoad(this.gameObject);
        }
       
    }

    private void Update()
    {
        int currentSceneI = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneI != 0 && currentSceneI != 4)
        {
            Destroy(gameObject);   
        }
        
    }
}