using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class L2NextLevel : MonoBehaviour
{
    public GameObject levelComplete;
    public GameObject pauseButton;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckLevelComplete2();

    }

    public void NextButton2()
    {
        SceneManager.LoadSceneAsync(4);
    }


    public void CheckLevelComplete2()
    {
        if (L2PointManager.score >= 1000)
        {
            Time.timeScale = 0f;
            levelComplete.SetActive(true);
            pauseButton.SetActive(false);
            FindObjectOfType<L2PointManager>().SubmitScoreToPlayFab();
        }
    }
}
