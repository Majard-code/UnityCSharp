using UnityEngine;
using UnityEngine.PostProcessing;

public class PPController : MonoBehaviour
{
    public static BloomModel.Settings blSettings = new BloomModel.Settings();
    public static PostProcessingProfile ppProfile;

    private void Start()
    {
        ppProfile = gameObject.GetComponent<PostProcessingBehaviour>().profile;
        blSettings = ppProfile.bloom.settings;
        blSettings.bloom.intensity = 0f;
        ppProfile.bloom.settings = blSettings;
    }

    public static void BloomOn()
    {
        blSettings.bloom.intensity = 2f;
        ppProfile.bloom.settings = blSettings;
    }
}
