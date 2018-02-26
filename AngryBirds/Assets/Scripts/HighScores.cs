using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScores : MonoBehaviour {

    HighScoreList highScoreList;

    public List<string> names = new List<string>();
    public List<int> scores = new List<int>();

    void Awake()
    {
        highScoreList = GetComponent<HighScoreList>();
    }

	void Start () {
        LoadScores();
        //PlayerPrefs.DeleteAll(); //USE WITH CAUTION!
    }

    void SaveScore(string name, int score, string placement)
    {
        
        PlayerPrefs.SetInt(placement+"int", score);
        PlayerPrefs.SetString(placement+"str", name);
    }

    void LoadScores()
    {
        for (int i = 0; i < 3; i++)
        {
            int loadedScore = PlayerPrefs.GetInt(i.ToString() + "int");
            string loadedName = PlayerPrefs.GetString(i.ToString() + "str");
            scores.Add(loadedScore);
            names.Add(loadedName);
            Debug.Log(names[i] + ": " + scores[i]);
        }
    }

    public void GetName(string name)
    {
        int tempScore = PlayerPrefs.GetInt("Score");
        
        if (tempScore > scores[0])
        {
            SaveScore(PlayerPrefs.GetString("2str"), PlayerPrefs.GetInt("2int"), "3");
            SaveScore(PlayerPrefs.GetString("1str"), PlayerPrefs.GetInt("1int"), "2");
            SaveScore(name, tempScore, "0");
        }
        else if (tempScore > scores[1] && tempScore < scores[0])
        {
            SaveScore(PlayerPrefs.GetString("1str"), PlayerPrefs.GetInt("1int"), "3");
            SaveScore(name, tempScore, "1");
        }
        else if (tempScore > scores[2] && tempScore < scores[1])
        {
            SaveScore(name, tempScore, "2");
        }
        else
        {
            Debug.Log("no score");
        }
    }

}
