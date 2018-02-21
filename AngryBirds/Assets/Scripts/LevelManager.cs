using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    //public static LevelManager Instance = null;

    //void Awake()
    //{
    //    if (Instance == null)
    //        Instance = this;
    //    else if (Instance != this)
    //        Destroy(gameObject);

    //    DontDestroyOnLoad(this);
    //}

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
