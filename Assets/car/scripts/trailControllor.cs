using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailControllor : MonoBehaviour
{
    //TrailRenderer tr;

    [SerializeField]
    Skidmarks skidmarksController;

    AudioSource audioData;

    int lastSkid=-1;

    private void Start()
    {
        audioData = GetComponent<AudioSource>();
        if (audioData)
        {
            if (!audioData.isPlaying)
            {
                audioData.Play(0);
            }
        }
       
    }

    void Update()
    {
       
        if (Input.GetMouseButton(0))
        {
            lastSkid = skidmarksController.AddSkidMark(transform.position,transform.position, 1, lastSkid);
            //tr.enabled = true;
            if (audioData) {
                audioData.Stop();
            }
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            lastSkid = -1;
            // StartCoroutine(stopTrail());
            if (audioData)
            {
                if (!audioData.isPlaying)
                {
                    audioData.Play(0);
                }
            }
        }
        if (Input.GetMouseButton(1))
        {
            lastSkid = skidmarksController.AddSkidMark( transform.position, transform.position, 1, lastSkid);
                //tr.enabled = true;
                if (audioData)
                {
                    audioData.Stop();
                }
        }
        if (Input.GetMouseButtonUp(1))
        {
            lastSkid = -1;
                    //StartCoroutine(stopTrail());
                    if (audioData)
                    {
                        if (!audioData.isPlaying)
                        {
                            audioData.Play(0);
                        }
                    }
        }
    }

    IEnumerator stopTrail()
    {
        yield return new WaitForSeconds(2);
        //tr.enabled = false;
    }
}
