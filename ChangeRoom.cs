using System;
using UnityEngine;
using UnityEngine.UI;

public class ChangeRoom : MonoBehaviour
{
    private int count = 0;
    public static bool doAction = false;
    private Color c = new Color(0f, 0f, 0f, 0f);

    public static Vector3 angleTemp;
    public static int angleDelta = 0;
    public static GameObject goTemp;

    public static void chrChangeRoom()
    {
        Gcam.touchable = false;
        Gcam.rotable = false;
        if (Gevents.gEvents[0] == 0)
        {
            angleTemp = new Vector3(0f, 0f, 0f);
            angleDelta = 1;
            goTemp = Ggos.g.goDoor1handle;
        }
        else
        {
            angleTemp = new Vector3(0f, 0f, 180f);
            angleDelta = -1;
            goTemp = Ggos.g.goDoor3handle;
        }        
        doAction = true;
    }

    private void FixedUpdate()
    {
        if (doAction)
        {
            if (count < 50)
            {
                if (count == 1) Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[7]);
                c.a += 0.02f;
                Ggos.g.goCanvas40BG.GetComponent<Image>().color = c;
                if (count < 25)
                {
                    angleTemp.z += angleDelta;
                    goTemp.transform.localEulerAngles = angleTemp;
                }
                else
                {
                    angleTemp.z -= angleDelta;
                    goTemp.transform.localEulerAngles = angleTemp;
                }

                count++;
            }
            if (count >= 50 && count < 75)
            {
                if (count == 51)
                {
                    if (Gevents.gEvents[0] == 0)
                    {
                        Gevents.WasEvent(0);
                        Gcam.PosReset();
                        Ggos.g.goRoom1.SetActive(false);
                        Ggos.g.goRoom2.SetActive(true);
                    }
                    else
                    {
                        Gevents.UnWasEvent(0);
                        Gcam.PosReset();
                        Ggos.g.goRoom2.SetActive(false);
                        Ggos.g.goRoom1.SetActive(true);
                    }
                    Ggos.g.goArrowImg1.SetActive(false);
                    AdvManager.AdvInterShow();
                }
                count++;
            }
            if (count >= 75)
            {
                c.a -= 0.02f;
                Ggos.g.goCanvas40BG.GetComponent<Image>().color = c;
                count++;
            }
            if (count == 125)
            {
                Gcam.touchable = true;
                Gcam.rotable = true;
                count = 0;
                doAction = false;
            }
        }
    }
}
