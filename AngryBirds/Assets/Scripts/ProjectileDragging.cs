using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDragging : MonoBehaviour {

    public float maxStretch = 3.0f;
    public LineRenderer catapultLineFront;
    public LineRenderer catapultLineBack;

    private Rigidbody2D rigidbody;
    private SpringJoint2D spring;
    private Transform catapult;
    private Ray rayToMouse;
    private Ray leftCatapultToProjectile;
    private float maxStretchSqr;
    private float circleRadius;
    private CircleCollider2D circle;

    private bool clickedOn;
    private Vector2 prevVelocity;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spring = GetComponent<SpringJoint2D>();
        circle = GetComponent<CircleCollider2D>();

        catapult = spring.connectedBody.transform;
    }

	void Start () {
        LineRendererSetup();
        rayToMouse = new Ray(catapult.position, Vector3.zero);
        leftCatapultToProjectile = new Ray(catapultLineFront.transform.position, Vector3.zero);
        maxStretchSqr = maxStretch * maxStretch;
        circleRadius = circle.radius;
	}
	

	void Update () {
		if (clickedOn)
        {
            Dragging();
        }

        if (spring != null)
        {
            if(!rigidbody.isKinematic && prevVelocity.sqrMagnitude > rigidbody.velocity.sqrMagnitude)
            {
                Destroy(spring);
                rigidbody.velocity = prevVelocity;
            }
            if (!clickedOn)
            {
                prevVelocity = rigidbody.velocity;
            }

            LineRendererUpdate();
        }
        else
        {
            catapultLineFront.enabled = false;
            catapultLineBack.enabled = false;
        }
	}

    void LineRendererSetup()
    {
        catapultLineFront.SetPosition(0, catapultLineFront.transform.position);
        catapultLineBack.SetPosition(0, catapultLineBack.transform.position);

        catapultLineFront.sortingLayerName = "Foreground";
        catapultLineBack.sortingLayerName = "Foreground";

        catapultLineFront.sortingOrder = 3;
        catapultLineBack.sortingOrder = 1;
    }

    void LineRendererUpdate()
    {
        Vector2 catapultToProjectile = transform.position - catapultLineFront.transform.position;
        leftCatapultToProjectile.direction = catapultToProjectile;
        Vector3 holdPoint = leftCatapultToProjectile.GetPoint(catapultToProjectile.magnitude + circleRadius);
        catapultLineFront.SetPosition(1, holdPoint);
        catapultLineBack.SetPosition(1, holdPoint);
    }

    void OnMouseDown()
    {
        spring.enabled = false;
        clickedOn = true;
    }

    void OnMouseUp()
    {
        spring.enabled = true;
        rigidbody.isKinematic = false;
        rigidbody.drag = 0.1f;
        rigidbody.angularDrag = 1f;
        clickedOn = false;
    }

    void Dragging()
    {
        Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 catapultToMouse = mouseWorldPoint - catapult.position;

        if (catapultToMouse.sqrMagnitude > maxStretchSqr)
        {
            rayToMouse.direction = catapultToMouse;
            mouseWorldPoint = rayToMouse.GetPoint(maxStretch);
        }

        mouseWorldPoint.z = 0f;
        transform.position = mouseWorldPoint;
    }

}
