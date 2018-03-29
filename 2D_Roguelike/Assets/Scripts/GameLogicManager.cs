using System.Collections;
using System.Collections.Generic; //lists
using UnityEngine;
using UnityEngine.UI; //added clip 12
using UnityEngine.SceneManagement;

public class GameLogicManager : MonoBehaviour {

    public float levelStartDelay = 2f; //added clip 12
    public float turnDelay = .1f; //added clip 11
    public static GameLogicManager instance = null;
    public BoardManager boardScript;
    public int playerFoodPoints = 100; //added clip 9
    [HideInInspector]
    public bool playersTurn = true;  //added clip 9

    private Text levelText; //added clip 12
    private GameObject levelImage; //added clip 12
    private int level = 0; 

    // added clip 11
    private List<Enemy> enemies;
    private bool enemiesMoving;
    private bool doingSetup; //added clip 12

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject); //kun uusi scene alkaa se luo uuden GameManagerin. tämä tuohaisi sen.
        }

        DontDestroyOnLoad(gameObject); // tämä varmistaa, ettei gameobjectia tuhota.
        enemies = new List<Enemy>(); //added clip 11
        boardScript = GetComponent<BoardManager>();
        //InitGame(); //added clip 12
    }

    //private void OnLevelWasLoaded(int index) //added clip 12. Unityn oma funktio
    //{
    //    level++;
    //    InitGame();
    //}

    //This is called each time a scene is loaded.
    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        //Add one to our level number.
        level++;
        //Call InitGame to initialize our level.
        InitGame();
    }

    void OnEnable()
    {
        //Tell our ‘OnLevelFinishedLoading’ function to start listening for a scene change event as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our ‘OnLevelFinishedLoading’ function to stop listening for a scene change event as soon as this script is disabled.
        //Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void InitGame() {
        doingSetup = true; //added clip 12
        levelImage = GameObject.Find("LevelImage"); //added clip 12
        levelText = GameObject.Find("LevelText").GetComponent<Text>(); //added clip 12
        levelText.text = "Day " + level; //added clip 12
        levelImage.SetActive(true); //added clip 12
        Invoke("HideLevelImage", levelStartDelay); //added clip 12

        enemies.Clear(); // added clip 11
        boardScript.SetupScene(level);
	}

    private void HideLevelImage() //added clip 12
    {
        levelImage.SetActive(false);
        doingSetup = false;
    }
	
    public void GameOver()  //added clip 9
    {
        levelText.text = "After " + level + " days, you starved."; //added clip 12
        levelImage.SetActive(true); //added clip 12
        enabled = false; //disabloi GameManagerin
    }

	void Update () { //added clip 11
        //if (playersTurn || enemiesMoving) //clip 11
        //    return;

        if (playersTurn || enemiesMoving || doingSetup) //added clip 12
            return;

        StartCoroutine(MoveEnemies());
	}

    public void AddEnemyToList(Enemy script) //clip 11
    {
        enemies.Add(script);
    }


    IEnumerator MoveEnemies() //added clip 11
    {
        enemiesMoving = true;
        yield return new WaitForSeconds(turnDelay);
        if (enemies.Count == 0)
        {
            yield return new WaitForSeconds(turnDelay);
        }

        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].MoveEnemy();
            yield return new WaitForSeconds(enemies[i].moveTime);
        }

        playersTurn = true;
        enemiesMoving = false;
    }

}
