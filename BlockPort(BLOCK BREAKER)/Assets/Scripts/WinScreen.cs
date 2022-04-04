using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinScreen : MonoBehaviour
{
    public GameObject winScreenUI;
    Level blocks;
    [SerializeField] TextMeshProUGUI scoreText;
    GameStats score;

    void Start()
    {
        blocks = FindObjectOfType<Level>();
        score = FindObjectOfType<GameStats>();
    }


    void Update()
    {
        if (blocks.breakableBlocks == 0)
        {
            WinnScreen();
        }
    }

    public void WinnScreen()
    {
        winScreenUI.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
        scoreText.text = score.totalScore.ToString();
        FindObjectOfType<PauseMenu>().pauseMenuUI.SetActive(false);
    }
}
