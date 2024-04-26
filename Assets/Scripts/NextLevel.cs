using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
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
        CheckLevelComplete();
    }


    public void NextButton()
    {
        SceneManager.LoadSceneAsync(3);
    }


    public void CheckLevelComplete()
    {
        if (PointManager.score >= 500)
        {
            Time.timeScale = 0f;
            levelComplete.SetActive(true);
            pauseButton.SetActive(false);
        }
    }
}
