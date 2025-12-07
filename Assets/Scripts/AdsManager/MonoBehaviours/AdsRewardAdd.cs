using GoogleMobileAds.Api;
using UnityEngine;
using UnityEngine.Events;

public class AdsRewardAdd : MonoBehaviour
{
#if UNITY_ANDROID
    private const string AD_UNIT_ID = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
        private const string AD_UNIT_ID = "ca-app-pub-3940256099942544/1712485313";
#else
        private const string AD_UNIT_ID = "unused";
#endif

    [SerializeField]
    UnityEvent toDoWhenGetReward;

    // Create our request used to load the ad.
    AdRequest adRequest = null;
    RewardedAd rewardedAd = null;
    public void LoadAdd()
    {
        adRequest = new AdRequest();
        // Send the request to load the ad.
        RewardedAd.Load(AD_UNIT_ID, adRequest, (RewardedAd ad, LoadAdError error) =>
        {
            if (error != null)
            {
                // The ad failed to load.
                return;
            }
            this.rewardedAd = ad;
            // The ad loaded successfully.
        });
    }

    public void ShowAd()
    {
        // [START show_ad]
        if (rewardedAd != null && rewardedAd.CanShowAd())
        {
            rewardedAd.Show((Reward reward) =>
            {
                Debug.Log("Show The reward add");
                toDoWhenGetReward.Invoke();
            });
        }
        // [END show_ad]]
    }
}
