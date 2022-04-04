using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public GameObject gameOverUI;

    void Update()
    {
        if (FindObjectOfType<LoseCollider>().gameOver == true || FindObjectOfType<SpikeCollider>().spikeGameOver == true)
        {
            GameOverScrPopUp();
        }
        
    }

    public void GameOverScrPopUp()
    {
        gameOverUI.SetActive(true);
        Cursor.visible = true;
        Time.timeScale = 0f;
        FindObjectOfType<PauseMenu>().pauseMenuUI.SetActive(false);
    }

}
