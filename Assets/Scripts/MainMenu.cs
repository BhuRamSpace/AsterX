using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void QuitGame()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void Menu()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(2);
        Time.timeScale = 1f;
    }

    public void Leaderboard()
    {
        SceneManager.LoadSceneAsync(5);
    }

}
