
using UnityEngine;
using UnityEngine.Advertisements;


namespace Ads
{
    public class RewardAdController : MonoBehaviour, IUnityAdsListener
    {
        private string _gameId = "1234567";
        private AdsPlacementType _placement = AdsPlacementType.rewardedVideo;


        private void Start()
        {
            Advertisement.AddListener(this);
            Advertisement.Initialize(_gameId, true);


        }
        private void Update()
        {
            if(Input.GetKeyUp(KeyCode.P))
            {
                ShowRewardedVideo();
            }
        }
        public void ShowRewardedVideo()
        {
            if (Advertisement.IsReady(_placement.ToString()))
            {
                Advertisement.Show(_placement.ToString());
            }
            else
            {
                Debug.LogWarning("Don't have any rewarded ads in the pool");
            }
        }

        void IUnityAdsListener.OnUnityAdsDidError(string message)
        {
           
        }

        void IUnityAdsListener.OnUnityAdsDidFinish(string placementId, ShowResult showResult)
        {
            switch (showResult)
            {
                case ShowResult.Failed:
                    //Dont give reward
                    break;
                case ShowResult.Skipped:
                    //Don'tGive reward
                    break;
                case ShowResult.Finished:
                    Debug.Log("REWARD TO PLAYER, MONEY TO ME");
                    break;
            }
        }

        void IUnityAdsListener.OnUnityAdsDidStart(string placementId)
        {
            
        }

        void IUnityAdsListener.OnUnityAdsReady(string placementId)
        {
           
        }
        public void OnDisable()
        {
            Advertisement.RemoveListener(this);
        }
    }
}
