using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class detectCollider : MonoBehaviour
{
    AudioSource audioData;
    public Drifting dr;
    public Text t;
    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.gameObject.name== "collider")
        {
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
        if (collision.gameObject.name == "startBar")
        {
            StartCoroutine(startText());
        }
    }

    IEnumerator startText()
    {
        t.fontSize = (int)Mathf.Lerp(t.fontSize, 100, 0.1f*Time.deltaTime);
       
        yield return new WaitForSeconds(1f);
        t.enabled = false;
    }
}
