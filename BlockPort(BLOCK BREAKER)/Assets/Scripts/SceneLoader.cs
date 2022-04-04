using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static int skipNumber = 0;
  
    public void LoadNextScene()
    {
        int currentSceneI = SceneManager.GetActiveScene().buildIndex;       
        SceneManager.LoadScene(currentSceneI + 1);
        
    }
    public void LoadFirstScene()
    {
        SceneManager.LoadScene(0);        
    }
    public void LoadHelpScene()
    {
        int currentSceneI = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneI == 0)
          SceneManager.LoadScene("HELP SCENE");
    }  
    public void QuitGame()
    {
        Application.Quit();
    }
    public void HowToPlayScene()
    {
        SceneManager.LoadScene(4);
    }
    public void GoToFirtstLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadNextLevel()
    {
        int currentSceneI = SceneManager.GetActiveScene().buildIndex;
        if (skipNumber < 1)
        {
            SceneManager.LoadScene(currentSceneI + 1);
            skipNumber++;
            PauseMenu closeMenu = FindObjectOfType<PauseMenu>();
            //closeMenu.pauseMenuUI.SetActive(false);
            closeMenu.Resume();
            DontDestroyOnLoad(gameObject);
        }
        else if (currentSceneI == 0)
          skipNumber = 0;

        }
    public void RetryLevel()
    {
        int currentSceneI = SceneManager.GetActiveScene().buildIndex;
        if (FindObjectOfType<LoseCollider>().gameOver == true || FindObjectOfType<SpikeCollider>().spikeGameOver==true)
        {
            SceneManager.LoadScene(currentSceneI);
            FindObjectOfType<PauseMenu>().pauseMenuUI.SetActive(false);
        }
    }

}
