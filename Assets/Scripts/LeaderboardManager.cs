using PlayFab.ClientModels;
using PlayFab;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using Newtonsoft.Json;



public class LeaderboardManager : MonoBehaviour
{

    public GameObject rowPrefab;
    public Transform rowsParent;


    public void Start()
    {
        GetLeaderboard();
    }

    public void GoBack()
    {
        SceneManager.LoadSceneAsync(1);
    }

    void Start()
    {
        // Verifica se l'utente � autenticato
        if (!PlayFabManager.Instance.IsLoggedIn())
        {
            // Se l'utente non � autenticato, visualizza un messaggio di errore o avvia il processo di login
            Debug.LogError("User is not logged in. Cannot submit score to PlayFab.");
            return;
        }

        int value;

        // Applica la condizione per assegnare il valore corretto
        if (PointManager.score >= 500)
        {
            value = L2PointManager.score;
        }
        else
        {
            value = PointManager.score;
        }

        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "Score",
                    Value = value
                }
            }
        };

        PlayFabClientAPI.UpdatePlayerStatistics(request, OnScoreSubmitted, OnError);
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

    void OnError(PlayFabError error)
    {
        Debug.LogError("Error submitting score: " + error.ErrorMessage);
    }

    void OnLeaderboardGet(GetLeaderboardResult result)
    {
        foreach(Transform item in rowsParent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in result.Leaderboard)
        {
            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            Text[] texts = newGo.GetComponentsInChildren<Text>();
            texts[0].text = item.Position.ToString();
            texts[1].text = item.PlayFabId;
            texts[2].text = item.StatValue.ToString();
            Debug.Log(string.Format("PLACE:{0} | ID:{1} | VALUE:{2}",
                item.Position,item.PlayFabId,item.StatValue));

        }
    }

}
