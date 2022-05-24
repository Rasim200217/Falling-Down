using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsCore : MonoBehaviour, IUnityAdsListener
{
   [SerializeField] private bool _testMode = true;

   private string _gameId = "4768191";

   private string _video = "Interstitial_Android";
   private string _rewardedVieo = "Rewarded_Android";
   private string _banner = "Banner_Android";

   private void Start()
   {
      Advertisement.AddListener(this);
      Advertisement.Initialize(_gameId, _testMode);

      #region  Banner

      StartCoroutine(ShowBannerWhenInitialized());
      Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);

      #endregion
   }

   public static void ShowAdsVideo(string placementId)
   {
      if (Advertisement.IsReady())
      {
         Advertisement.Show(placementId);
      }
      else
         Debug.Log("Advestisement not ready!");
   }

   IEnumerator ShowBannerWhenInitialized()
   {
      while (!Advertisement.isInitialized)
      {
         yield return new WaitForSeconds(0.5f);
      }
      Advertisement.Banner.Show(_banner);
   }

   public void OnUnityAdsReady(string placementId)
   {
      if (placementId == _rewardedVieo)
      {
         
      }
   }

   public void OnUnityAdsDidError(string message)
   {
     
   }

   public void OnUnityAdsDidStart(string placementId)
   {
      
   }

   public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
   {
      if (showResult == ShowResult.Finished)
      {
         Debug.Log("+1");
      }
      else if (showResult == ShowResult.Skipped)
      {
         Debug.Log("-");
      }
      else if (showResult == ShowResult.Failed)
      {
         
      }
   }
}
