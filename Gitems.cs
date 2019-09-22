using UnityEngine;

public class Gitems : MonoBehaviour
{
    public static bool isMenu = false;
    public static Vector3[] itemPos = new Vector3[93];
    public static int[] gItems = new int[93];
    public static int activeItem = 0;

    public static Vector3 angleTemp;
    public static Quaternion rotTemp;
    public static Material[] matTemp;
    public static int count = 0;
    public static int wasActive = 0;
    public static int wasnotActive = 0;

    private void Start()
    {
        LoadItems();
        itemPos[0] = new Vector3(-1.2f, 0.3f, 10f);
        itemPos[4] = new Vector3(-0.9f, 0.3f, 10f);
        itemPos[9] = new Vector3(-0.6f, 0.3f, 10f);
        itemPos[13] = new Vector3(-0.3f, 0.3f, 10f);
        itemPos[15] = new Vector3(0f, 0.3f, 10f);
        itemPos[17] = new Vector3(0.3f, 0.3f, 10f);
        itemPos[22] = new Vector3(0.6f, 0.3f, 10f);
        itemPos[26] = new Vector3(0.9f, 0.3f, 10f);
        itemPos[27] = new Vector3(1.2f, 0.3f, 10f);

        itemPos[30] = new Vector3(-1.2f, 0f, 10f);
        itemPos[34] = new Vector3(-0.9f, 0f, 10f);
        itemPos[38] = new Vector3(-0.6f, 0f, 10f);
        itemPos[41] = new Vector3(-0.3f, 0f, 10f);
        itemPos[45] = new Vector3(0f, 0f, 10f);
        itemPos[47] = new Vector3(0.3f, 0f, 10f);
        itemPos[49] = new Vector3(0.6f, 0f, 10f);
        itemPos[60] = new Vector3(0.9f, 0f, 10f);
        itemPos[61] = new Vector3(1.2f, 0f, 10f);

        itemPos[67] = new Vector3(-1.2f, -0.3f, 10f);
        itemPos[72] = new Vector3(-0.9f, -0.3f, 10f);
        itemPos[73] = new Vector3(-0.6f, -0.3f, 10f);
        itemPos[74] = new Vector3(-0.3f, -0.3f, 10f);
        itemPos[78] = new Vector3(0f, -0.3f, 10f);
        itemPos[80] = new Vector3(0.3f, -0.3f, 10f);
        itemPos[83] = new Vector3(0.6f, -0.3f, 10f);
        itemPos[84] = new Vector3(0.9f, -0.3f, 10f);
        itemPos[91] = new Vector3(1.2f, -0.3f, 10f);

    }

    public static void TakeItem(int tii)
    {
        Gevents.WasEvent(tii);

        gItems[tii] = 1;
        SaveItems();

        ItemReFocus(tii);

        Ggos.g.goItems[tii].SetActive(true);
    }

    public static void UseItem(int uiItem, int uiEvent, bool uiDel)
    {
        if (uiItem == activeItem)
        {
            Gevents.WasEvent(uiEvent);
            if (uiDel)
            {
                gItems[uiItem] = 0;
                SaveItems();
                Ggos.g.goItems[uiItem].SetActive(false);
                ItemReFocus(uiItem);
            }
            wasActive = uiEvent;
        }
        else
        {
            wasnotActive = uiEvent;
        }
    }

    public static void ItemReFocus(int irfItem)
    {
        Ggos.g.goItemFrames[activeItem].GetComponent<MeshRenderer>().material = Ggos.g.mats[1];
        if (gItems[irfItem] == 0)
        {
            activeItem = 0;
        }
        else
        {
            activeItem = irfItem;
        }
        Ggos.g.goItemFrames[activeItem].GetComponent<MeshRenderer>().material = Ggos.g.mats[0];
        Ggos.g.goItemCamera.transform.position = itemPos[activeItem];
    }

