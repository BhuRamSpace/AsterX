using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using PlayFab.ClientModels;
using PlayFab;

public class L2PointManager : MonoBehaviour
{
    public static int score;
    public TMP_Text scoreText;

    void Start()
    {
        ResetScore();
        Time.timeScale = 1f;
    }

    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

    public void ResetScore()
    {
        // Reimposta lo score a zero
        score = 500;
        scoreText.text = "Score: " + score;
    }
}