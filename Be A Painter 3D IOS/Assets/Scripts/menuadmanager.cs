using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class menuadmanager : MonoBehaviour
{
    private BannerView bannerView;

    [System.Obsolete]
    void Start()
    {
        MobileAds.Initialize(initstatus => { });

        this.RequestBanner();
    }

    [System.Obsolete]
    private void RequestBanner()
    {

#if UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
  private string _adUnitId = "unused";
#endif
        this.bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Top);

        AdRequest request = new AdRequest.Builder().Build();

        this.bannerView.LoadAd(request);

    }

    public void destroyBanner()
    {
        if (bannerView != null)
        {
            bannerView.Destroy();
            bannerView = null;
        }
    }
}
