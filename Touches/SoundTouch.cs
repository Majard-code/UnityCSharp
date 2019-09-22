using UnityEngine;

public class SoundTouch : MonoBehaviour
{    
    private void OnMouseDown()
    {
        if (Gcam.touchable)
        {
            if (Gevents.gEvents[1] == 0)
            {
                Ggos.g.goSoundImgOff.SetActive(false);
                Ggos.g.goSoundImgOn.SetActive(true);

                Ggos.g.goMainCamera.GetComponent<AudioSource>().mute = true;

                Gevents.WasEvent(1);
            }
            else
            {
                Ggos.g.goSoundImgOff.SetActive(true);
                Ggos.g.goSoundImgOn.SetActive(false);

                Ggos.g.goMainCamera.GetComponent<AudioSource>().mute = false;

                Gevents.UnWasEvent(1);
            }
        }
    }
}
