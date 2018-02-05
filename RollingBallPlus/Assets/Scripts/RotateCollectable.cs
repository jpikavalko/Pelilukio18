using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCollectable : MonoBehaviour {


	void Update () {
        transform.Rotate(new Vector3(30f, 30f, 30f) * Time.deltaTime);
	}
}
