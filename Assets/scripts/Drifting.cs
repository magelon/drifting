using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drifting : MonoBehaviour
{
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //transform.Translate(transform.up*0.01f);
        rb.AddForce(transform.up*0.1f);
        if (Input.GetMouseButton(0))
        {
            rb.AddTorque(0.01f);
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            rb.angularVelocity = 0;
            rb.velocity = Vector2.zero;
        }
        if (Input.GetMouseButton(1))
        {
            rb.AddTorque(-0.01f);
        }
        if (Input.GetMouseButtonUp(1))
        {
            rb.angularVelocity = 0;
            rb.velocity = Vector2.zero;
        }
    }
}
