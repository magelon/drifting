using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class detectCollider : MonoBehaviour
{
    AudioSource audioData;
    public Drifting dr;
    public SpriteRenderer carImage;
    public Text t;
    public Rigidbody2D rb;
    public ParticleSystem par;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.gameObject.name== "collider")
        {
            rb.bodyType = RigidbodyType2D.Static;
            carImage.color = Color.black;
            if (!par.isPlaying)
            {
                par.Play();

            }
            Debug.Log("collision!");
            if (!audioData.isPlaying)
            {
                audioData.Play(0);
            }
        }
        if (collision.gameObject.name == "2")
        {
            dr.turnleft = true;
            Debug.Log("left turn");
        }
       
    }

    private void Update()
    {
        t.fontSize = (int)Mathf.Lerp(t.fontSize, 1000, Time.deltaTime);
        Color c = t.color;
        c.a -= 0.1f;
        t.color = c;
        
    }

}
