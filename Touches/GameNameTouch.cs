using UnityEngine;

public class GameNameTouch : MonoBehaviour
{
    private void OnMouseDown()
    {
        Ggos.g.goGameManager.GetComponent<Animation>().Play("StartAnim");
    }
}
