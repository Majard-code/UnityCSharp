using UnityEngine;

public class ChangeRoomTouch : MonoBehaviour
{
    private void OnMouseUpAsButton()
    {
        if (Gcam.touchable)
        {
            if (Gevents.gEvents[10] == 1)
            {
                ChangeRoom.chrChangeRoom();
            }
        }
    }
}
