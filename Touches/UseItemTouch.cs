using UnityEngine;

public class UseItemTouch : MonoBehaviour
{
    public int useItemID;
    public int eventID;
    public bool delItem;

    private void OnMouseUpAsButton()
    {
        if (Gcam.touchable)
        {
            Gitems.UseItem(useItemID, eventID, delItem);
        }
    }
}
