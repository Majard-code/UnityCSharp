using System;
using UnityEngine;

public class Code3Touch : MonoBehaviour
{
    public int bookID;

    private Vector3 posTemp;

    private bool doChange = false;
    private int count = 0;

    private void OnMouseUpAsButton()
    {
        if (Gcam.touchable)
        {
            Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[0]);
            if (Codes.firstBook3 == null)
            {
                posTemp = Ggos.g.goBookshelf2books[bookID].transform.localPosition;
                posTemp.y = 0.02f;
                Ggos.g.goBookshelf2books[bookID].transform.localPosition = posTemp;

                Codes.firstBook3 = bookID;
            }
            else
            {
                if (Codes.firstBook3 == bookID)
                {
                    posTemp = Ggos.g.goBookshelf2books[bookID].transform.localPosition;
                    posTemp.y = 0f;
                    Ggos.g.goBookshelf2books[bookID].transform.localPosition = posTemp;

                    Codes.firstBook3 = null;
                }
                else
                {
                    posTemp = Ggos.g.goBookshelf2books[bookID].transform.localPosition;
                    posTemp.y = 0.02f;
                    Ggos.g.goBookshelf2books[bookID].transform.localPosition = posTemp;
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

            switch (count)
            {
                case 5:
                    Ggos.g.goBookshelf2books[(int)Codes.firstBook3].GetComponent<MeshRenderer>().material = Ggos.g.mats[0];
                    Ggos.g.goBookshelf2books[bookID].GetComponent<MeshRenderer>().material = Ggos.g.mats[0];

                    Ggos.g.goBookshelf2books[(int)Codes.firstBook3].transform.localPosition = Codes.bookPos[Array.IndexOf(Codes.codeReal[3], bookID)];
                    Ggos.g.goBookshelf2books[bookID].transform.localPosition = Codes.bookPos[Array.IndexOf(Codes.codeReal[3], (int)Codes.firstBook3)];

                    count++;
                    break;
                case 10:
                    Ggos.g.goBookshelf2books[(int)Codes.firstBook3].GetComponent<MeshRenderer>().material = Ggos.g.mats[4];
                    Ggos.g.goBookshelf2books[bookID].GetComponent<MeshRenderer>().material = Ggos.g.mats[4];
                    count++;
                    break;
                case 15:
                    posTemp = Ggos.g.goBookshelf2books[(int)Codes.firstBook3].transform.localPosition;
                    posTemp.y = 0f;
                    Ggos.g.goBookshelf2books[(int)Codes.firstBook3].transform.localPosition = posTemp;

                    posTemp = Ggos.g.goBookshelf2books[bookID].transform.localPosition;
                    posTemp.y = 0f;
                    Ggos.g.goBookshelf2books[bookID].transform.localPosition = posTemp;

                    Codes.Swap(3, Array.IndexOf(Codes.codeReal[3], (int)Codes.firstBook3), Array.IndexOf(Codes.codeReal[3], bookID));
                    Debug.Log(Codes.codeReal[3][0].ToString() + " * " + Codes.codeReal[3][1].ToString() + " * " + Codes.codeReal[3][2].ToString() + " * " + Codes.codeReal[3][3].ToString() + " * " + Codes.codeReal[3][4].ToString() + " * " + Codes.codeReal[3][5].ToString() + " * " + Codes.codeReal[3][6].ToString());

                    Codes.firstBook3 = null;
                    Gcam.touchable = true;

                    Codes.CheckCode(3);

                    doChange = false;
                    count = 0;
                    break;
                default:
                    count++;
                    break;
            }
        }
    }
}
