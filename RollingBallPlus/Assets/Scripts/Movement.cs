using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

    private Rigidbody rb;

    public Text scoreText;
    public Text winText;
    public Button playAgain;

    public float speed = 10f;

    public int maxCubes;

    int count = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetScore();
        winText.text = "";
        playAgain.gameObject.SetActive(false);
        maxCubes = GameObject.FindGameObjectsWithTag("Collectable").Length;
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable")) { 
            other.gameObject.SetActive(false);
            count++;
            SetScore();
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
            winText.text = "You lose";
            ShowRestart();
        }
    }

    void SetScore()
    {
        scoreText.text = "Score: " + count.ToString();
        if (count >= maxCubes)
        {
            ShowRestart();
            winText.text = "You win";
        }
    }

    void ShowRestart()
    {
        playAgain.gameObject.SetActive(true);
    }
}
