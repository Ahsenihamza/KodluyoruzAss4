using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void AdsEvent(AdsPlacementType type);

    public static event AdsEvent PlayAdsEvent;

    public static void TriggerPlayAds(AdsPlacementType type)
    {
        PlayAdsEvent?.Invoke(type);
    }
}
