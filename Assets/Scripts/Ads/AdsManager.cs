#define TEST
using UnityEngine;
using UnityEngine.Advertisements;

namespace Ads
{
    public class AdsManager : MonoBehaviour
    {
    #if UNITY_IOS
        private string _gameId = "3868682";
    #elif UNITY_ANDROID
        private string _gameId = "3868683";
    #else
        private string _gameId = "1234567";
    #endif

    #if TEST
        private bool _isTest = true;
    #else
        private bool _isTest = false;
    #endif

        //Inter ads controller
        //Banner ads controller
        //REwarded ads controller


        private void Start()
        {
            Advertisement.Initialize(_gameId, _isTest);
        }
        private void OnEnable()
        {
            EventManager.PlayAdsEvent += ShowAds;
        }
        private void OnDisable()
        {
            EventManager.PlayAdsEvent -= ShowAds;
        }
        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.N))
            {
                ShowInterstitialAd();
            }
        }


        private void ShowAds(AdsPlacementType adsType)
        {
            switch(adsType)
            {
                case AdsPlacementType.rewardedVideo:
                    if (Advertisement.IsReady(adsType.ToString()))
                    {
                        Advertisement.Show(adsType.ToString());
                    }
                    else
                    {
                        Debug.LogWarning("Don't have any rewarded ads in the pool");
                    }
                    break;
                case AdsPlacementType.bannerPlacement:
                    Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
                    Advertisement.Banner.Show(adsType.ToString());
                    break;
                case AdsPlacementType.intersitialAds:
                    if (Advertisement.IsReady())
                    {
                        Advertisement.Show();
                    }
                    else
                    {
                        Debug.Log("Havuz boş");
                    }
                    break;
            }
        }

        public void ShowInterstitialAd()
        {
            if (Advertisement.IsReady())
            {
                Advertisement.Show();
            }
            else
            {
                Debug.Log("Havuz boş");
            }
        }

    }
}