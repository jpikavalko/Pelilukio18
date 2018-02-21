using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

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
