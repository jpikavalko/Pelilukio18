using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    public Sprite dmgSprite;
    public int hp = 4;

    public AudioClip chopSound1; // added clip 13
    public AudioClip chopSound2; // added clip 13

    private SpriteRenderer spriteRenderer; //päästään käsiksi spriteihin

	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
    public void DamageWall (int loss)
    {
        SoundManager.instance.RandomizeSoundEffect(chopSound1, chopSound2); // added clip 13
        spriteRenderer.sprite = dmgSprite;
        hp -= loss;
        if (hp <= 0)
            gameObject.SetActive(false);
    }

}
