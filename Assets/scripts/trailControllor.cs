using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailControllor : MonoBehaviour
{
    //TrailRenderer tr;

    [SerializeField]
    Skidmarks skidmarksController;

    int lastSkid=-1;

    void Update()
    {
       
        if (Input.GetMouseButton(0))
        {
            lastSkid = skidmarksController.AddSkidMark(transform.position, transform.position, 1, lastSkid);
            //tr.enabled = true;

        }
        if (Input.GetMouseButtonUp(0))
        {
            lastSkid = -1;
           // StartCoroutine(stopTrail());
        }
        if (Input.GetMouseButton(1))
        {
            lastSkid = skidmarksController.AddSkidMark(transform.position, transform.position, 1, lastSkid);
            //tr.enabled = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            lastSkid = -1;
            //StartCoroutine(stopTrail());
        }
    }

    IEnumerator stopTrail()
    {
        yield return new WaitForSeconds(2);
        //tr.enabled = false;
    }
}
