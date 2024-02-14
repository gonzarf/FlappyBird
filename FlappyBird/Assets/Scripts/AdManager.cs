using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class AdManager : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener, IUnityAdsInitializationListener
{
    public string myGameIdAndroid = "5528919";
    public string adUnityIdAndroid = "Interstitial_Android";

    public string myAdUnityId;
    public bool testMode = false;

    public static AdManager instance;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Advertisement.Initialize(myGameIdAndroid, testMode, this);
            myAdUnityId = adUnityIdAndroid;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowAd()
    {
        if (Advertisement.isInitialized)
        {
            Advertisement.Show(myAdUnityId, this);
        }
    }

    public void HandleAd(ShowResult result)
    {
        switch(result)
        {
            case ShowResult.Finished:
            case ShowResult.Skipped:
            case ShowResult.Failed:
                SceneManager.LoadScene("Game"); //Cuando se completa el anuncio reinicia la escena
                break;
        }
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        print("Ad loaded!");
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        print("Failed to load the ad");
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        SceneManager.LoadScene("Game"); //Cuando se completa el anuncio reinicia la escena
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        SceneManager.LoadScene("Game"); //Cuando se completa el anuncio reinicia la escena
        Advertisement.Load(myAdUnityId, this);
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        print("Fallo al enseñar el anuncio");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        SceneManager.LoadScene("Game"); //Cuando se completa el anuncio reinicia la escena
    }

    public void OnInitializationComplete()
    {
        print("Ads done");
        Advertisement.Load(myAdUnityId, this);
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        print("Ads failed");
    }
}
