using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    public int health = 100;
    public GameObject player;

    float enemySpeed, step;

	void Start () {
        player = GameObject.Find("Player");
        enemySpeed = Random.Range(2f, 20f);
	}
	
	void Update () {
        step = enemySpeed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Projectile"))
        {
            health -= 20;

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
