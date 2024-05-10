using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;
using PlayFab.MultiplayerModels;
using UnityEngine.UI;
using TMPro;
using System;

public class GameController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseButton;
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
    }
    
    public void GameOver()
    {
        gameOver.SetActive(true);
        FindObjectOfType<LeaderboardManager>().SubmitScoreToPlayFab();

    }

    public void L2GameOver()
    {
        gameOver.SetActive(true);
        FindObjectOfType<LeaderboardManager>().SubmitScoreToPlayFab();

    }

    public void resumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
    }

}