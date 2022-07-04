using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class RewardedAdsBtn : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
   [SerializeField] Button _showAdButton;
   [SerializeField] string _androidAdUnitId = "Rewarded_Android";
   [SerializeField] string _iOSAdUnitId = "Rewarded_iOS";
    string _adUnitId = null; // This will remain null for unsupported platforms


    void Awake()
    {   
        _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOSAdUnitId
            : _androidAdUnitId;

             _showAdButton.interactable = true;
    }

    private void Start()
    {
        LoadAd();
    }

    // Load content to the Ad Unit:
    public void LoadAd()
    {
      
        Debug.Log("Loading Ad: " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
    }
    
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Ad Loaded: " + adUnitId);
 
        if (adUnitId.Equals(_adUnitId))
        {
            _showAdButton.onClick.AddListener(ShowAd);
            //_showAdButton.interactable = true;
        }
    }
    
    public void ShowAd()
    {
        _showAdButton.interactable = false;

       Star.num += 5;
        PlayerPrefs.SetInt("starPoint", Star.num);
        Advertisement.Show(_adUnitId, this);
    }
    
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Advertisement.Load(_adUnitId, this);
        }
    }
 
    // Implement Load and Show Listener error callbacks:
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
    }
 
    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
    }
 
    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }
 
    void OnDestroy()
    {
        _showAdButton.onClick.RemoveAllListeners();
    }
}
