using UnityEngine;

public class TakeItemTouch : MonoBehaviour
{
    public int itemID;

    private void OnMouseUpAsButton()
    {
        if (Gcam.touchable)
        {
            Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[0]);
            gameObject.SetActive(false);
            Gitems.TakeItem(itemID);
        }
    }
}
