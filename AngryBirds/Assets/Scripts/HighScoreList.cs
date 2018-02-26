using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreList : MonoBehaviour
{
    HighScores highScores;
    public Text namesText, scoresText;
    int rank = 0;

    void Start()
    {
        highScores = GetComponent<HighScores>();
        for (int i = 0; i < 3; i++)
        {
            SetScores(highScores.names[i], highScores.scores[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetScores(string name, int score)
    {
        rank++;
        if (rank == 1)
        {
            namesText.text = name + "\n";
            scoresText.text = score.ToString() + "\n";
        }
        else
        {
            namesText.text += name + "\n";
            scoresText.text += score.ToString() + "\n";
        }

    }
}
