using PlayFab.ClientModels;
using PlayFab;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;


public class LeaderboardManager : MonoBehaviour
{

    public PointManager PointManager;

    public void GoBack()
    {
        SceneManager.LoadSceneAsync(1);
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
                    Value = PointManager.score
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

    public void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "Score",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }

    void OnLeaderboardGet(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            Debug.Log(item.Position + " " + item.PlayFabId + " " + item.StatValue);
        }
    }
}
