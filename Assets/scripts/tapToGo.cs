using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using AudienceNetwork;

public class tapToGo : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject startText;
    private InterstitialAd interstitialAd;
    private bool isLoaded;

    private void Start()
    {
        Loadintersitital();
    }

    void OnDestroy()
    {
        // Dispose of interstitial ad when the scene is destroyed
        if (interstitialAd != null)
        {
            interstitialAd.Dispose();
        }
        Debug.Log("InterstitialAdTest was destroyed!");
    }

    public void Loadintersitital()
    {
        this.interstitialAd = new InterstitialAd("2222185464713314_2222189018046292");
        this.interstitialAd.Register(this.gameObject);

        // Set delegates to get notified on changes or when the user interacts with the ad.
        this.interstitialAd.InterstitialAdDidLoad = (delegate () {
            Debug.Log("Interstitial ad loaded.");
            this.isLoaded = true;
        });
        interstitialAd.InterstitialAdDidFailWithError = (delegate (string error) {
            Debug.Log("Interstitial ad failed to load with error: " + error);
        });
        interstitialAd.InterstitialAdWillLogImpression = (delegate () {
            Debug.Log("Interstitial ad logged impression.");
        });
        interstitialAd.InterstitialAdDidClick = (delegate () {
            Debug.Log("Interstitial ad clicked.");
        });

        this.interstitialAd.interstitialAdDidClose = (delegate () {
            Debug.Log("Interstitial ad did close.");

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            if (this.interstitialAd != null)
            {
                this.interstitialAd.Dispose();
            }
        });

        // Initiate the request to load the ad.
        this.interstitialAd.LoadAd();
    }

    public void ShowInterstitial()
    {
        if (this.isLoaded)
        {
            this.interstitialAd.Show();
            this.isLoaded = false;

        }
        else
        {
            Debug.Log("Interstitial Ad not loaded!");
        }
    }

    public void TapToGo()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        startText.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void Restart()
    {
        ShowInterstitial();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
