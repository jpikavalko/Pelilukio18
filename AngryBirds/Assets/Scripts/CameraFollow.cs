using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform projectile, projectile2, projectile3;
    public Transform farLeft;
    public Transform farRight;
    public int lifesLeft = 3;

    void Start()
    {
        Debug.Log("Camera Follow started");
    }

    void Update () {
        Debug.Log("CF updates");
        switch (lifesLeft)
        {
            case 3:
                UpdatePosition(projectile);
                break;
            case 2:
                UpdatePosition(projectile2);
                break;
            case 1:
                UpdatePosition(projectile3);
                break;
        }
        
	}

    void UpdatePosition(Transform projectile)
    {
        Debug.Log("Updating position");
        Vector3 newPosition = transform.position;
        newPosition.x = projectile.position.x;
        newPosition.x = Mathf.Clamp(newPosition.x, farLeft.position.x, farRight.position.x);
        transform.position = newPosition;
    }

}