    public static void ItemPressed(int ipi)
    {
        if (isMenu)
        {
            Ggos.g.goItemFrames[activeItem].GetComponent<MeshRenderer>().material = Ggos.g.mats[1];
            if (gItems[ipi] == 0)
            {
                activeItem = 0;
            }
            else
            {
                activeItem = ipi;
            }
            Ggos.g.goItemFrames[activeItem].GetComponent<MeshRenderer>().material = Ggos.g.mats[0];
            CamResizeToSmall();
        }
        else
        {
            CamResizeToFull();
        }
    }
    
    public static void CamResizeToSmall()
    {
        if (Gcam.myLoc == 0)
        {
            Gcam.rotable = true;
        }

        Gcam.touchable = true;

        float mainWidth = Screen.width;
        float mainHeight = Screen.height;
        float itemWidth = mainWidth / 10;
        float itemHeight = itemWidth;

        float itemPercent = itemHeight / mainHeight;

        Rect rect = Ggos.g.goItemCamera.GetComponent<Camera>().rect;
        rect.Set(0.9f, 0f, 0.1f, itemPercent);
        Ggos.g.goItemCamera.GetComponent<Camera>().rect = rect;
        Ggos.g.goItemCamera.GetComponent<Camera>().orthographicSize = 0.11f;

        Gmenu.MenuUnHide();

        Ggos.g.goCrossImg2.SetActive(false);
        Ggos.g.goItemCamera.transform.position = itemPos[activeItem];

        Ggos.g.goBacks.SetActive(false);

        isMenu = false;
    }

    public static void CamResizeToFull()
    {
        Gcam.rotable = false;
        Gcam.touchable = false;

        Rect rect = Ggos.g.goItemCamera.GetComponent<Camera>().rect;
        rect.Set(0f, 0f, 1f, 1f);
        Ggos.g.goItemCamera.GetComponent<Camera>().rect = rect;
        Ggos.g.goItemCamera.GetComponent<Camera>().orthographicSize = 0.9f;

        Gmenu.MenuHide(false);

        Ggos.g.goCrossImg2.SetActive(true);
        Ggos.g.goItemCamera.transform.position = itemPos[45];

        Ggos.g.goBacks.SetActive(true);
        
        isMenu = true;
    }

    public static void SaveItems()
    {
        string s = "";
        s += 1;
        for (int i = 1; i < gItems.Length; i++)
        {
            s += gItems[i].ToString();
        }
        Debug.Log(s);
        PlayerPrefs.SetString("items", s);
        PlayerPrefs.Save();
    }

    public static void LoadItems()
    {
        string s = "";
        if (PlayerPrefs.HasKey("items"))
        {
            s = PlayerPrefs.GetString("items");
            Debug.Log(s);
            for (int i = 0; i < gItems.Length; i++)
            {
                gItems[i] = (int)char.GetNumericValue(s[i]);
                if (gItems[i] == 1) Ggos.g.goItems[i].SetActive(true);
            }
        }
        else
        {
            s += '1';
            for (int i = 1; i < gItems.Length; i++)
            {
                s += '0';
            }
            Debug.Log(s);
            PlayerPrefs.SetString("items", s);
        }

    }

    private void FixedUpdate()
    {
        switch (wasActive)
        {
            //********************************************************************************************************
            case 5:
                Ggos.g.goTv101.SetActive(false);
                Ggos.g.goTv11.SetActive(true);
                wasActive = 0;
                break;
            //********************************************************************************************************
            case 10:
                if (count == 0)
                {
                    angleTemp = new Vector3(0f, 0f, 0f);
                    Gcam.touchable = false;
                    Ggos.g.goDoor1key1.SetActive(true);
                    Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[8]);
                }

                if (count > 19)
                {
                    angleTemp.z += 12;
                    Ggos.g.goDoor1keyhole.transform.localEulerAngles = angleTemp;
                }

                if (count == 50)
                {
                    Gcam.myLoc = 0;
                    Ggos.g.goDoor1keyholeplate.GetComponent<BoxCollider>().enabled = false;
                    Ggos.g.goDoor1.GetComponent<BoxCollider>().enabled = true;
                    ChangeRoom.chrChangeRoom();
                }

                count++;
                if (count > 50)
                {
                    count = 0;
                    wasActive = 0;
                }
                break;
            //********************************************************************************************************
            case 14:
                if (count == 0)
                {
                    Gcam.touchable = false;
                }

                if (count == 10)
                {
                    Ggos.g.goWrenchdrivers1[0].SetActive(true);
                    Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[9]);
                    angleTemp = new Vector3(0f, 0f, 330f);
                }
                if (count > 10 && count < 30)
                {
                    angleTemp.z -= 2;
                    Ggos.g.goVentilation1bolts[0].transform.localEulerAngles = angleTemp;
                }
                if (count == 30)
                {
                    Ggos.g.goVentilation1bolts[0].SetActive(false);
                }

