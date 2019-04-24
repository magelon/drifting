using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinCountText : MonoBehaviour
{
    Text t;
    public int coin=0;

    public void Start()
    {
        t = GetComponent<Text>();
    }

    public void UpdateCoinText()
    {
        t.text = "" +coin;
    }
}
