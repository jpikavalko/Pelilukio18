using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;
    static int score = 0;

    void Awake()
    {
        SetScore();
    }

    void Start()
    {
        try
        {
            scoreText = GetComponent<Text>();
        }
        catch
        {
            Debug.Log("this scene has no text elements");
        }

        LoadData();
        SetScore();
    }

    void LoadData()
    {
        score = PlayerPrefs.GetInt("Score");
        SetScore();
    }

    void Savedata()
    {
        PlayerPrefs.SetInt("Score", score);
    }

    public void EraseData()
    {
        PlayerPrefs.SetInt("Score", 0);

        for (int i = 0; i < 3; i++)
        {
            PlayerPrefs.DeleteKey(i.ToString() + "int");
            PlayerPrefs.DeleteKey(i.ToString() + "str");
        }



    }

    public void AddPoints(int amount)
    {
        score += amount;
        SetScore();
    }

    void SetScore()
    {
        if (scoreText != null)
            scoreText.text = score.ToString();
    }

    void OnDestroy()
    {
        Savedata();
    }


}
