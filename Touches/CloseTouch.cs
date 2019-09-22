using UnityEngine;

public class CloseTouch : MonoBehaviour
{
    public int eventID;
    private void OnMouseUpAsButton()
    {
        if (Gcam.touchable)
        {
            if (Gevents.gEvents[eventID] == 0)
            {
                Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[1]);
            }
        }
    }
}
