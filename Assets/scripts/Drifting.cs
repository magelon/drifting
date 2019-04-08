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
            rb.AddTorque(2f);
           
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            rb.angularVelocity = 0;

            StartCoroutine(stopDely());

        }
        if (Input.GetMouseButton(1))
        {
            rb.AddTorque(-2f);
            
        }
        if (Input.GetMouseButtonUp(1))
        {
            rb.angularVelocity = 0;

            StartCoroutine(stopDely());

        }
    }


    IEnumerator  stopDely()
    {
        yield return new WaitForSeconds(0.01f);
        rb.velocity=Vector2.Lerp(rb.velocity,Vector2.zero , 0.5f);
        
    }

}
