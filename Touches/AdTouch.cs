using UnityEngine;

public class AdTouch : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (Gevents.gEvents[2] == 0)
        {
            Gevents.WasEvent(2);
        }
        else
        {
            Gevents.UnWasEvent(2);
        }
    }
}
