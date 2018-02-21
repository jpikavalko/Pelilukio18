using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetDamage : MonoBehaviour {

    static private int birdsLeft;

    Rigidbody2D rb;
    BoxCollider2D boxCollider;
    public int hitPoints = 2;
    public Sprite damageSprite;
    public float damageImpactSpeed;

    private int currentHitPoints;
    private float damageImpactSpeedSqr;
    private SpriteRenderer spriteRenderer;


    void Awake()
    {
        birdsLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;
        //Debug.Log(birdsLeft);
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHitPoints = hitPoints;
        damageImpactSpeedSqr = damageImpactSpeed * damageImpactSpeed;
	}
	

	void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Damager") {
            return;
        }
        if (collision.relativeVelocity.sqrMagnitude < damageImpactSpeedSqr) {
            return;
        }

        spriteRenderer.sprite = damageSprite;
        currentHitPoints--;

        if (currentHitPoints <= 0)
        {
            Kill();
            birdsLeft--;

            if (birdsLeft < 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
            }
        }
    }

    void Kill()
    {
        spriteRenderer.enabled = false;
        boxCollider.enabled = false;
        rb.isKinematic = true;
        //particle system if wanted
    }
}
