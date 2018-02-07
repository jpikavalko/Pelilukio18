using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemySpawn;
    float timeLeft = 10f;

	void Start () {
		
	}
	

	void Update () { 

        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            float posX = Random.Range(-50f, 50f);
            float posZ = Random.Range(-50f, 50f);
            Instantiate(enemySpawn, new Vector3(posX, 0f, posZ), Quaternion.identity);
            timeLeft = Random.Range(2f, 10f);
        }
	}
}
