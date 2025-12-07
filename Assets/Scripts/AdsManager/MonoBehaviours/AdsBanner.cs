using GoogleMobileAds.Api;
using System;
using System.Collections.Generic;
using UnityEngine;

public class AdsBanner : MonoBehaviour
{
    // These ad units are configured to always serve test ads.
#if UNITY_ANDROID
    private string _adUnitId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
  private string _adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
  private string _adUnitId = "unused";
#endif

    [SerializeField]
    List<Vector2> positions = new List<Vector2>();
    [SerializeField]
    List<Vector2> sizes = new List<Vector2>();
    [SerializeField]

    public AdPosition staticPosition = AdPosition.Top;
    [SerializeField]
    bool useCustomPos = false;
    private void OnEnable()
    {
        LoadAd();
    }

    BannerView _bannerView;

    /// <summary>
    /// Creates a 320x50 banner view at top of the screen.
    /// </summary>
    public void CreateBannerView()
    {
        Debug.Log("Creating banner view");

        // If we already have a banner, destroy the old one.
        if (_bannerView != null)
        {
            DestroyAd();
        }
        AdSize adaptiveSize =
                AdSize.GetLandscapeAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);
        // Create a 320x50 banner at top of the screen

        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        float aspectRatio = screenWidth / screenHeight;
        Debug.Log("Screen Width " + (aspectRatio));
        
        if(useCustomPos)
        {
            if (aspectRatio > 2 && aspectRatio < 2.5f)
                _bannerView = new BannerView(_adUnitId, AdSize.Banner, (int)positions[0].x, (int)positions[0].y);//400
            else if (aspectRatio < 2)
                _bannerView = new BannerView(_adUnitId, AdSize.Banner, (int)positions[1].x, (int)positions[1].y);//250
            else
                _bannerView = new BannerView(_adUnitId, AdSize.Banner, (int)positions[2].x, (int)positions[2].y);//500
        }
        else
        {
            if (aspectRatio > 2 && aspectRatio < 2.5f)
                _bannerView = new BannerView(_adUnitId, adaptiveSize, staticPosition);//400
            else if (aspectRatio < 2)
                _bannerView = new BannerView(_adUnitId, adaptiveSize, staticPosition);//250
            else
                _bannerView = new BannerView(_adUnitId, adaptiveSize, staticPosition);//500
        }
        
        

    }

    /// <summary>
    /// Creates the banner view and loads a banner ad.
    /// </summary>
    public void LoadAd()
    {
        // create an instance of a banner view first.
        if (_bannerView == null)
        {
            CreateBannerView();
        }

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        Debug.Log("Loading banner ad.");
        _bannerView.LoadAd(adRequest);
    }

    /// <summary>
    /// Destroys the banner view.
    /// </summary>
    public void DestroyAd()
    {
        if (_bannerView != null)
        {
            Debug.Log("Destroying banner view.");
            _bannerView.Destroy();
            _bannerView = null;
        }
    }

    /// <summary>
    /// listen to events the banner view may raise.
    /// </summary>
    private void ListenToAdEvents()
    {
        // Raised when an ad is loaded into the banner view.
        _bannerView.OnBannerAdLoaded += () =>
        {
            Debug.Log("Banner view loaded an ad with response : "
                + _bannerView.GetResponseInfo());
        };
        // Raised when an ad fails to load into the banner view.
        _bannerView.OnBannerAdLoadFailed += (LoadAdError error) =>
        {
            Debug.LogError("Banner view failed to load an ad with error : "
                + error);
        };
        // Raised when the ad is estimated to have earned money.
        _bannerView.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(String.Format("Banner view paid {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };
        // Raised when an impression is recorded for an ad.
        _bannerView.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Banner view recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        _bannerView.OnAdClicked += () =>
        {
            Debug.Log("Banner view was clicked.");
        };
        // Raised when an ad opened full screen content.
        _bannerView.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Banner view full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        _bannerView.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Banner view full screen content closed.");
        };
    }

    private void OnDisable()
    {
        DestroyAd();
    }
}
