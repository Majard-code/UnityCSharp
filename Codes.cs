using System;
using UnityEngine;

public class Codes : MonoBehaviour
{
    public static int[][] codeReal = new int[20][];
    public static int[][] codeRight = new int[20][];

    public static Vector3 pic4target1 = new Vector3(-0.2f, 0.8f, -0.01f);
    public static Vector3 pic4target2 = new Vector3(0f, 0.8f, -0.01f);
    public static Vector3 pic4target3 = new Vector3(0.2f, 0.8f, -0.01f);
    public static Vector3 pic4target4 = new Vector3(-0.2f, -0.8f, -0.01f);
    public static Vector3 pic4target5 = new Vector3(0f, -0.8f, -0.01f);
    public static Vector3 pic4target6 = new Vector3(0.2f, -0.8f, -0.01f);
    public static Vector3 pic123target = new Vector3(0f, -0.3f, -0.01f);


    public static Material[] matBuff;
    public static int? firstBook2 = null;
    public static int? firstBook3 = null;
    public static int? firstPic4 = null;
    public static int? firstPic7 = null;
    public static int? firstPic8 = null;
    public static int? firstPic9 = null;
    public static int[] picPointer = new int[15];
    public static Vector3 posTemp;
    public static Quaternion rotTemp;

    public static Vector3[] bookPos = new Vector3[7];
    public static Vector3[] picPos = new Vector3[9];

    public static int rightCode = 0;
    public static int errorCode = 0;
    public static int count = 0;

    private void Awake()
    {
        bookPos[0] = new Vector3(-0.24f, 0.02f, 0f);
        bookPos[1] = new Vector3(-0.16f, 0.02f, 0f);
        bookPos[2] = new Vector3(-0.08f, 0.02f, 0f);
        bookPos[3] = new Vector3(0f, 0.02f, 0f);
        bookPos[4] = new Vector3(0.08f, 0.02f, 0f);
        bookPos[5] = new Vector3(0.16f, 0.02f, 0f);
        bookPos[6] = new Vector3(0.24f, 0.02f, 0f);

        picPos[0] = new Vector3(-0.2f, 0.2f, -0.02f);
        picPos[1] = new Vector3(0f, 0.2f, -0.02f);
        picPos[2] = new Vector3(0.2f, 0.2f, -0.02f);
        picPos[3] = new Vector3(-0.2f, 0f, -0.02f);
        picPos[4] = new Vector3(0f, 0f, -0.02f);
        picPos[5] = new Vector3(0.2f, 0f, -0.02f);
        picPos[6] = new Vector3(-0.2f, -0.2f, -0.02f);
        picPos[7] = new Vector3(0f, -0.2f, -0.02f);
        picPos[8] = new Vector3(0.2f, -0.2f, -0.02f);

        codeReal[0] = new int[] { 0 };
        codeRight[0] = new int[] { 0 };

        codeReal[1] = new int[] { 0, 0, 0, 0 };
        codeRight[1] = new int[] { 5, 3, 1, 4 };

        codeReal[2] = new int[] { 0, 1, 2, 3, 4, 5, 6 };
        codeRight[2] = new int[] { 3, 0, 6, 4, 2, 1, 5 };

        codeReal[3] = new int[] { 0, 1, 2, 3, 4, 5, 6 };
        codeRight[3] = new int[] { 1, 5, 0, 3, 6, 2, 4 };

        codeReal[4] = new int[] { 8, 4, 7, 1, 3, 0, 2, 6, 5 };
        codeRight[4] = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

        codeReal[5] = new int[] { 0, 0, 0, 0 };
        codeRight[5] = new int[] { 1, 2, 4, 6 };

        codeReal[6] = new int[] { 0, 0, 0, 0 };
        codeRight[6] = new int[] { 3, 2, 5, 1 };

        codeReal[7] = new int[] { 6, 5, 3, 1, 7, 0, 2, 8, 4 };
        codeRight[7] = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

        codeReal[8] = new int[] { 7, 4, 3, 8, 6, 2, 0, 5, 1 };
        codeRight[8] = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

        codeReal[9] = new int[] { 5, 3, 7, 4, 8, 2, 1, 0, 6 };
        codeRight[9] = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

        codeReal[10] = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        codeRight[10] = new int[] { 1, 9, 7, 3, 6, 5, 4, 2, 8 };

        codeReal[11] = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        codeRight[11] = new int[] { 8, 4, 6, 1, 7, 5, 3, 2, 9 };

        codeReal[12] = new int[] { 0 };
        codeRight[12] = new int[] { 0 };

        codeReal[13] = new int[] { 0 };
        codeRight[13] = new int[] { 0 };

        codeReal[14] = new int[] { 0 };
        codeRight[14] = new int[] { 0 };

        codeReal[15] = new int[] { 0 };
        codeRight[15] = new int[] { 0 };

        codeReal[16] = new int[] { 0 };
        codeRight[16] = new int[] { 0 };

        codeReal[17] = new int[] { 0 };
        codeRight[17] = new int[] { 0 };

        codeReal[18] = new int[] { 0 };
        codeRight[18] = new int[] { 0 };

        codeReal[19] = new int[] { 0 };
        codeRight[19] = new int[] { 0 };
}

