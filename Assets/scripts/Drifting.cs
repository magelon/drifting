using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drifting : MonoBehaviour
{
    Rigidbody2D rb;

    public ParticleSystem par;
    //time count during turning
    private float timerun;
    //turning left or right 
    public bool turnleft;

    AudioSource audioData;

    public Image sr;
    //is accelerate or drifting
    public bool accelerate;

    //public float velocityLimit;

    private void Start()
    {
        //start with accelerating
        accelerate = true;
        //start with ablity turning left
        turnleft = true;

        rb = GetComponent<Rigidbody2D>();
        audioData = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        //if not drifting
        if (accelerate)
        {
            //keep velocity under 0.35f
            if (rb.velocity.magnitude < 0.35f)
            {
                //addforce keep accelerating
                rb.AddForce(transform.up * 0.1f);
            }
        }

        //if drifting
        else
        {
            //decresing velocity untill 0
            if (rb.velocity.magnitude > 0)
            {
                //addforce on oppsite side
                rb.AddForce(-transform.up * 0.1f);
            }
        }

    }

    void Update()
    {
        //when has ability turning left
        if (turnleft)
        {
            //show turn left sign
          sr.rectTransform.localScale=new Vector3(1,1,1);
        }
        else
        {
            //flip the sign
            sr.rectTransform.localScale = new Vector3(-1, 1, 1);
        }
        //velocityLimit = rb.velocity.magnitude;
        //transform.Translate(transform.up*0.01f);
       
        //start drifting
        if (Input.GetMouseButton(0))
        {
            //decresing velocity
            accelerate = false;

            //add turning force
            if (turnleft)
            {
                rb.AddTorque(2f);
            }
            else
            {
                rb.AddTorque(-2f);
            }

           //start counting turning timer
            timerun += 1;

            //play the drifting sound
            if (!audioData.isPlaying)
            {
                audioData.Play(0);
            }
           
            //play the smoke partical effect
            if (!par.isPlaying)
            {
                par.Play();
               
            }
        }

        //stop drifting
        if (Input.GetMouseButtonUp(0))
        {
            //incresing velocity
            accelerate = true;
            //stop turining force
            rb.angularVelocity = 0;
            //stop drifting sound
            audioData.Stop();

            if (timerun > 35)
            {
                //stop velocity and then start accelerating
                StartCoroutine(stopDely());
            }

            //reset timer
            timerun = 0;
           
        }
       
    }


    IEnumerator  stopDely()
    {
        yield return new WaitForSeconds(0.02f);
        par.Stop();
        //reset accelerate to 0
        rb.velocity = Vector2.zero;
        //get car back to accelerate
        rb.AddForce(transform.up * 0.3f);
    }

}
