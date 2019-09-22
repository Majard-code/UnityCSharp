using UnityEngine;

public class Ganim : MonoBehaviour
{
    public void StartAnimMiddle()
    {
        PPController.BloomOn();
    }

    public void GameNameAnimEnd()
    {
        Ggos.g.goCanvas1BG.SetActive(false);
        Ggos.g.goGameName.SetActive(false);

        Gitems.CamResizeToSmall();
    }

    public void AnyAnimEnd()
    {
        Gcam.touchable = true;
    }

}
