using UnityEngine;

public class ItemsTouch : MonoBehaviour
{
    public int itItemID;

    private void OnMouseDown()
    {
        Gitems.ItemPressed(itItemID);
    }
}
