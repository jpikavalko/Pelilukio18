using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour {

    public ParticleSystem explosion;

	void Update () {
        Destroy(this.gameObject, 5f);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            
            explosion.Play();
            Destroy(this.gameObject, 0.5f);
        }
    }
}
