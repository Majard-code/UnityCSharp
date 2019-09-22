using System;
using UnityEngine;

public class Gevents : MonoBehaviour
{
    public static int[] gEvents = new int[93];
    public static Material[] matsBuff;
    public static Vector3 v3Buff;

    private void Start()
    {
        LoadEvents();
        CheckEvents();
    }

    public static void CheckEvents()
    {
        if (gEvents[0] == 1)
        {
            Ggos.g.goRoom1.SetActive(false);
            Ggos.g.goRoom2.SetActive(true);
        }
        else
        {
            Ggos.g.goRoom1.SetActive(true);
            Ggos.g.goRoom2.SetActive(false);
        }
        if (gEvents[1] == 1)
        {
            Ggos.g.goMainCamera.GetComponent<AudioSource>().mute = true;
        }
        if (gEvents[4] == 1)
        {
            Ggos.g.goTv1remote0.SetActive(false);
        }
        if (gEvents[5] == 1)
        {
            Ggos.g.goTv100.SetActive(false);
            Ggos.g.goTv11.SetActive(true);
        }
        if (gEvents[6] == 1)
        {
            matsBuff = Ggos.g.goLamp1rolls[0].GetComponent<MeshRenderer>().materials;
            matsBuff[1] = Ggos.g.mats[2];
            matsBuff[6] = Ggos.g.mats[3];
            Ggos.g.goLamp1rolls[0].GetComponent<MeshRenderer>().materials = matsBuff;
            Ggos.g.goLamp1rolls[0].transform.localEulerAngles = new Vector3(0f, 300f, 0f);
            matsBuff = Ggos.g.goLamp1rolls[1].GetComponent<MeshRenderer>().materials;
            matsBuff[1] = Ggos.g.mats[2];
            matsBuff[4] = Ggos.g.mats[3];
            Ggos.g.goLamp1rolls[1].GetComponent<MeshRenderer>().materials = matsBuff;
            Ggos.g.goLamp1rolls[1].transform.localEulerAngles = new Vector3(0f, 180f, 0f);
            matsBuff = Ggos.g.goLamp1rolls[2].GetComponent<MeshRenderer>().materials;
            matsBuff[1] = Ggos.g.mats[2];
            matsBuff[2] = Ggos.g.mats[3];
            Ggos.g.goLamp1rolls[2].GetComponent<MeshRenderer>().materials = matsBuff;
            Ggos.g.goLamp1rolls[2].transform.localEulerAngles = new Vector3(0f, 60f, 0f);
            matsBuff = Ggos.g.goLamp1rolls[3].GetComponent<MeshRenderer>().materials;
            matsBuff[1] = Ggos.g.mats[2];
            matsBuff[5] = Ggos.g.mats[3];
            Ggos.g.goLamp1rolls[3].GetComponent<MeshRenderer>().materials = matsBuff;
            Ggos.g.goLamp1rolls[3].transform.localEulerAngles = new Vector3(0f, 240f, 0f);
        }
        if (gEvents[8] == 1)
        {
            Ggos.g.goBookshelf3books[3].transform.localPosition = new Vector3(-0.24f, 0f, 0f);
            Ggos.g.goBookshelf3books[0].transform.localPosition = new Vector3(-0.16f, 0f, 0f);
            Ggos.g.goBookshelf3books[6].transform.localPosition = new Vector3(-0.08f, 0f, 0f);
            Ggos.g.goBookshelf3books[4].transform.localPosition = new Vector3(0f, 0f, 0f);
            Ggos.g.goBookshelf3books[2].transform.localPosition = new Vector3(0.08f, 0f, 0f);
            Ggos.g.goBookshelf3books[1].transform.localPosition = new Vector3(0.16f, 0f, 0f);
            Ggos.g.goBookshelf3books[5].transform.localPosition = new Vector3(0.24f, 0f, 0f);
            Ggos.g.goBookshelf3in.transform.localPosition = new Vector3(0f, 0.16f, 0f);
        }
        if (gEvents[9] == 1)
        {
            Ggos.g.goDoor1key0.SetActive(false);
        }
        if (gEvents[10] == 1)
        {
            Ggos.g.goDoor1key1.SetActive(true);
        }
        if (gEvents[12] == 1)
        {
            Ggos.g.goBookshelf2books[1].transform.localPosition = new Vector3(-0.24f, 0f, 0f);
            Ggos.g.goBookshelf2books[5].transform.localPosition = new Vector3(-0.16f, 0f, 0f);
            Ggos.g.goBookshelf2books[0].transform.localPosition = new Vector3(-0.08f, 0f, 0f);
            Ggos.g.goBookshelf2books[3].transform.localPosition = new Vector3(0f, 0f, 0f);
            Ggos.g.goBookshelf2books[6].transform.localPosition = new Vector3(0.08f, 0f, 0f);
            Ggos.g.goBookshelf2books[2].transform.localPosition = new Vector3(0.16f, 0f, 0f);
            Ggos.g.goBookshelf2books[4].transform.localPosition = new Vector3(0.24f, 0f, 0f);
            Ggos.g.goBookshelf2in.transform.localPosition = new Vector3(0f, 0.16f, 0f);
        }
        if (gEvents[13] == 1)
        {
            Ggos.g.goWrenchdriver0.SetActive(false);
        }
        if (gEvents[14] == 1)
        {
            Ggos.g.goVentilation1grid.SetActive(false);
            for (int i = 0; i < Ggos.g.goVentilation1bolts.Length; i++) Ggos.g.goVentilation1bolts[i].SetActive(false);
        }
        if (gEvents[15] == 1)
        {
            Ggos.g.goBureau1key20.SetActive(false);
        }
        if (gEvents[16] == 1)
        {
            Ggos.g.goBureau1key2.SetActive(true);
        }
        if (gEvents[17] == 1)
        {
            Ggos.g.goPic4piece40.SetActive(false);
        }
        if (gEvents[18] == 1)
        {
            Ggos.g.goPic4pieces[3].SetActive(true);
        }
        if (gEvents[19] == 0)
        {
            for (int i = 0; i < 9; i++) Ggos.g.goPic4pieces[i].transform.localPosition = Codes.picPos[Array.IndexOf(Codes.codeReal[4], i)];
        }
        else
        {
            Ggos.g.goPic4P.SetActive(false);
            v3Buff = Ggos.g.goSafe2.transform.localPosition;
            v3Buff.z = -2.1f;
            Ggos.g.goSafe2.transform.localPosition = v3Buff;
        }
        if (gEvents[21] == 1)
        {
            v3Buff = new Vector3(0f, 180f, 0f);
            Ggos.g.goSafe2codes[0].transform.localEulerAngles = v3Buff;
            v3Buff = new Vector3(-0.125f, 0.37f, 0.035f);
            Ggos.g.goSafe2codes[0].transform.localPosition = v3Buff;

            v3Buff = new Vector3(180f, 0f, 270f);
            Ggos.g.goSafe2codes[1].transform.localEulerAngles = v3Buff;
            v3Buff = new Vector3(0.37f, 0.125f, 0.035f);
            Ggos.g.goSafe2codes[1].transform.localPosition = v3Buff;

            v3Buff = new Vector3(180f, 0f, 90f);
            Ggos.g.goSafe2codes[2].transform.localEulerAngles = v3Buff;
            v3Buff = new Vector3(-0.37f, -0.125f, 0.035f);
            Ggos.g.goSafe2codes[2].transform.localPosition = v3Buff;

            v3Buff = new Vector3(0f, 180f, 180f);
            Ggos.g.goSafe2codes[3].transform.localEulerAngles = v3Buff;
            v3Buff = new Vector3(0.125f, -0.37f, 0.035f);
            Ggos.g.goSafe2codes[3].transform.localPosition = v3Buff;
        }
        if (gEvents[22] == 1)
        {
            Ggos.g.goScrewdriver0.SetActive(false);
        }
        if (gEvents[23] == 1)
        {
            Ggos.g.goSp1door.SetActive(false);
            for (int i = 0; i < Ggos.g.goSp1screws.Length; i++) Ggos.g.goSp1screws[i].SetActive(false);
        }
        if (gEvents[24] == 1)
        {
            Ggos.g.goSp2door.SetActive(false);
            for (int i = 0; i < Ggos.g.goSp2screws.Length; i++) Ggos.g.goSp2screws[i].SetActive(false);
        }
        if (gEvents[25] == 1)
        {
            matsBuff = Ggos.g.goLamp2rolls[0].GetComponent<MeshRenderer>().materials;
            matsBuff[1] = Ggos.g.mats[2];
            matsBuff[4] = Ggos.g.mats[3];
            Ggos.g.goLamp2rolls[0].GetComponent<MeshRenderer>().materials = matsBuff;
            Ggos.g.goLamp2rolls[0].transform.localEulerAngles = new Vector3(0f, 180f, 0f);
            matsBuff = Ggos.g.goLamp2rolls[1].GetComponent<MeshRenderer>().materials;
            matsBuff[1] = Ggos.g.mats[2];
            matsBuff[3] = Ggos.g.mats[3];
            Ggos.g.goLamp2rolls[1].GetComponent<MeshRenderer>().materials = matsBuff;
            Ggos.g.goLamp2rolls[1].transform.localEulerAngles = new Vector3(0f, 120f, 0f);
            matsBuff = Ggos.g.goLamp2rolls[2].GetComponent<MeshRenderer>().materials;
            matsBuff[1] = Ggos.g.mats[2];
            matsBuff[6] = Ggos.g.mats[3];
            Ggos.g.goLamp2rolls[2].GetComponent<MeshRenderer>().materials = matsBuff;
            Ggos.g.goLamp2rolls[2].transform.localEulerAngles = new Vector3(0f, 300f, 0f);
            matsBuff = Ggos.g.goLamp2rolls[3].GetComponent<MeshRenderer>().materials;
            matsBuff[1] = Ggos.g.mats[2];
            matsBuff[2] = Ggos.g.mats[3];
            Ggos.g.goLamp2rolls[3].GetComponent<MeshRenderer>().materials = matsBuff;
            Ggos.g.goLamp2rolls[3].transform.localEulerAngles = new Vector3(0f, 60f, 0f);
        }
        if (gEvents[26] == 1)
        {
            Ggos.g.goSmallcogwheel1.SetActive(false);
        }
        if (gEvents[27] == 1)
        {
            Ggos.g.goBigcogwheel1.SetActive(false);
        }
        if (gEvents[28] == 1)
        {
            Ggos.g.goSp1cogwheels[2].SetActive(true);
        }
        if (gEvents[29] == 1)
        {
            Ggos.g.goSp2cogwheels[1].SetActive(true);
        }
        if (gEvents[30] == 1)
        {
            Ggos.g.goPic2piece80.SetActive(false);
        }
        if (gEvents[31] == 1)
        {
            Ggos.g.goPic2pieces[7].SetActive(true);
        }
        if (gEvents[32] == 0)
        {
            for (int i = 0; i < 9; i++) Ggos.g.goPic2pieces[i].transform.localPosition = Codes.picPos[Array.IndexOf(Codes.codeReal[7], i)];
        }
        else
        {
            for (int i = 0; i < 9; i++) Ggos.g.goPic2pieces[i].transform.localPosition = Codes.picPos[Array.IndexOf(Codes.codeRight[7], i)];
            Ggos.g.goPic2pieces[4].SetActive(false);
        }
        if (gEvents[33] == 1)
        {
            v3Buff = Ggos.g.goPic2indoor1.transform.localPosition;
            v3Buff.x = -0.1f;
            Ggos.g.goPic2indoor1.transform.localPosition = v3Buff;
            v3Buff = Ggos.g.goPic2indoor2.transform.localPosition;
            v3Buff.x = 0.1f;
            Ggos.g.goPic2indoor2.transform.localPosition = v3Buff;
        }
        if (gEvents[34] == 1)
        {
            Ggos.g.goPic1piece70.SetActive(false);
        }
        if (gEvents[35] == 1)
        {
            Ggos.g.goPic1pieces[6].SetActive(true);
        }
        if (gEvents[36] == 0)
        {
            for (int i = 0; i < 9; i++) Ggos.g.goPic1pieces[i].transform.localPosition = Codes.picPos[Array.IndexOf(Codes.codeReal[8], i)];
        }
        else
        {
            for (int i = 0; i < 9; i++) Ggos.g.goPic1pieces[i].transform.localPosition = Codes.picPos[Array.IndexOf(Codes.codeRight[8], i)];
            Ggos.g.goPic1pieces[4].SetActive(false);
        }
        if (gEvents[37] == 1)
        {
            Ggos.g.goVentilation2grid.SetActive(false);
        }
        if (gEvents[38] == 1)
        {
            Ggos.g.goPic3piece90.SetActive(false);
        }
        if (gEvents[39] == 1)
        {
            Ggos.g.goPic3pieces[8].SetActive(true);
        }
        if (gEvents[40] == 0)
        {
            for (int i = 0; i < 9; i++) Ggos.g.goPic3pieces[i].transform.localPosition = Codes.picPos[Array.IndexOf(Codes.codeReal[9], i)];
        }
        else
        {
            for (int i = 0; i < 9; i++) Ggos.g.goPic3pieces[i].transform.localPosition = Codes.picPos[Array.IndexOf(Codes.codeRight[9], i)];
            Ggos.g.goPic3pieces[4].SetActive(false);
        }
        if (gEvents[41] == 1)
        {
            Ggos.g.goPic2key0.SetActive(false);
        }
        if (gEvents[42] == 1)
        {
            Ggos.g.goPic2key1.SetActive(true);
        }
        if (gEvents[43] == 1)
        {
            v3Buff = Ggos.g.goPic1indoor1.transform.localPosition;
            v3Buff.x = -0.1f;
            Ggos.g.goPic1indoor1.transform.localPosition = v3Buff;
            v3Buff = Ggos.g.goPic1indoor2.transform.localPosition;
            v3Buff.x = 0.1f;
            Ggos.g.goPic1indoor2.transform.localPosition = v3Buff;
        }
        if (gEvents[44] == 1)
        {
            v3Buff = Ggos.g.goPic3indoor1.transform.localPosition;
            v3Buff.x = -0.1f;
            Ggos.g.goPic3indoor1.transform.localPosition = v3Buff;
            v3Buff = Ggos.g.goPic3indoor2.transform.localPosition;
            v3Buff.x = 0.1f;
            Ggos.g.goPic3indoor2.transform.localPosition = v3Buff;
        }
        if (gEvents[45] == 1)
        {
            Ggos.g.goPic1coin0.SetActive(false);
        }
        if (gEvents[46] == 1)
        {
            Ggos.g.goPic1coin1.SetActive(true);
            v3Buff = Ggos.g.goPic1btnspanel.transform.localEulerAngles;
            v3Buff.y = 180f;
            Ggos.g.goPic1btnspanel.transform.localEulerAngles = v3Buff;
        }
        if (gEvents[47] == 1)
        {
            Ggos.g.goPic3coin0.SetActive(false);
        }
        if (gEvents[48] == 1)
        {
            Ggos.g.goPic3coin1.SetActive(true);
            v3Buff = Ggos.g.goPic3btnspanel.transform.localEulerAngles;
            v3Buff.y = 180f;
            Ggos.g.goPic3btnspanel.transform.localEulerAngles = v3Buff;
        }
        if (gEvents[49] == 1)
        {
            Ggos.g.goNotebook1flash0.SetActive(false);
        }
        if (gEvents[50] == 1)
        {
            Ggos.g.goNotebook1flash1.SetActive(true);
            matsBuff = Ggos.g.goNotebook1.GetComponent<MeshRenderer>().materials;
            matsBuff[1] = Ggos.g.mats[5];
            Ggos.g.goNotebook1.GetComponent<MeshRenderer>().materials = matsBuff;
        }
    }

    public static void WasEvent(int weEventID)
    {
        gEvents[weEventID] = 1;
        SaveEvents();
    }

    public static void UnWasEvent(int uweEventID)
    {
        gEvents[uweEventID] = 0;
        SaveEvents();
    }

    public static void SaveEvents()
    {
        string s = "";
        for (int i = 0; i < gEvents.Length; i++)
        {
            s += gEvents[i].ToString();
        }
        Debug.Log(s);
        PlayerPrefs.SetString("events", s);
        PlayerPrefs.Save();
    }

    public static void LoadEvents()
    {
        string s = "";
        if (PlayerPrefs.HasKey("events"))
        {
            s = PlayerPrefs.GetString("events");
            Debug.Log(s);
            for (int i = 0; i < gEvents.Length; i++)
            {
                gEvents[i] = (int)char.GetNumericValue(s[i]);
            }
        }
        else
        {
            for (int i = 0; i < gEvents.Length; i++)
            {
                s += '0';
            }
            Debug.Log(s);
            PlayerPrefs.SetString("events", s);
        }
    }

    public static void ClearAll()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }

}
