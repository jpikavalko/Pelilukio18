using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour {

    public Transform startPos;
    public Transform endPos;

    private Vector3 pos1, pos2;
    public float speed = 1.0f;

    void Start()
    {
        pos1 = startPos.transform.position;
        pos2 = endPos.transform.position;
    }

    void Update()
    {

    transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
    }
}
