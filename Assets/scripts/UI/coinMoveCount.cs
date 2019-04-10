using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinMoveCount : MonoBehaviour
{
    //coin destination should be sign in scense in editor mode
    public Transform coin;

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
           
            coin.GetComponent<coinCount>().coin++;
            Destroy(this.gameObject);
        }
    }
}
