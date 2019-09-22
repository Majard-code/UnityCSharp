using System;
using UnityEngine;

public class Code2Touch : MonoBehaviour
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
            if (Codes.firstBook2 == null)
            {
                posTemp = Ggos.g.goBookshelf3books[bookID].transform.localPosition;
                posTemp.y = 0.02f;
                Ggos.g.goBookshelf3books[bookID].transform.localPosition = posTemp;

                Codes.firstBook2 = bookID;
            }
            else
            {
                if (Codes.firstBook2 == bookID)
                {
                    posTemp = Ggos.g.goBookshelf3books[bookID].transform.localPosition;
                    posTemp.y = 0f;
                    Ggos.g.goBookshelf3books[bookID].transform.localPosition = posTemp;

                    Codes.firstBook2 = null;
                }
                else
                {
                    posTemp = Ggos.g.goBookshelf3books[bookID].transform.localPosition;
                    posTemp.y = 0.02f;
                    Ggos.g.goBookshelf3books[bookID].transform.localPosition = posTemp;
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
                    Ggos.g.goBookshelf3books[(int)Codes.firstBook2].GetComponent<MeshRenderer>().material = Ggos.g.mats[0];
                    Ggos.g.goBookshelf3books[bookID].GetComponent<MeshRenderer>().material = Ggos.g.mats[0];

                    Ggos.g.goBookshelf3books[(int)Codes.firstBook2].transform.localPosition = Codes.bookPos[Array.IndexOf(Codes.codeReal[2], bookID)];
                    Ggos.g.goBookshelf3books[bookID].transform.localPosition = Codes.bookPos[Array.IndexOf(Codes.codeReal[2], (int)Codes.firstBook2)];

                    count++;
                    break;
                case 10:
                    Ggos.g.goBookshelf3books[(int)Codes.firstBook2].GetComponent<MeshRenderer>().material = Ggos.g.mats[4];
                    Ggos.g.goBookshelf3books[bookID].GetComponent<MeshRenderer>().material = Ggos.g.mats[4];
                    count++;
                    break;
                case 15:
                    posTemp = Ggos.g.goBookshelf3books[(int)Codes.firstBook2].transform.localPosition;
                    posTemp.y = 0f;
                    Ggos.g.goBookshelf3books[(int)Codes.firstBook2].transform.localPosition = posTemp;

                    posTemp = Ggos.g.goBookshelf3books[bookID].transform.localPosition;
                    posTemp.y = 0f;
                    Ggos.g.goBookshelf3books[bookID].transform.localPosition = posTemp;

                    Codes.Swap(2, Array.IndexOf(Codes.codeReal[2], (int)Codes.firstBook2), Array.IndexOf(Codes.codeReal[2], bookID));
                    Debug.Log(Codes.codeReal[2][0].ToString() + " * " + Codes.codeReal[2][1].ToString() + " * " + Codes.codeReal[2][2].ToString() + " * " + Codes.codeReal[2][3].ToString() + " * " + Codes.codeReal[2][4].ToString() + " * " + Codes.codeReal[2][5].ToString() + " * " + Codes.codeReal[2][6].ToString());
                    Codes.firstBook2 = null;
                    Gcam.touchable = true;

                    Codes.CheckCode(2);

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
