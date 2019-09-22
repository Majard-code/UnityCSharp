using UnityEngine;

public class Gmenu : MonoBehaviour
{

    public static void MenuHide(bool mhCamera)
    {
        Ggos.g.goSoundImgOff.SetActive(false);
        Ggos.g.goSoundImgOn.SetActive(false);
        Ggos.g.goAdImg.SetActive(false);
        Ggos.g.goStarImg1.SetActive(false);
        Ggos.g.goStarImg2.SetActive(false);
        Ggos.g.goHelpImg.SetActive(false);
        Ggos.g.goHelpCount.SetActive(false);
        Ggos.g.goHelpCountInfin.SetActive(false);
        Ggos.g.goArrowImg1.SetActive(false);
        if (mhCamera)
        {
            Ggos.g.goItemCamera.SetActive(false);
        }
    }

    public static void MenuUnHide()
    {
        if (Gevents.gEvents[1] == 0)
        {
            Ggos.g.goSoundImgOff.SetActive(true);
        }
        else
        {
            Ggos.g.goSoundImgOn.SetActive(true);
        }

        if (Gevents.gEvents[2] == 0)
        {
            Ggos.g.goAdImg.SetActive(true);
        }

        if (Gevents.gEvents[3] == 0)
        {
            if (Gevents.gEvents[2] == 0)
            {
                Ggos.g.goStarImg2.SetActive(true);
            }
            else
            {
                Ggos.g.goStarImg1.SetActive(true);
            }
        }

        if (Ghelp.helpPoints == 777)
        {
            Ggos.g.goHelpCountInfin.SetActive(true);
        }
        else
        {
            Ghelp.RefreshCount();
            Ggos.g.goHelpCount.SetActive(true);
        }

        if (Gcam.myLoc != 0) Ggos.g.goArrowImg1.SetActive(true);

        Ggos.g.goHelpImg.SetActive(true);
        Ggos.g.goItemCamera.SetActive(true);
    }
}