    public static void CheckCode(int ccArrayID)
    {
        if (CodeEquals(ccArrayID))
        {
            rightCode = ccArrayID;
        }
        else
        {
            errorCode = ccArrayID;
        }
    }

    public static void Swap(int arrayID, int element1ID, int element2ID)
    {
        int buff;
        buff = codeReal[arrayID][element1ID];
        codeReal[arrayID][element1ID] = codeReal[arrayID][element2ID];
        codeReal[arrayID][element2ID] = buff;
    }

    public static void Incr(int arrayID, int elementID, int maxValue)
    {

    }   

    public static bool CodeEquals(int arrayID)
    {
        bool equal = false;
        for (int i = 0; i < codeReal[arrayID].Length; i++)
        {
            if (codeReal[arrayID][i] != codeRight[arrayID][i])
            {
                equal = false;
                break;
            }
            else
            {
                equal = true;
            }

        }
        return equal;
    }

    public static void Clear9(int c9i)
    {
        for (int i = 0; i < codeReal[c9i].Length; i++)
        {
            if (codeReal[c9i][i] != 0)
            {
                matBuff = Ggos.g.goPic1btns[codeReal[c9i][i]].GetComponent<MeshRenderer>().materials;
                matBuff[0] = Ggos.g.mats[2];
                Ggos.g.goPic1btns[codeReal[c9i][i]].GetComponent<MeshRenderer>().materials = matBuff;
                codeReal[c9i][i] = 0;
            }
        }
        picPointer[c9i] = 0;
    }

