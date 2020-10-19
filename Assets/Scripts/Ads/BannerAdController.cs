using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAdController : MonoBehaviour
{
    private string _gameId = "1234567";
    private AdsPlacementType _placement = AdsPlacementType.bannerPlacement;


    private void Start()
    {
        
        Advertisement.Initialize(_gameId, true);
    }

    private void Update()
    {
        ShowBannerAds();
        
    }

    private void ShowBannerAds()
    {

        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(_placement.ToString());
    }
}
