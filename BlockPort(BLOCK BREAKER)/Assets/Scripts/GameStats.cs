using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStats : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockScore = 15;
    [SerializeField] public int totalScore = 0;
    [SerializeField] TextMeshProUGUI scoreNumber;

    void Update()
    {
        if (PauseMenu.gameIsPaused)
            Time.timeScale = 0f;
        else Time.timeScale = gameSpeed;
    }
    public void AddToScore()
    {
        totalScore = totalScore + pointsPerBlockScore;
        scoreNumber.text = totalScore.ToString();
    }
}
