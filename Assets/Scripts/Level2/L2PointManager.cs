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


    public void SubmitScoreToPlayFab()
    {
        // Verifica se l'utente è autenticato
        if (!PlayFabManager.Instance.IsLoggedIn())
        {
            // Se l'utente non è autenticato, visualizza un messaggio di errore o avvia il processo di login
            Debug.LogError("User is not logged in. Cannot submit score to PlayFab.");
            return;
        }
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "Score",
                    Value = score
                }
            }
        };

        PlayFabClientAPI.UpdatePlayerStatistics(request, OnScoreSubmitted, OnError);
    }

    void OnScoreSubmitted(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Score submitted successfully!");
    }

    void OnError(PlayFabError error)
    {
        Debug.LogError("Error submitting score: " + error.ErrorMessage);
    }

}
