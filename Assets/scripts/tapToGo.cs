using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tapToGo : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject startText;

    public void TapToGo()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        startText.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
