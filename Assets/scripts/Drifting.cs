﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drifting : MonoBehaviour
{
    Rigidbody2D rb;

    public ParticleSystem par;

    private float timerun;

    public bool turnleft;

    AudioSource audioData;

    //public float velocityLimit;

    private void Start()
    {
        turnleft = true;
        rb = GetComponent<Rigidbody2D>();
        audioData = GetComponent<AudioSource>();
    }

    void Update()
    {
        //velocityLimit = rb.velocity.magnitude;
        //transform.Translate(transform.up*0.01f);
        if (rb.velocity.magnitude < 0.5f)
        {
            rb.AddForce(transform.up * 0.1f);
        }
        
        if (Input.GetMouseButton(0))
        {
            if (turnleft)
            {
                rb.AddTorque(2f);
            }
            else
            {
                rb.AddTorque(-2f);
            }

           
            timerun += 1;

            if (!audioData.isPlaying)
            {
                audioData.Play(0);
            }
           

            if (!par.isPlaying)
            {
                par.Play();
               
            }
            

        }
        if (Input.GetMouseButtonUp(0))
        {
            rb.angularVelocity = 0;
            audioData.Stop();
            if (timerun > 35)
            {
                StartCoroutine(stopDely());
            }
            timerun = 0;
           // par.Stop();

        }
       
    }


    IEnumerator  stopDely()
    {
        yield return new WaitForSeconds(0.02f);
        par.Stop();
        rb.velocity = Vector2.zero;
    }

}
