using System;
using UnityEngine;

public class Code4Touch : MonoBehaviour
{
    public int picID;
    public static Vector3 target1Pos, target2Pos;
    public static Vector3 smallScale = new Vector3(0.9f, 0.9f, 0.9f);
    public static Vector3 normScale = new Vector3(1f, 1f, 1f);

    private bool doChange = false;


    private void OnMouseUpAsButton()
    {
        if (Gcam.touchable)
        {
            Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[0]);

            if (Codes.firstPic4 == null)
            {
                target1Pos = Ggos.g.goPic4pieces[picID].transform.localPosition;
                target1Pos.z = -0.01f;
                Ggos.g.goPic4pieces[picID].transform.localPosition = target1Pos;
                Ggos.g.goPic4pieces[picID].transform.localScale = smallScale;

                Codes.firstPic4 = picID;
            }
            else
            {
                if (Codes.firstPic4 == picID)
                {
                    target1Pos = Ggos.g.goPic4pieces[picID].transform.localPosition;
                    target1Pos.z = -0.02f;
                    Ggos.g.goPic4pieces[picID].transform.localPosition = target1Pos;
                    Ggos.g.goPic4pieces[picID].transform.localScale = normScale;

                    Codes.firstPic4 = null;
                }
                else
                {
                    target2Pos = Ggos.g.goPic4pieces[picID].transform.localPosition;
                    target2Pos.z = -0.03f;
                    Ggos.g.goPic4pieces[picID].transform.localPosition = target2Pos;
                    Ggos.g.goPic4pieces[picID].transform.localScale = smallScale;
                    target1Pos.z = -0.03f;
                    target2Pos.z = -0.01f;
                    Gcam.touchable = false;
                    doChange = true;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (doChange)
        {
            Ggos.g.goPic4pieces[(int)Codes.firstPic4].transform.localPosition = Vector3.Lerp(Ggos.g.goPic4pieces[(int)Codes.firstPic4].transform.localPosition, target2Pos, 0.5f);
            Ggos.g.goPic4pieces[picID].transform.localPosition = Vector3.Lerp(Ggos.g.goPic4pieces[picID].transform.localPosition, target1Pos, 0.5f);

            if (Ggos.g.goPic4pieces[(int)Codes.firstPic4].transform.localPosition == target2Pos)
            {
                target2Pos.z = -0.02f;
                Ggos.g.goPic4pieces[(int)Codes.firstPic4].transform.localPosition = target2Pos;
                Ggos.g.goPic4pieces[(int)Codes.firstPic4].transform.localScale = normScale;

                target1Pos.z = -0.02f;
                Ggos.g.goPic4pieces[picID].transform.localPosition = target1Pos;
                Ggos.g.goPic4pieces[picID].transform.localScale = normScale;



                Codes.Swap(4, Array.IndexOf(Codes.codeReal[4], (int)Codes.firstPic4), Array.IndexOf(Codes.codeReal[4], picID));
                Debug.Log(Codes.codeReal[4][0].ToString() + " * " + Codes.codeReal[4][1].ToString() + " * " + Codes.codeReal[4][2].ToString() + " * " + Codes.codeReal[4][3].ToString() + " * " + Codes.codeReal[4][4].ToString() + " * " + Codes.codeReal[4][5].ToString() + " * " + Codes.codeReal[4][6].ToString() + " * " + Codes.codeReal[4][7].ToString() + " * " + Codes.codeReal[4][8].ToString());

                Codes.firstPic4 = null;
                Gcam.touchable = true;

                Codes.CheckCode(4);

                doChange = false;
            }
        }
    }
}
