using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Resetter : MonoBehaviour {

    public Rigidbody2D projectile;
    public float resetSpeed = 0.025f;

    private float resetSpeedSqr;
    private SpringJoint2D spring;

    public GameObject projectile2, projectile3;
    static private int projectilesLeft;
    public CameraFollow cameraFollow;


	void Start () {
        projectilesLeft = 3;
        projectile2.SetActive(false);
        projectile3.SetActive(false);
        resetSpeedSqr = resetSpeed * resetSpeed;
        spring = projectile.GetComponent<SpringJoint2D>();
	}
	

	void Update () {
		if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }

        if (spring == null && projectile.velocity.sqrMagnitude < resetSpeedSqr)
        {
            NewProjectile();
        }

	}

    void NewProjectile()
    {
        projectilesLeft--;
        cameraFollow.lifesLeft--;
        switch (projectilesLeft)
        {
            case 2:
                projectile2.SetActive(true);
                spring = projectile2.GetComponent<SpringJoint2D>();
                break;
            case 1:
                projectile3.SetActive(true);
                spring = projectile3.GetComponent<SpringJoint2D>();
                break;
        }
    }

    void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
 
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //if (other.GetComponent<Rigidbody2D>() == projectile)
        //{
        //    Reset();
        //}
        if (other.gameObject.name == "Asteroid")
        {
            NewProjectile();
            
        }
        if (other.gameObject.name == "Asteroid 2")
        {
            NewProjectile();
        }
        if (other.gameObject.name == "Asteroid 3")
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
                SceneManager.LoadScene(1);
        }

    }

}