                if (count == 60)
                {
                    Ggos.g.goWrenchdrivers1[1].SetActive(true);
                    Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[9]);
                    angleTemp = new Vector3(0f, 0f, 0f);
                }
                if (count > 60 && count < 80)
                {
                    angleTemp.z -= 2;
                    Ggos.g.goVentilation1bolts[1].transform.localEulerAngles = angleTemp;
                }
                if (count == 80)
                {
                    Ggos.g.goVentilation1bolts[1].SetActive(false);
                }

                if (count == 110)
                {
                    Ggos.g.goWrenchdrivers1[2].SetActive(true);
                    Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[9]);
                    angleTemp = new Vector3(0f, 0f, 0f);
                }
                if (count > 110 && count < 130)
                {
                    angleTemp.z -= 2;
                    Ggos.g.goVentilation1bolts[2].transform.localEulerAngles = angleTemp;
                }
                if (count == 130)
                {
                    Ggos.g.goVentilation1bolts[2].SetActive(false);
                }

                if (count == 160)
                {
                    Ggos.g.goWrenchdrivers1[3].SetActive(true);
                    Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[9]);
                    angleTemp = new Vector3(0f, 0f, 330f);
                }
                if (count > 160 && count < 180)
                {
                    angleTemp.z -= 2;
                    Ggos.g.goVentilation1bolts[3].transform.localEulerAngles = angleTemp;
                }
                if (count == 180)
                {
                    Ggos.g.goVentilation1bolts[3].SetActive(false);
                }
                if (count == 210)
                {
                    Ggos.g.goVentilation1grid.SetActive(false);
                }
                if (count == 240)
                {
                    Gcam.ChangeLocation(15);
                }

                count++;
                if (count > 240)
                {
                    count = 0;
                    wasActive = 0;
                }
                break;
            //********************************************************************************************************
            case 16:
                if (count == 0)
                {
                    angleTemp = new Vector3(0f, 0f, 0f);
                    Gcam.touchable = false;
                    Ggos.g.goBureau1key2.SetActive(true);
                    Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[8]);
                }

                if (count > 19)
                {
                    angleTemp.z += 12;
                    Ggos.g.goBureau1keyhole2.transform.localEulerAngles = angleTemp;
                }

                count++;
                if (count > 49)
                {
                    Gcam.touchable = true;
                    count = 0;
                    wasActive = 0;
                }
                break;
            //********************************************************************************************************
            case 18:
                Ggos.g.goPic4pieces[3].SetActive(true);
                Ggos.g.goPic4P.GetComponent<BoxCollider>().enabled = false;
                for (int i = 0; i < 9; i++) Ggos.g.goPic4pieces[i].GetComponent<BoxCollider>().enabled = true;
                Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[4]);
                wasActive = 0;
                break;
            //********************************************************************************************************
            case 23:
                if (count == 0)
                {
                    Gcam.touchable = false;
                    rotTemp = Quaternion.AngleAxis(10f, Vector3.forward);
                }

                if (count == 10)
                {
                    Ggos.g.goScrewdrivers1[0].SetActive(true);
                    Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[9]);
                }
                if (count > 10 && count < 30)
                {
                    Ggos.g.goSp1screws[0].transform.localRotation *= rotTemp;
                }
                if (count == 30)
                {
                    Ggos.g.goSp1screws[0].SetActive(false);
                }

                if (count == 60)
                {
                    Ggos.g.goScrewdrivers1[1].SetActive(true);
                    Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[9]);
                }
                if (count > 60 && count < 80)
                {
                    Ggos.g.goSp1screws[1].transform.localRotation *= rotTemp;
                }
                if (count == 80)
                {
                    Ggos.g.goSp1screws[1].SetActive(false);
                }

                if (count == 110)
                {
                    Ggos.g.goScrewdrivers1[2].SetActive(true);
                    Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[9]);
                }
                if (count > 110 && count < 130)
                {
                    Ggos.g.goSp1screws[2].transform.localRotation *= rotTemp;
                }
                if (count == 130)
                {
                    Ggos.g.goSp1screws[2].SetActive(false);
                }

                if (count == 160)
                {
                    Ggos.g.goScrewdrivers1[3].SetActive(true);
                    Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[9]);
                }
                if (count > 160 && count < 180)
                {
                    Ggos.g.goSp1screws[3].transform.localRotation *= rotTemp;
                }
                if (count == 180)
                {
                    Ggos.g.goSp1screws[3].SetActive(false);
                }
                if (count == 210)
                {
                    Ggos.g.goSp1door.SetActive(false);
                }

                count++;
                if (count > 210)
                {
                    Ggos.g.goSp1pin2.GetComponent<BoxCollider>().enabled = true;
                    Gcam.touchable = true;
                    count = 0;
                    wasActive = 0;
                }
                break;
            //********************************************************************************************************
            case 24:
                if (count == 0)
                {
                    Gcam.touchable = false;
                    rotTemp = Quaternion.AngleAxis(10f, Vector3.forward);
                }

                if (count == 10)
                {
                    Ggos.g.goScrewdrivers2[0].SetActive(true);
                    Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[9]);
                }
                if (count > 10 && count < 30)
                {
                    Ggos.g.goSp2screws[0].transform.localRotation *= rotTemp;
                }
                if (count == 30)
                {
                    Ggos.g.goSp2screws[0].SetActive(false);
                }

                if (count == 60)
                {
                    Ggos.g.goScrewdrivers2[1].SetActive(true);
                    Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[9]);
                }
                if (count > 60 && count < 80)
                {
                    Ggos.g.goSp2screws[1].transform.localRotation *= rotTemp;
                }
                if (count == 80)
                {
                    Ggos.g.goSp2screws[1].SetActive(false);
                }

                if (count == 110)
                {
                    Ggos.g.goScrewdrivers2[2].SetActive(true);
                    Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[9]);
                }
                if (count > 110 && count < 130)
                {
                    Ggos.g.goSp2screws[2].transform.localRotation *= rotTemp;
                }
                if (count == 130)
                {
                    Ggos.g.goSp2screws[2].SetActive(false);
                }

                if (count == 160)
                {
                    Ggos.g.goScrewdrivers2[3].SetActive(true);
                    Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[9]);
                }
                if (count > 160 && count < 180)
                {
                    Ggos.g.goSp2screws[3].transform.localRotation *= rotTemp;
                }
                if (count == 180)
                {
                    Ggos.g.goSp2screws[3].SetActive(false);
                }
                if (count == 210)
                {
                    Ggos.g.goSp2door.SetActive(false);
                }

                count++;
                if (count > 210)
                {
                    Ggos.g.goSp2pin1.GetComponent<BoxCollider>().enabled = true;
                    Gcam.touchable = true;
                    count = 0;
                    wasActive = 0;
                }
                break;
            //********************************************************************************************************
            case 28:
                if (count == 0)
                {
                    Ggos.g.goSp1cogwheels[2].SetActive(true);
                    Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[5]);
                    if (Gevents.gEvents[29] == 1 && Gevents.gEvents[32] == 1)
                    {
                        Gevents.WasEvent(33);
                        Gcam.touchable = false;
                    }
                    else
                    {
                        count = -1;
                        wasActive = 0;
                    }
                }
                if (count == 29)
                {
                    Ggos.g.goMainCamera.transform.localPosition = Gcam.camPos[29];
                    Ggos.g.goMainCamera.transform.localEulerAngles = Gcam.camRot[29];
                }

                if (count > 29 && count < 80)
                {
                    angleTemp = Ggos.g.goPic2indoor1.transform.localPosition;
                    angleTemp.x -= 0.002f;
                    Ggos.g.goPic2indoor1.transform.localPosition = angleTemp;
                    angleTemp = Ggos.g.goPic2indoor2.transform.localPosition;
                    angleTemp.x += 0.002f;
                    Ggos.g.goPic2indoor2.transform.localPosition = angleTemp;
                }

                count++;
                if (count >= 110)
                {
                    Ggos.g.goMainCamera.transform.localPosition = Gcam.camPos[23];
                    Ggos.g.goMainCamera.transform.localEulerAngles = Gcam.camRot[23];
                    Gcam.touchable = true;
                    count = 0;
                    wasActive = 0;
                }
                break;
            //********************************************************************************************************
            case 29:
                if (count == 0)
                {
                    Ggos.g.goSp2cogwheels[1].SetActive(true);
                    Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[5]);
                    if (Gevents.gEvents[28] == 1 && Gevents.gEvents[32] == 1)
                    {
                        Gevents.WasEvent(33);
                        Gcam.touchable = false;
                    }
                    else
                    {
                        count = -1;
                        wasActive = 0;
                    }
                }
                if (count == 29)
                {
                    Ggos.g.goMainCamera.transform.localPosition = Gcam.camPos[29];
                    Ggos.g.goMainCamera.transform.localEulerAngles = Gcam.camRot[29];
                }

                if (count > 29 && count < 80)
                {
                    angleTemp = Ggos.g.goPic2indoor1.transform.localPosition;
                    angleTemp.x -= 0.002f;
                    Ggos.g.goPic2indoor1.transform.localPosition = angleTemp;
                    angleTemp = Ggos.g.goPic2indoor2.transform.localPosition;
                    angleTemp.x += 0.002f;
                    Ggos.g.goPic2indoor2.transform.localPosition = angleTemp;
                }

                count++;
                if (count >= 110)
                {
                    Ggos.g.goMainCamera.transform.localPosition = Gcam.camPos[24];
                    Ggos.g.goMainCamera.transform.localEulerAngles = Gcam.camRot[24];
                    Gcam.touchable = true;
                    count = 0;
                    wasActive = 0;
                }
                break;
            //********************************************************************************************************
            case 31:
                Ggos.g.goPic2pieces[7].SetActive(true);
                Ggos.g.goPic2in.GetComponent<BoxCollider>().enabled = false;
                for (int i = 0; i < 9; i++) Ggos.g.goPic2pieces[i].GetComponent<BoxCollider>().enabled = true;
                Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[4]);
                wasActive = 0;
                break;
            //********************************************************************************************************
            case 35:
                Ggos.g.goPic1pieces[6].SetActive(true);
                Ggos.g.goPic1in.GetComponent<BoxCollider>().enabled = false;
                for (int i = 0; i < 9; i++) Ggos.g.goPic1pieces[i].GetComponent<BoxCollider>().enabled = true;
                Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[4]);
                wasActive = 0;
                break;
            //********************************************************************************************************
            case 37:
                if (count == 0)
                {
                    Gcam.touchable = false;
                }

                if (count == 10)
                {
                    Ggos.g.goWrenchdrivers2[0].SetActive(true);
                    Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[9]);
                    angleTemp = new Vector3(0f, 0f, 330f);
                }
                if (count > 10 && count < 30)
                {
                    angleTemp.z -= 2;
                    Ggos.g.goVentilation2bolts[0].transform.localEulerAngles = angleTemp;
                }
                if (count == 30)
                {
                    Ggos.g.goVentilation2bolts[0].SetActive(false);
                }

                if (count == 60)
                {
                    Ggos.g.goWrenchdrivers2[1].SetActive(true);
                    Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[9]);
                    angleTemp = new Vector3(0f, 0f, 0f);
                }
                if (count > 60 && count < 80)
                {
                    angleTemp.z -= 2;
                    Ggos.g.goVentilation2bolts[1].transform.localEulerAngles = angleTemp;
                }
                if (count == 80)
                {
                    Ggos.g.goVentilation2bolts[1].SetActive(false);
                }

                if (count == 110)
                {
                    Ggos.g.goWrenchdrivers2[2].SetActive(true);
                    Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[9]);
                    angleTemp = new Vector3(0f, 0f, 0f);
                }
                if (count > 110 && count < 130)
                {
                    angleTemp.z -= 2;
                    Ggos.g.goVentilation2bolts[2].transform.localEulerAngles = angleTemp;
                }
                if (count == 130)
                {
                    Ggos.g.goVentilation2bolts[2].SetActive(false);
                }

                if (count == 160)
                {
                    Ggos.g.goWrenchdrivers2[3].SetActive(true);
                    Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[9]);
                    angleTemp = new Vector3(0f, 0f, 330f);
                }
                if (count > 160 && count < 180)
                {
                    angleTemp.z -= 2;
                    Ggos.g.goVentilation2bolts[3].transform.localEulerAngles = angleTemp;
                }
                if (count == 180)
                {
                    Ggos.g.goVentilation2bolts[3].SetActive(false);
                }
                if (count == 210)
                {
                    Ggos.g.goVentilation2grid.SetActive(false);
                }
                if (count == 240)
                {
                    Gcam.ChangeLocation(34);
                }

                count++;
                if (count > 240)
                {
                    count = 0;
                    wasActive = 0;
                }
                break;
            //********************************************************************************************************
            case 39:
                Ggos.g.goPic3pieces[8].SetActive(true);
                Ggos.g.goPic3in.GetComponent<BoxCollider>().enabled = false;
                for (int i = 0; i < 9; i++) Ggos.g.goPic3pieces[i].GetComponent<BoxCollider>().enabled = true;
                Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[4]);
                wasActive = 0;
                break;
            //********************************************************************************************************
            case 42:
                if (count == 0)
                {
                    Ggos.g.goPic2key1.SetActive(true);
                    Ggos.g.goPic2keyhole.GetComponent<BoxCollider>().enabled = false;
                    Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[4]);
                    if (Gevents.gEvents[36] == 1 && Gevents.gEvents[40] == 1)
                    {
                        Gevents.WasEvent(43);
                        Gevents.WasEvent(44);
                        Gcam.touchable = false;
                    }
                    else
                    {
                        count = -1;
                        wasActive = 0;
                    }
                }
                if (count == 29)
                {
                    Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[6]);
                }

                if (count > 29 && count < 55)
                {
                    angleTemp = Ggos.g.goPic2key1.transform.localEulerAngles;
                    angleTemp.z -= 3.6f;
                    Ggos.g.goPic2key1.transform.localEulerAngles = angleTemp;
                }

                if (count == 55)
                {
                    Ggos.g.goMainCamera.transform.localPosition = Gcam.camPos[31];
                    Ggos.g.goMainCamera.transform.localEulerAngles = Gcam.camRot[31];
                }

                if (count > 54 && count < 80)
                {
                    angleTemp = Ggos.g.goPic1indoor1.transform.localPosition;
                    angleTemp.x -= 0.004f;
                    Ggos.g.goPic1indoor1.transform.localPosition = angleTemp;
                    angleTemp = Ggos.g.goPic1indoor2.transform.localPosition;
                    angleTemp.x += 0.004f;
                    Ggos.g.goPic1indoor2.transform.localPosition = angleTemp;
                }

                if (count == 80)
                {
                    Ggos.g.goMainCamera.transform.localPosition = Gcam.camPos[35];
                    Ggos.g.goMainCamera.transform.localEulerAngles = Gcam.camRot[35];
                }

                if (count > 79 && count < 105)
                {
                    angleTemp = Ggos.g.goPic3indoor1.transform.localPosition;
                    angleTemp.x -= 0.004f;
                    Ggos.g.goPic3indoor1.transform.localPosition = angleTemp;
                    angleTemp = Ggos.g.goPic3indoor2.transform.localPosition;
                    angleTemp.x += 0.004f;
                    Ggos.g.goPic3indoor2.transform.localPosition = angleTemp;
                }

                if (count == 105)
                {
                    Ggos.g.goMainCamera.transform.localPosition = Gcam.camPos[30];
                    Ggos.g.goMainCamera.transform.localEulerAngles = Gcam.camRot[30];
                }

                if (count > 104 && count < 130)
                {
                    angleTemp = Ggos.g.goPic2key1.transform.localEulerAngles;
                    angleTemp.z -= 3.6f;
                    Ggos.g.goPic2key1.transform.localEulerAngles = angleTemp;
                }

                count++;
                if (count >= 130)
                {
                    Gcam.touchable = true;
                    count = 0;
                    wasActive = 0;
                }
                break;
            //********************************************************************************************************
            case 46:
                if (count == 0)
                {
                    Gcam.touchable = false;
                    Ggos.g.goPic1coin1.SetActive(true);
                    Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[3]);
                }

                if (count == 29)
                {
                    Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[6]);
                }

                if (count > 29 && count < 130)
                {
                    angleTemp = Ggos.g.goPic1btnspanel.transform.localEulerAngles;
                    angleTemp.y += 1.8f;
                    Ggos.g.goPic1btnspanel.transform.localEulerAngles = angleTemp;
                    angleTemp = Ggos.g.goPic1coinsocket.transform.localEulerAngles;
                    angleTemp.z += 3.6f;
                    Ggos.g.goPic1coinsocket.transform.localEulerAngles = angleTemp;
                }

                count++;
                if (count >= 130)
                {
                    Ggos.g.goPic1coinsocket.GetComponent<BoxCollider>().enabled = false;
                    for (int i = 0; i < Ggos.g.goPic1btns.Length; i++) Ggos.g.goPic1btns[i].GetComponent<BoxCollider>().enabled = true;
                    Gcam.touchable = true;
                    count = 0;
                    wasActive = 0;
                }
                break;
            //********************************************************************************************************
            case 48:
                if (count == 0)
                {
                    Gcam.touchable = false;
                    Ggos.g.goPic3coin1.SetActive(true);
                    Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[3]);
                }

                if (count == 29)
                {
                    Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[6]);
                }

                if (count > 29 && count < 130)
                {
                    angleTemp = Ggos.g.goPic3btnspanel.transform.localEulerAngles;
                    angleTemp.y += 1.8f;
                    Ggos.g.goPic3btnspanel.transform.localEulerAngles = angleTemp;
                    angleTemp = Ggos.g.goPic3coinsocket.transform.localEulerAngles;
                    angleTemp.z += 3.6f;
                    Ggos.g.goPic3coinsocket.transform.localEulerAngles = angleTemp;
                }

                count++;
                if (count >= 130)
                {
                    Ggos.g.goPic3coinsocket.GetComponent<BoxCollider>().enabled = false;
                    for (int i = 0; i < Ggos.g.goPic3btns.Length; i++) Ggos.g.goPic3btns[i].GetComponent<BoxCollider>().enabled = true;
                    Gcam.touchable = true;
                    count = 0;
                    wasActive = 0;
                }
                break;
            //********************************************************************************************************
            case 50:
                Ggos.g.goNotebook1flash1.SetActive(true);
                matTemp = Ggos.g.goNotebook1.GetComponent<MeshRenderer>().materials;
                matTemp[1] = Ggos.g.mats[5];
                Ggos.g.goNotebook1.GetComponent<MeshRenderer>().materials = matTemp;
                Ggos.g.goNotebook1.GetComponent<BoxCollider>().enabled = false;
                Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[4]);
                wasActive = 0;
                break;
            //********************************************************************************************************
            default:
                wasActive = 0;
                break;
        }



        switch (wasnotActive)
        {
            //********************************************************************************************************
            case 10:
                if (count == 0)
                {
                    angleTemp = new Vector3(0f, 0f, 0f);
                    Gcam.touchable = false;
                    Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[1]);
                }

                if (count < 8)
                {
                    angleTemp.z += 3;
                    Ggos.g.goDoor1handle.transform.localEulerAngles = angleTemp;
                }

                if (count >= 8) 
                {
                    angleTemp.z -= 3;
                    Ggos.g.goDoor1handle.transform.localEulerAngles = angleTemp;
                }

                count++;
                if (count > 15)
                {
                    Gcam.touchable = true;
                    count = 0;
                    wasnotActive = 0;
                }
                break;
            //********************************************************************************************************
            case 16:
                Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[1]);
                wasnotActive = 0;
                break;
            //********************************************************************************************************
            default:
                wasnotActive = 0;
                break;
        }
    }
}
