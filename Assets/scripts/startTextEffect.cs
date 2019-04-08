using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startTextEffect : MonoBehaviour
{
    public Text t;

    private void Update()
    {
        t.fontSize = (int)Mathf.Lerp(t.fontSize, 1000, 0.2f*Time.deltaTime);
        Color c = t.color;
        c.a -= 0.01f;
        t.color = c;

    }
}
