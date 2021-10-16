using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdManager : MonoBehaviour
{
    private BannerView bannerAd;
    private InterstitialAd interstitial;
    // private RewardBasedVideoAd rewardBasedVideo;
    // bool isRewarded = false;

    public static AdManager instance;

    private void Awake() {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(InitializationStatus => {});
        //Get Singleton reward based video ad reference.
        // this.rewardBasedVideo = RewardBasedVideoAd.Instance;

        //RewardBasedVideoAd is a singleton, so handlers should only be registered once.
        /* this.rewardBasedVideo.OnAdRewarded += this.HandleRewardBasedVideoRewarded;
        this.rewardBasedVideo.OnAdClosed += this.HandleRewardBasedVideoClosed; */

        // this.RequestRewardBasedVideo();

        this.RequestBanner();
    }

    /* private void Update()
    {
        if (isRewarded)
        {
            isRewarded = false;
            FindObjectOfType<CharacterSelector>().UnlockRandom();
        }
    } */

    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder().Build();
    }

    private void RequestBanner()
    {
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";
        this.bannerAd = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build();
        this.bannerAd.LoadAd(this.CreateAdRequest());
    }

    public void RequestInterstitial()
    {
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";
        //Clean up interstitail Ad before creating a new one.
        if(this.interstitial != null)
          this.interstitial.Destroy();

        //Create an interstitail.
        this.interstitial = new InterstitialAd(adUnitId);

        //Load an interstitail Ad.
        this.interstitial.LoadAd(this.CreateAdRequest());
    }

    public void ShowInterstitial()
    {
        if (this.interstitial.IsLoaded())
        {
            interstitial.Show();
        }
        else 
        {
            Debug.Log("Interstitial Ad is not ready yet");
        }
    }

    /* public void RequestRewardBasedVideo()
    {
        string adUnitId = "";

        this.rewardBasedVideo.LoadAd(this.CreateAdRequest(), adUnitId);
    }

    public void ShowRewardBasedVideo()
    {
        if(this.rewardBasedVideo.IsLoaded())
        {
            this.rewardBasedVideo.Show();
        }
    }

    #region RewardBasedVideo callback handlers

    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
         this.RequestRewardBasedVideo();
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
         isRewarded = true;
    }

    #endregion
    */
}
