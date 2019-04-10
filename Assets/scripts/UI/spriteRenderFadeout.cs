using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteRenderFadeout : MonoBehaviour
{
    public SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        StartCoroutine(scaleing());
    }

    IEnumerator scaleing()
    {
        transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * 0.5f;
        Color c = sr.color;
        c.a -= 0.005f;
        sr.color = c;
        yield return new WaitForSeconds(5);
        this.enabled = false;
    }

}
