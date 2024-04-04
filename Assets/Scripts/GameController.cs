using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseButton;
    public GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        gameOver.SetActive(false);
        
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
        pauseButton.SetActive(false);
    }
}
