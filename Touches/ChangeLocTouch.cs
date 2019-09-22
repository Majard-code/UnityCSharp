using UnityEngine;

public class ChangeLocTouch : MonoBehaviour
{
    public int eventID;
    public bool wasEvent;
    public bool checkEvent;
    public int targetLoc;

    private void OnMouseUpAsButton()
    {
        if (Gcam.touchable)
        {
            if (checkEvent)
            {
                if (wasEvent)
                {
                    if (Gevents.gEvents[eventID] == 1)
                    {
                        Gcam.ChangeLocation(targetLoc);
                    }
                }
                else
                {
                    if (Gevents.gEvents[eventID] == 0)
                    {
                        Gcam.ChangeLocation(targetLoc);
                    }
                }
            }
            else
            {
                Gcam.ChangeLocation(targetLoc);
            }
        }
    }
}
