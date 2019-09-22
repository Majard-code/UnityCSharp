using GoogleMobileAds.Api;
using UnityEngine;

public class AdvManager : MonoBehaviour
{
    // TEST
    public static readonly string advInter = "ca-app-pub-3940256099942544/1033173712";
    public static readonly string advRewar = "ca-app-pub-3940256099942544/5224354917";
    // REAL
    //public static readonly string advInter = "";
    //public static readonly string advRewar = "";

    public static InterstitialAd interstitial;
    public static AdRequest request;
    public static bool advLoaded = false;
    public static bool isLoading = false;

    private void Awake()
    {
        MobileAds.Initialize("");
        interstitial = new InterstitialAd(advInter);
        interstitial.OnAdLoaded += Interstitial_OnAdLoaded;
        interstitial.OnAdFailedToLoad += Interstitial_OnAdFailedToLoad;
        interstitial.OnAdClosed += Interstitial_OnAdClosed;
        AdvInterLoad();
    }

    private void Interstitial_OnAdClosed(object sender, System.EventArgs e)
    {
        advLoaded = false;
        AdvInterLoad();
    }

    private void Interstitial_OnAdFailedToLoad(object sender, AdFailedToLoadEventArgs e)
    {
        isLoading = false;
        advLoaded = false;
    }

    private void Interstitial_OnAdLoaded(object sender, System.EventArgs e)
    {
        isLoading = false;
        advLoaded = true;
    }

    public static void AdvInterLoad()
    {
        if (Gevents.gEvents[2] == 0)
        {
            isLoading = true;
            request = new AdRequest.Builder().Build();
            interstitial.LoadAd(request);
        }
    }

    public static void AdvInterShow()
    {
        if (Gevents.gEvents[2] == 0)
        {
            if (interstitial.IsLoaded()) interstitial.Show();
        }
    }
}
