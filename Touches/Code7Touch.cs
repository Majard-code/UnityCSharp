using System;
using UnityEngine;

public class Code7Touch : MonoBehaviour
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

            if (Codes.firstPic7 == null)
            {
                target1Pos = Ggos.g.goPic2pieces[picID].transform.localPosition;
                target1Pos.z = -0.01f;
                Ggos.g.goPic2pieces[picID].transform.localPosition = target1Pos;
                Ggos.g.goPic2pieces[picID].transform.localScale = smallScale;

                Codes.firstPic7 = picID;
            }
            else
            {
                if (Codes.firstPic7 == picID)
                {
                    target1Pos = Ggos.g.goPic2pieces[picID].transform.localPosition;
                    target1Pos.z = -0.02f;
                    Ggos.g.goPic2pieces[picID].transform.localPosition = target1Pos;
                    Ggos.g.goPic2pieces[picID].transform.localScale = normScale;

                    Codes.firstPic7 = null;
                }
                else
                {
                    target2Pos = Ggos.g.goPic2pieces[picID].transform.localPosition;
                    target2Pos.z = -0.03f;
                    Ggos.g.goPic2pieces[picID].transform.localPosition = target2Pos;
                    Ggos.g.goPic2pieces[picID].transform.localScale = smallScale;
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
            Ggos.g.goPic2pieces[(int)Codes.firstPic7].transform.localPosition = Vector3.Lerp(Ggos.g.goPic2pieces[(int)Codes.firstPic7].transform.localPosition, target2Pos, 0.5f);
            Ggos.g.goPic2pieces[picID].transform.localPosition = Vector3.Lerp(Ggos.g.goPic2pieces[picID].transform.localPosition, target1Pos, 0.5f);

            if (Ggos.g.goPic2pieces[(int)Codes.firstPic7].transform.localPosition == target2Pos)
            {
                target2Pos.z = -0.02f;
                Ggos.g.goPic2pieces[(int)Codes.firstPic7].transform.localPosition = target2Pos;
                Ggos.g.goPic2pieces[(int)Codes.firstPic7].transform.localScale = normScale;

                target1Pos.z = -0.02f;
                Ggos.g.goPic2pieces[picID].transform.localPosition = target1Pos;
                Ggos.g.goPic2pieces[picID].transform.localScale = normScale;



                Codes.Swap(7, Array.IndexOf(Codes.codeReal[7], (int)Codes.firstPic7), Array.IndexOf(Codes.codeReal[7], picID));
                Debug.Log(Codes.codeReal[7][0].ToString() + " * " + Codes.codeReal[7][1].ToString() + " * " + Codes.codeReal[7][2].ToString() + " * " + Codes.codeReal[7][3].ToString() + " * " + Codes.codeReal[7][4].ToString() + " * " + Codes.codeReal[7][5].ToString() + " * " + Codes.codeReal[7][6].ToString() + " * " + Codes.codeReal[7][7].ToString() + " * " + Codes.codeReal[7][8].ToString());

                Codes.firstPic7 = null;
                Gcam.touchable = true;

                Codes.CheckCode(7);

                doChange = false;
            }
        }
    }
}