    private void FixedUpdate()
    {
        switch (rightCode)
        {
            //********************************************************************************************************
            case 1:
                switch (count)
                {
                    case 0:
                        Gcam.touchable = false;
                        Gevents.WasEvent(6);
                        for (int i = 0; i < Ggos.g.goLamp1rolls.Length; i++) Ggos.g.goLamp1rolls[i].GetComponent<BoxCollider>().enabled = false;
                        count++;
                        break;
                    case 10:
                        matBuff = Ggos.g.goLamp1rolls[0].GetComponent<MeshRenderer>().materials;
                        matBuff[6] = Ggos.g.mats[3];
                        Ggos.g.goLamp1rolls[0].GetComponent<MeshRenderer>().materials = matBuff;
                        count++;
                        break;
                    case 20:
                        matBuff = Ggos.g.goLamp1rolls[1].GetComponent<MeshRenderer>().materials;
                        matBuff[4] = Ggos.g.mats[3];
                        Ggos.g.goLamp1rolls[1].GetComponent<MeshRenderer>().materials = matBuff;
                        count++;
                        break;
                    case 30:
                        matBuff = Ggos.g.goLamp1rolls[2].GetComponent<MeshRenderer>().materials;
                        matBuff[2] = Ggos.g.mats[3];
                        Ggos.g.goLamp1rolls[2].GetComponent<MeshRenderer>().materials = matBuff;
                        count++;
                        break;
                    case 40:
                        matBuff = Ggos.g.goLamp1rolls[3].GetComponent<MeshRenderer>().materials;
                        matBuff[5] = Ggos.g.mats[3];
                        Ggos.g.goLamp1rolls[3].GetComponent<MeshRenderer>().materials = matBuff;
                        count++;
                        break;
                    case 60:
                        Ggos.g.goMainCamera.transform.localPosition = new Vector3(-2.2f, 1f, 1.38f);
                        Ggos.g.goMainCamera.transform.localEulerAngles = new Vector3(65f, 0f, 0f);
                        count++;
                        break;
                    case 100:
                        Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[5]);
                        Ggos.g.goBad1table1drawer.transform.localPosition = new Vector3(-2.19f, 0.26f, 1.55f);
                        count++;
                        break;
                    case 140:
                        Ggos.g.goMainCamera.transform.localPosition = Gcam.camPos[6];
                        Ggos.g.goMainCamera.transform.localEulerAngles = Gcam.camRot[6];
                        Gcam.touchable = true;
                        rightCode = 0;
                        count = 0;
                        break;
                    default:
                        count++;
                        break;
                }
                break;
            //********************************************************************************************************
            case 2:
                switch (count)
                {
                    case 0:
                        Gcam.touchable = false;
                        Gevents.WasEvent(8);
                        for (int i = 0; i < Ggos.g.goBookshelf3books.Length; i++) Ggos.g.goBookshelf3books[i].GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goDoor1key0.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goCard1.GetComponent<BoxCollider>().enabled = true;
                        posTemp = new Vector3(0f, 0f, 0f);
                        Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[5]);
                        count++;
                        break;
                    case 29:
                        Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[6]);
                        count++;
                        break;
                    case 30:
                        posTemp.y += 0.0016f;
                        Ggos.g.goBookshelf3in.transform.localPosition = posTemp;
                        if (posTemp.y >= 0.1584f)
                        {
                            Gcam.touchable = true;
                            rightCode = 0;
                            count = 0;
                        }
                        break;
                    default:
                        count++;
                        break;
                }
                break;
            //********************************************************************************************************
            case 3:
                switch (count)
                {
                    case 0:
                        Gcam.touchable = false;
                        Gevents.WasEvent(12);
                        for (int i = 0; i < Ggos.g.goBookshelf2books.Length; i++) Ggos.g.goBookshelf2books[i].GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goWrenchdriver0.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goBox4.GetComponent<BoxCollider>().enabled = true;
                        posTemp = new Vector3(0f, 0f, 0f);
                        Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[5]);
                        count++;
                        break;
                    case 29:
                        Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[6]);
                        count++;
                        break;
                    case 30:
                        posTemp.y += 0.0016f;
                        Ggos.g.goBookshelf2in.transform.localPosition = posTemp;
                        if (posTemp.y >= 0.1584f)
                        {
                            Gcam.touchable = true;
                            rightCode = 0;
                            count = 0;
                        }
                        break;
                    default:
                        count++;
                        break;
                }
                break;
            //********************************************************************************************************
            case 4:
                if (count == 0)
                {
                    Gcam.touchable = false;
                    Gevents.WasEvent(19);
                    Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[5]);
                }
                if (count == 29) Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[6]);
                if (count > 29 && count < 130)
                {
                    posTemp = Ggos.g.goSafe2.transform.localPosition;
                    posTemp.z += 0.045f;
                    Ggos.g.goSafe2.transform.localPosition = posTemp;
                }
                if (count == 29)
                {
                    posTemp = Ggos.g.goPic4pieces[7].transform.localPosition;
                    posTemp.z = 0.01f;
                    Ggos.g.goPic4pieces[7].transform.localPosition = posTemp;
                }
                if (count > 29) Ggos.g.goPic4pieces[7].transform.localPosition = Vector3.Lerp(Ggos.g.goPic4pieces[7].transform.localPosition, pic4target2, Time.deltaTime * 0.8f);

                if (count == 39)
                {
                    posTemp = Ggos.g.goPic4pieces[0].transform.localPosition;
                    posTemp.z = 0.01f;
                    Ggos.g.goPic4pieces[0].transform.localPosition = posTemp;
                }
                if (count > 39) Ggos.g.goPic4pieces[0].transform.localPosition = Vector3.Lerp(Ggos.g.goPic4pieces[0].transform.localPosition, pic4target4, Time.deltaTime * 0.8f);

                if (count == 49)
                {
                    posTemp = Ggos.g.goPic4pieces[5].transform.localPosition;
                    posTemp.z = 0.01f;
                    Ggos.g.goPic4pieces[5].transform.localPosition = posTemp;
                }
                if (count > 49) Ggos.g.goPic4pieces[5].transform.localPosition = Vector3.Lerp(Ggos.g.goPic4pieces[5].transform.localPosition, pic4target6, Time.deltaTime * 0.8f);

                if (count == 59)
                {
                    posTemp = Ggos.g.goPic4pieces[3].transform.localPosition;
                    posTemp.z = 0.01f;
                    Ggos.g.goPic4pieces[3].transform.localPosition = posTemp;
                }
                if (count > 59) Ggos.g.goPic4pieces[3].transform.localPosition = Vector3.Lerp(Ggos.g.goPic4pieces[3].transform.localPosition, pic4target1, Time.deltaTime * 0.8f);

                if (count == 69)
                {
                    posTemp = Ggos.g.goPic4pieces[4].transform.localPosition;
                    posTemp.z = 0.01f;
                    Ggos.g.goPic4pieces[4].transform.localPosition = posTemp;
                }
                if (count > 69) Ggos.g.goPic4pieces[4].transform.localPosition = Vector3.Lerp(Ggos.g.goPic4pieces[4].transform.localPosition, pic4target5, Time.deltaTime * 0.8f);

                if (count == 79)
                {
                    posTemp = Ggos.g.goPic4pieces[8].transform.localPosition;
                    posTemp.z = 0.01f;
                    Ggos.g.goPic4pieces[8].transform.localPosition = posTemp;
                }
                if (count > 79) Ggos.g.goPic4pieces[8].transform.localPosition = Vector3.Lerp(Ggos.g.goPic4pieces[8].transform.localPosition, pic4target3, Time.deltaTime * 0.8f);

                if (count == 89)
                {
                    posTemp = Ggos.g.goPic4pieces[1].transform.localPosition;
                    posTemp.z = 0.01f;
                    Ggos.g.goPic4pieces[1].transform.localPosition = posTemp;
                }
                if (count > 89) Ggos.g.goPic4pieces[1].transform.localPosition = Vector3.Lerp(Ggos.g.goPic4pieces[1].transform.localPosition, pic4target2, Time.deltaTime * 0.8f);

                if (count == 99)
                {
                    posTemp = Ggos.g.goPic4pieces[6].transform.localPosition;
                    posTemp.z = 0.01f;
                    Ggos.g.goPic4pieces[6].transform.localPosition = posTemp;
                }
                if (count > 99) Ggos.g.goPic4pieces[6].transform.localPosition = Vector3.Lerp(Ggos.g.goPic4pieces[6].transform.localPosition, pic4target4, Time.deltaTime * 0.8f);

                if (count == 109)
                {
                    posTemp = Ggos.g.goPic4pieces[2].transform.localPosition;
                    posTemp.z = 0.01f;
                    Ggos.g.goPic4pieces[2].transform.localPosition = posTemp;
                }
                if (count > 109) Ggos.g.goPic4pieces[2].transform.localPosition = Vector3.Lerp(Ggos.g.goPic4pieces[2].transform.localPosition, pic4target3, Time.deltaTime * 0.8f);

                count++;
                if (count >= 130)
                {
                    for (int i = 0; i < 9; i++) Ggos.g.goPic4pieces[i].SetActive(false);
                    for (int i = 0; i < 4; i++) Ggos.g.goSafe2coderolls[i].GetComponent<BoxCollider>().enabled = true;
                    Gcam.touchable = true;
                    count = 0;
                    rightCode = 0;
                }
                break;
            //********************************************************************************************************
            case 5:
                if (count == 0)
                {
                    Gcam.touchable = false;
                    Gevents.WasEvent(21);
                    for (int i = 0; i < Ggos.g.goSafe2coderolls.Length; i++) Ggos.g.goSafe2coderolls[i].GetComponent<BoxCollider>().enabled = false;
                    Ggos.g.goPiramids[0].GetComponent<BoxCollider>().enabled = true;
                    Ggos.g.goNotebook1flash0.GetComponent<BoxCollider>().enabled = true;
                    Ggos.g.goPic2key0.GetComponent<BoxCollider>().enabled = true;
                }
                if (count == 10)
                {
                    matBuff = Ggos.g.goSafe2coderolls[0].GetComponent<MeshRenderer>().materials;
                    matBuff[2] = Ggos.g.mats[3];
                    Ggos.g.goSafe2coderolls[0].GetComponent<MeshRenderer>().materials = matBuff;
                }

                if (count == 20)
                {
                    matBuff = Ggos.g.goSafe2coderolls[1].GetComponent<MeshRenderer>().materials;
                    matBuff[3] = Ggos.g.mats[3];
                    Ggos.g.goSafe2coderolls[1].GetComponent<MeshRenderer>().materials = matBuff;
                }

                if (count == 30)
                {
                    matBuff = Ggos.g.goSafe2coderolls[2].GetComponent<MeshRenderer>().materials;
                    matBuff[5] = Ggos.g.mats[3];
                    Ggos.g.goSafe2coderolls[2].GetComponent<MeshRenderer>().materials = matBuff;
                }
                if (count == 40)
                {
                    matBuff = Ggos.g.goSafe2coderolls[3].GetComponent<MeshRenderer>().materials;
                    matBuff[7] = Ggos.g.mats[3];
                    Ggos.g.goSafe2coderolls[3].GetComponent<MeshRenderer>().materials = matBuff;
                }

                if (count == 50) Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[5]);

                if (count == 60) Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[6]);

                if (count > 59 && count < 110)
                {
                    rotTemp = Quaternion.AngleAxis(3.6f, Vector3.up);
                    for (int i = 0; i < Ggos.g.goSafe2codes.Length; i++) Ggos.g.goSafe2codes[i].transform.localRotation *= rotTemp;
                }

                if (count > 109 && count < 160)
                {
                    posTemp = Ggos.g.goSafe2codes[0].transform.localPosition;
                    posTemp.y += 0.0049f;
                    Ggos.g.goSafe2codes[0].transform.localPosition = posTemp;

                    posTemp = Ggos.g.goSafe2codes[1].transform.localPosition;
                    posTemp.x += 0.0049f;
                    Ggos.g.goSafe2codes[1].transform.localPosition = posTemp;

                    posTemp = Ggos.g.goSafe2codes[2].transform.localPosition;
                    posTemp.x -= 0.0049f;
                    Ggos.g.goSafe2codes[2].transform.localPosition = posTemp;

                    posTemp = Ggos.g.goSafe2codes[3].transform.localPosition;
                    posTemp.y -= 0.0049f;
                    Ggos.g.goSafe2codes[3].transform.localPosition = posTemp;
                }


                count++;
                if (count >= 160)
                {
                    Gcam.touchable = true;
                    count = 0;
                    rightCode = 0;
                }
                break;
            //********************************************************************************************************
            case 6:
                switch (count)
                {
                    case 0:
                        Gcam.touchable = false;
                        Gevents.WasEvent(25);
                        for (int i = 0; i < Ggos.g.goLamp2rolls.Length; i++) Ggos.g.goLamp2rolls[i].GetComponent<BoxCollider>().enabled = false;
                        count++;
                        break;
                    case 10:
                        matBuff = Ggos.g.goLamp2rolls[0].GetComponent<MeshRenderer>().materials;
                        matBuff[4] = Ggos.g.mats[3];
                        Ggos.g.goLamp2rolls[0].GetComponent<MeshRenderer>().materials = matBuff;
                        count++;
                        break;
                    case 20:
                        matBuff = Ggos.g.goLamp2rolls[1].GetComponent<MeshRenderer>().materials;
                        matBuff[3] = Ggos.g.mats[3];
                        Ggos.g.goLamp2rolls[1].GetComponent<MeshRenderer>().materials = matBuff;
                        count++;
                        break;
                    case 30:
                        matBuff = Ggos.g.goLamp2rolls[2].GetComponent<MeshRenderer>().materials;
                        matBuff[6] = Ggos.g.mats[3];
                        Ggos.g.goLamp2rolls[2].GetComponent<MeshRenderer>().materials = matBuff;
                        count++;
                        break;
                    case 40:
                        matBuff = Ggos.g.goLamp2rolls[3].GetComponent<MeshRenderer>().materials;
                        matBuff[2] = Ggos.g.mats[3];
                        Ggos.g.goLamp2rolls[3].GetComponent<MeshRenderer>().materials = matBuff;
                        count++;
                        break;
                    case 60:
                        Ggos.g.goMainCamera.transform.localPosition = new Vector3(0.4f, 1f, 1.38f);
                        Ggos.g.goMainCamera.transform.localEulerAngles = new Vector3(65f, 0f, 0f);
                        count++;
                        break;
                    case 100:
                        Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[5]);
                        Ggos.g.goBad1table2drawer.transform.localPosition = new Vector3(0.39f, 0.26f, 1.55f);
                        count++;
                        break;
                    case 140:
                        Ggos.g.goMainCamera.transform.localPosition = Gcam.camPos[26];
                        Ggos.g.goMainCamera.transform.localEulerAngles = Gcam.camRot[26];
                        Gcam.touchable = true;
                        rightCode = 0;
                        count = 0;
                        break;
                    default:
                        count++;
                        break;
                }
                break;
            //********************************************************************************************************
            case 7:
                if (count == 0)
                {
                    Gcam.touchable = false;
                    Gevents.WasEvent(32);
                    Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[5]);
                }
                if (count == 29)
                {
                    posTemp = Ggos.g.goPic2pieces[4].transform.localPosition;
                    posTemp.z = -0.01f;
                    Ggos.g.goPic2pieces[4].transform.localPosition = posTemp;
                }
                if (count > 29) Ggos.g.goPic2pieces[4].transform.localPosition = Vector3.Lerp(Ggos.g.goPic2pieces[4].transform.localPosition, pic123target, Time.deltaTime * 2f);
                if (count == 50)
                {
                    if (Gevents.gEvents[28] == 1 && Gevents.gEvents[29] == 1)
                    {
                        Gevents.WasEvent(33);
                        Gcam.ChangeLocation(30);
                    }
                    else
                    {
                        for (int i = 0; i < 9; i++) Ggos.g.goPic2pieces[i].GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goPic2pieces[4].SetActive(false);
                        Gcam.touchable = true;
                        count = -1;
                        rightCode = 0;
                    }
                }
                if (count > 50 && count < 100)
                {
                    Debug.Log(count);
                    posTemp = Ggos.g.goPic2indoor1.transform.localPosition;
                    posTemp.x -= 0.002f;
                    Ggos.g.goPic2indoor1.transform.localPosition = posTemp;

                    posTemp = Ggos.g.goPic2indoor2.transform.localPosition;
                    posTemp.x += 0.002f;
                    Ggos.g.goPic2indoor2.transform.localPosition = posTemp;
                }

                count++;
                if (count >= 100)
                {
                    for (int i = 0; i < 9; i++) Ggos.g.goPic2pieces[i].GetComponent<BoxCollider>().enabled = false;
                    Ggos.g.goPic2pieces[4].SetActive(false);
                    Ggos.g.goPic2keyhole.GetComponent<BoxCollider>().enabled = true;
                    Ggos.g.goPic1.GetComponent<BoxCollider>().enabled = true;
                    Ggos.g.goPic3.GetComponent<BoxCollider>().enabled = true;
                    Gcam.touchable = true;
                    count = 0;
                    rightCode = 0;
                }
                break;
            //********************************************************************************************************
            case 8:
                if (count == 0)
                {
                    Gcam.touchable = false;
                    Gevents.WasEvent(36);
                    Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[5]);
                }
                if (count == 29)
                {
                    posTemp = Ggos.g.goPic1pieces[4].transform.localPosition;
                    posTemp.z = -0.01f;
                    Ggos.g.goPic1pieces[4].transform.localPosition = posTemp;
                }
                if (count > 29) Ggos.g.goPic1pieces[4].transform.localPosition = Vector3.Lerp(Ggos.g.goPic1pieces[4].transform.localPosition, pic123target, Time.deltaTime * 2f);
                if (count == 50)
                {
                    if (Gevents.gEvents[42] == 1 && Gevents.gEvents[40] == 1)
                    {
                        Gevents.WasEvent(43);
                        Gevents.WasEvent(44);
                    }
                    else
                    {
                        for (int i = 0; i < 9; i++) Ggos.g.goPic1pieces[i].GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goPic1pieces[4].SetActive(false);
                        Gcam.touchable = true;
                        count = -1;
                        rightCode = 0;
                    }
                }
                if (count == 79)
                {
                    Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[6]);
                    Ggos.g.goMainCamera.transform.localPosition = Gcam.camPos[30];
                    Ggos.g.goMainCamera.transform.localEulerAngles = Gcam.camRot[30];
                }

                if (count > 79 && count < 105)
                {
                    posTemp = Ggos.g.goPic2key1.transform.localEulerAngles;
                    posTemp.z -= 3.6f;
                    Ggos.g.goPic2key1.transform.localEulerAngles = posTemp;
                }

                if (count == 105)
                {
                    Ggos.g.goMainCamera.transform.localPosition = Gcam.camPos[35];
                    Ggos.g.goMainCamera.transform.localEulerAngles = Gcam.camRot[35];
                }

                if (count > 104 && count < 130)
                {
                    posTemp = Ggos.g.goPic3indoor1.transform.localPosition;
                    posTemp.x -= 0.004f;
                    Ggos.g.goPic3indoor1.transform.localPosition = posTemp;
                    posTemp = Ggos.g.goPic3indoor2.transform.localPosition;
                    posTemp.x += 0.004f;
                    Ggos.g.goPic3indoor2.transform.localPosition = posTemp;
                }

                if (count == 130)
                {
                    Ggos.g.goMainCamera.transform.localPosition = Gcam.camPos[31];
                    Ggos.g.goMainCamera.transform.localEulerAngles = Gcam.camRot[31];
                }

                if (count > 129 && count < 155)
                {
                    posTemp = Ggos.g.goPic1indoor1.transform.localPosition;
                    posTemp.x -= 0.004f;
                    Ggos.g.goPic1indoor1.transform.localPosition = posTemp;
                    posTemp = Ggos.g.goPic1indoor2.transform.localPosition;
                    posTemp.x += 0.004f;
                    Ggos.g.goPic1indoor2.transform.localPosition = posTemp;
                }

                count++;
                if (count >= 180)
                {
                    for (int i = 0; i < 9; i++) Ggos.g.goPic1pieces[i].GetComponent<BoxCollider>().enabled = false;
                    Ggos.g.goPic1pieces[4].SetActive(false);
                    Ggos.g.goPic1coinsocket.GetComponent<BoxCollider>().enabled = true;
                    Ggos.g.goPic2.GetComponent<BoxCollider>().enabled = true;
                    Ggos.g.goLamp2.GetComponent<BoxCollider>().enabled = true;
                    Gcam.ChangeLocation(32);
                    count = 0;
                    rightCode = 0;
                }
                break;
            //********************************************************************************************************
            case 9:
                if (count == 0)
                {
                    Gcam.touchable = false;
                    Gevents.WasEvent(40);
                    Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[5]);
                }
                if (count == 29)
                {
                    posTemp = Ggos.g.goPic3pieces[4].transform.localPosition;
                    posTemp.z = -0.01f;
                    Ggos.g.goPic3pieces[4].transform.localPosition = posTemp;
                }
                if (count > 29) Ggos.g.goPic3pieces[4].transform.localPosition = Vector3.Lerp(Ggos.g.goPic3pieces[4].transform.localPosition, pic123target, Time.deltaTime * 2f);
                if (count == 50)
                {
                    if (Gevents.gEvents[42] == 1 && Gevents.gEvents[36] == 1)
                    {
                        Gevents.WasEvent(43);
                        Gevents.WasEvent(44);
                    }
                    else
                    {
                        for (int i = 0; i < 9; i++) Ggos.g.goPic3pieces[i].GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goPic3pieces[4].SetActive(false);
                        Gcam.touchable = true;
                        count = -1;
                        rightCode = 0;
                    }
                }

                if (count == 79)
                {
                    Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[6]);
                    Ggos.g.goMainCamera.transform.localPosition = Gcam.camPos[30];
                    Ggos.g.goMainCamera.transform.localEulerAngles = Gcam.camRot[30];
                }

                if (count > 79 && count < 105)
                {
                    posTemp = Ggos.g.goPic2key1.transform.localEulerAngles;
                    posTemp.z -= 3.6f;
                    Ggos.g.goPic2key1.transform.localEulerAngles = posTemp;
                }

                if (count == 105)
                {
                    Ggos.g.goMainCamera.transform.localPosition = Gcam.camPos[31];
                    Ggos.g.goMainCamera.transform.localEulerAngles = Gcam.camRot[31];
                }

                if (count > 104 && count < 130)
                {
                    posTemp = Ggos.g.goPic1indoor1.transform.localPosition;
                    posTemp.x -= 0.004f;
                    Ggos.g.goPic1indoor1.transform.localPosition = posTemp;
                    posTemp = Ggos.g.goPic1indoor2.transform.localPosition;
                    posTemp.x += 0.004f;
                    Ggos.g.goPic1indoor2.transform.localPosition = posTemp;
                }

                if (count == 130)
                {
                    Ggos.g.goMainCamera.transform.localPosition = Gcam.camPos[35];
                    Ggos.g.goMainCamera.transform.localEulerAngles = Gcam.camRot[35];
                }

                if (count > 129 && count < 155)
                {
                    posTemp = Ggos.g.goPic3indoor1.transform.localPosition;
                    posTemp.x -= 0.004f;
                    Ggos.g.goPic3indoor1.transform.localPosition = posTemp;
                    posTemp = Ggos.g.goPic3indoor2.transform.localPosition;
                    posTemp.x += 0.004f;
                    Ggos.g.goPic3indoor2.transform.localPosition = posTemp;
                }

                count++;
                if (count >= 180)
                {
                    for (int i = 0; i < 9; i++) Ggos.g.goPic3pieces[i].GetComponent<BoxCollider>().enabled = false;
                    Ggos.g.goPic3pieces[4].SetActive(false);
                    Ggos.g.goPic3coinsocket.GetComponent<BoxCollider>().enabled = true;
                    Ggos.g.goPic2.GetComponent<BoxCollider>().enabled = true;
                    Gcam.ChangeLocation(36);
                    count = 0;
                    rightCode = 0;
                }
                break;
            //********************************************************************************************************
            case 10:
                if (count == 0)
                {
                    Gcam.touchable = false;
                    Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[11]);
                }

                if (count == 15)
                {
                    for (int i = 0; i < codeReal[10].Length; i++)
                    {
                        matBuff = Ggos.g.goPic1btns[codeReal[10][i]].GetComponent<MeshRenderer>().materials;
                        matBuff[0] = Ggos.g.mats[3];
                        Ggos.g.goPic1btns[codeReal[10][i]].GetComponent<MeshRenderer>().materials = matBuff;
                    }
                    rotTemp = Quaternion.AngleAxis(6f, Vector3.up);
                }

                if (count > 29 && count < 60)
                {
                    Ggos.g.goPic1btnspanel.transform.localRotation *= rotTemp;
                }

                if (count == 59)
                {
                    Ggos.g.goMainCamera.transform.localPosition = new Vector3();
                    Ggos.g.goMainCamera.transform.localEulerAngles = new Vector3();
                }

                count++;
                if (count > 200)
                {
                    Gcam.touchable = true;
                    count = 0;
                    rightCode = 0;
                }
                break;
        }
        switch (errorCode)
        {
            //********************************************************************************************************
            case 10:
                if (count == 0)
                {
                    Gcam.touchable = false;
                    Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[10]);
                    for (int i = 1; i < Ggos.g.goPic1btns.Length; i++) Ggos.g.goPic1btns[i].GetComponent<BoxCollider>().enabled = true;
                    for (int i = 0; i < codeReal[10].Length; i++)
                    {
                        matBuff = Ggos.g.goPic1btns[codeReal[10][i]].GetComponent<MeshRenderer>().materials;
                        matBuff[0] = Ggos.g.mats[6];
                        Ggos.g.goPic1btns[codeReal[10][i]].GetComponent<MeshRenderer>().materials = matBuff;
                    }
                }

                if (count == 25)
                {
                    for (int i = 0; i < codeReal[10].Length; i++)
                    {
                        matBuff = Ggos.g.goPic1btns[codeReal[10][i]].GetComponent<MeshRenderer>().materials;
                        matBuff[0] = Ggos.g.mats[2];
                        Ggos.g.goPic1btns[codeReal[10][i]].GetComponent<MeshRenderer>().materials = matBuff;
                        codeReal[10][i] = 0;
                    }
                }

                count++;
                if (count > 25)
                {
                    picPointer[10] = 0;
                    Gcam.touchable = true;
                    count = 0;
                    errorCode = 0;
                }

                break;
            default:
                errorCode = 0;
                break;
        }
    }
}
