using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinMoveCount : MonoBehaviour
{
    //coin destination should be sign in scense in editor mode
    public Transform coin;
    public GameObject coinText;
    AudioSource audioData;

    private void Start()
    {
        audioData = GetComponent<AudioSource>();
        if (!audioData.isPlaying)
        {
            audioData.Play(0);
        }
    }

    private void Update()
    {
        StartCoroutine(moveToward());
       
    }

    IEnumerator moveToward()
    {
        yield return null;
        float step = 1 * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, coin.position, step);
        if (Vector2.Distance(transform.position, coin.position) < 0.001f)
        {
           
            coinText.GetComponent<coinCountText>().coin++;
            coinText.GetComponent<coinCountText>().UpdateCoinText();
            Destroy(this.gameObject);
        }
    }
}
