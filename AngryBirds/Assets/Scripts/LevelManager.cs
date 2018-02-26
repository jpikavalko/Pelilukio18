using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public ScoreManager scoreManager;

    public void Awake()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    public void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            scoreManager.EraseData();
        }
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            //Debug.Log("hm");
        }
    }


    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ChangeLevelTo(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void QuitApplication()
    {
        //huom. ei toimi play-modessa, vaan ainoastaan buildissa.
        Application.Quit();
    }


}
