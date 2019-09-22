
using UnityEngine;

public class ClearTouch : MonoBehaviour
{
    private void OnMouseDown()
    {
        Gevents.ClearAll();
        Debug.Log("Clear!");
    }
}
