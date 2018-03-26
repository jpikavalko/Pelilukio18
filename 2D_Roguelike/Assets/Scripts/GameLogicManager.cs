using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogicManager : MonoBehaviour {

    public static GameLogicManager instance = null;
    public BoardManager boardScript;
    public int playerFoodPoints = 100; //added clip 9
    [HideInInspector]
    public bool playersTurn = true;  //added clip 9

    private int level = 3;

    void Awake()
    {
        if (instance = null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject); //kun uusi scene alkaa se luo uuden GameManagerin. tämä tuohaisi sen.
        }

        DontDestroyOnLoad(gameObject); // tämä varmistaa, ettei gameobjectia tuhota.
        boardScript = GetComponent<BoardManager>();
        InitGame();
    }

	void InitGame() {
        boardScript.SetupScene(level);
	}
	
    public void GameOver()  //added clip 9
    {
        enabled = false; //disabloi GameManagerin
    }

	void Update () {
		
	}
}
