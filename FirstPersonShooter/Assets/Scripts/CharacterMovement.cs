using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    Rigidbody rb;
    public float speed;
    float run;

    void Start()
    {
        //Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
            run = 2;
        else
            run = 1;

        transform.Translate(h * speed * run * Time.deltaTime, 0f, v * speed * run * Time.deltaTime);
    }
}
