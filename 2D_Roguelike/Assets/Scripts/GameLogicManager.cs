using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogicManager : MonoBehaviour {

    public static GameLogicManager instance = null;
    public BoardManager boardScript;

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
	
	void Update () {
		
	}
}
