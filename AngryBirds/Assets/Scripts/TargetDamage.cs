using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDamage : MonoBehaviour {

    Rigidbody2D rigidbody;
    BoxCollider2D collider;
    public int hitPoints = 2;
    public Sprite damageSprite;
    public float damageImpactSpeed;

    private int currentHitPoints;
    private float damageImpactSpeedSqr;
    private SpriteRenderer spriteRenderer;


    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
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
        }
    }

    void Kill()
    {
        spriteRenderer.enabled = false;
        collider.enabled = false;
        rigidbody.isKinematic = true;
        //particle system if wanted
    }
}
