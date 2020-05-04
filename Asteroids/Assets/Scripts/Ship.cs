using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigidbody2D;
    private Vector2 thrustDirection;
    private const float ThrustForce = 5f;
    private const int RotateDegPerSec = 40;
    private CircleCollider2D _circleCollider2D;

    void Start()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        thrustDirection = new Vector2();

        _circleCollider2D = gameObject.GetComponent<CircleCollider2D>();

    }

    // Update is called once per frame
    // void Update()
    // {
    //
    // }
    
    void FixedUpdate()
    {
        float moving = ThrustForce * Time.deltaTime;
        if (Input.GetAxis("Thrust") > 0)
        {
            var c = Mathf.Deg2Rad * (transform.eulerAngles.z+90);
            thrustDirection.x = Mathf.Cos(c);
            thrustDirection.y = Mathf.Sin(c);
            //rigidbody2D.AddForce(ThrustForce * thrustDirection, ForceMode2D.Force);

            this.transform.position += new Vector3(thrustDirection.x, thrustDirection.y) * moving;
        }

        float rotationAmount = RotateDegPerSec * Time.deltaTime;
        if (Input.GetAxis("Rotate") < 0)
        {
            rotationAmount *= -1;
        }
        else if (Input.GetAxis("Rotate") > 0)
        {
            rotationAmount *= 1;
        }
        else
        {
            rotationAmount = 0;
        }
        transform.Rotate(Vector3.forward, rotationAmount);
        
    }
    
    void OnBecameInvisible()
    {
        float radius = _circleCollider2D.radius;

        if (transform.position.x > ScreenUtils.ScreenRight)
        {
            transform.position = new Vector3(ScreenUtils.ScreenLeft, transform.position.y);
        }

        if (transform.position.x < ScreenUtils.ScreenLeft)
        {
            transform.position = new Vector3(ScreenUtils.ScreenRight, transform.position.y);
        }
        
        if (transform.position.y > ScreenUtils.ScreenTop)
        {
            transform.position = new Vector3(transform.position.x, ScreenUtils.ScreenBottom);
        }
        
        if (transform.position.y < ScreenUtils.ScreenBottom)
        {
            transform.position = new Vector3(transform.position.x, ScreenUtils.ScreenTop);
        }
    }
}
