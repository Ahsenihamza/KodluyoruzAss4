using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndManager : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            EventManager.TriggerPlayAds(AdsPlacementType.rewardedVideo);
            SceneManager.LoadScene("UIEndScene");
            SceneManager.UnloadSceneAsync("SampleScene");
            
        }
    }

   

}
