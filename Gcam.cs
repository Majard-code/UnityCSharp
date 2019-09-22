using UnityEngine;
using UnityEngine.UI;

public class Gcam : MonoBehaviour
{
    public static bool rotable = false;
    public static bool touchable = false;
    public static bool fly = false;
    public static bool go1IsFly = false;
    public static bool go2IsFly = false;
    public static GameObject go1Fly;
    public static GameObject go2Fly;
    public static int myLoc = 0;
    public static int targetLoc = 0;

    public static Vector3 goTarget1 = new Vector3(0f, 0f, 0f);
    public static Vector3 goTarget2 = new Vector3(0f, 0f, 0f);

    public static Vector3[] camPos = new Vector3[100];
    public static Vector3[] camRot = new Vector3[100];


    public static float angleHor = 0;
    public static float angleVert = 0;
    public static Vector3 angleNull = new Vector3(0f, 135f, 0f);
    public static Quaternion originRot;
    private string s;


    private void Start()
    {
        originRot = Ggos.g.goMainCamera.transform.localRotation;
        // Нолевая позиция
        RecordNullCamPos();
        // Подушки
        camPos[1] = new Vector3(-0.9f, 1.25f, 1.14f);
        camRot[1] = new Vector3(45f, 0f, 0f);
        // Левая подушка
        camPos[2] = new Vector3(-1.2f, 0.63f, 1.45f);
        camRot[2] = new Vector3(30f, 0f, 0f);
        // Правая подушка
        camPos[3] = new Vector3(-0.59f, 0.63f, 1.45f);
        camRot[3] = new Vector3(30f, 0f, 0f);
        // Телевизор 1
        camPos[4] = new Vector3(-0.9f, 1.5f, -1f);
        camRot[4] = new Vector3(0f, 180f, 0f);
        // Левая тумбочка
        camPos[5] = new Vector3(-2.19f, 0.9f, 0.8f);
        camRot[5] = new Vector3(30f, 0f, 0f);
        // Лампа на левой тумбочке
        camPos[6] = new Vector3(-2.19f, 0.5f, 1.6f);
        camRot[6] = new Vector3(10f, 0f, 0f);
        // Выдвижной ящик левой тумбочки
        camPos[7] = new Vector3(-2.19f, 0.9f, 1.06f);
        camRot[7] = new Vector3(60f, 0f, 0f);
        // Книга 3
        camPos[8] = new Vector3(-2.19f, 0.9f, 1.06f);
        camRot[8] = new Vector3(60f, 0f, 0f);
        // Книжная полка 3
        camPos[9] = new Vector3(0.3f, 2.2f, 1.45f);
        camRot[9] = new Vector3(30f, 0f, 0f);
        // Дверь в гостинную
        camPos[10] = new Vector3(1.57f, 1.24f, -1.75f);
        camRot[10] = new Vector3(25f, 145f, 0f);
        // Книга 2 коллайдер
        camPos[11] = new Vector3(-0.64f, 1.1f, 1f);
        camRot[11] = new Vector3(53f, -12f, 0f);
        // Книга 2
        camPos[12] = new Vector3(-0.64f, 1.1f, 1f);
        camRot[12] = new Vector3(53f, -12f, 0f);
        // Книжная полка 2
        camPos[13] = new Vector3(-0.9f, 2.2f, 1.45f);
        camRot[13] = new Vector3(30f, 0f, 0f);
        // Решетка вентиляции в комнате 1
        camPos[14] = new Vector3(-1.78f, 2.3f, -1.3f);
        camRot[14] = new Vector3(-15f, 200f, 0f);
        // Внутри вентиляции в комнате 1
        camPos[15] = new Vector3(-2.1f, 2.7f, -1.9f);
        camRot[15] = new Vector3(40f, 200f, 0f);
        // Комод
        camPos[16] = new Vector3(-0.49f, 0.7f, -0.8f);
        camRot[16] = new Vector3(30f, 180f, 0f);
        // Комод Ящик 1
        camPos[17] = new Vector3(-0.09f, 1f, -1.05f);
        camRot[17] = new Vector3(60f, 180f, 0f);
        // Комод Ящик 2
        camPos[18] = new Vector3(-0.89f, 1f, -1.05f);
        camRot[18] = new Vector3(60f, 180f, 0f);
        // Комод Ящик 3
        camPos[19] = new Vector3(-0.09f, 0.9f, -1.02f);
        camRot[19] = new Vector3(60f, 180f, 0f);
        // Комод Ящик 4
        camPos[20] = new Vector3(-0.89f, 0.9f, -1.02f);
        camRot[20] = new Vector3(60f, 180f, 0f);
        // Картина 4
        camPos[21] = new Vector3(2.1f, 1.79f, -1.25f);
        camRot[21] = new Vector3(20f, 180f, 0f);
        // Картина 6
        camPos[22] = new Vector3(1.6f, 1.9f, 1f);
        camRot[22] = new Vector3(0f, 90f, 0f);
        // Колонка 1 дверца механизма
        camPos[23] = new Vector3(1.1f, 0.38f, -1.85f);
        camRot[23] = new Vector3(30f, 260f, 0f);
        // Колонка 2 дверца механизма
        camPos[24] = new Vector3(-2.135f, 0.38f, -1.85f);
        camRot[24] = new Vector3(30f, 100f, 0f);
        // Правая тумбочка
        camPos[25] = new Vector3(0.39f, 0.9f, 0.8f);
        camRot[25] = new Vector3(30f, 0f, 0f);
        // Лампа на правой тумбочке
        camPos[26] = new Vector3(0.39f, 0.5f, 1.6f);
        camRot[26] = new Vector3(10f, 0f, 0f);
        // Выдвижной ящик правой тумбочки
        camPos[27] = new Vector3(0.39f, 0.9f, 1.06f);
        camRot[27] = new Vector3(60f, 0f, 0f);
        // Стул
        camPos[28] = new Vector3(2.25f, 1f, 0.27f);
        camRot[28] = new Vector3(60f, 90f, 0f);
        // Картина 2
        camPos[29] = new Vector3(-0.9f, 1.75f, 1f);
        camRot[29] = new Vector3(0f, 0f, 0f);
        // Картина 2 внутри
        camPos[30] = new Vector3(-0.9f, 1.78f, 1.8f);
        camRot[30] = new Vector3(0f, 0f, 0f);
        // Картина 1
        camPos[31] = new Vector3(-2.1f, 1.75f, 1f);
        camRot[31] = new Vector3(0f, 0f, 0f);
        // Картина 1 внутри
        camPos[32] = new Vector3(-2.1f, 1.78f, 1.8f);
        camRot[32] = new Vector3(0f, 0f, 0f);
        // Решетка вентиляции в комнате 2
        camPos[33] = new Vector3(-1.78f, 2.3f, -1.3f);
        camRot[33] = new Vector3(-15f, 200f, 0f);
        // Внутри вентиляции в комнате 2
        camPos[34] = new Vector3(-2.1f, 2.7f, -1.9f);
        camRot[34] = new Vector3(40f, 200f, 0f);
        // Картина 3
        camPos[35] = new Vector3(0.3f, 1.75f, 1f);
        camRot[35] = new Vector3(0f, 0f, 0f);
        // Картина 3 внутри
        camPos[36] = new Vector3(0.3f, 1.78f, 1.8f);
        camRot[36] = new Vector3(0f, 0f, 0f);
        // Ноутбук
        camPos[37] = new Vector3(2f, 0.97f, 1.14f);
        camRot[37] = new Vector3(38f, 45f, 0f);
    }

    public static void RecordNullCamPos()
    {
        camPos[0] = Ggos.g.goMainCamera.transform.localPosition;
        camRot[0] = Ggos.g.goMainCamera.transform.localEulerAngles;
    }

    public static void ChangeLocation(int cli)
    {
        if (!AdvManager.advLoaded)
        {
            if (!AdvManager.isLoading)
            {
                AdvManager.AdvInterLoad();
            }
        }
        rotable = false;
        touchable = false;

        if (myLoc == 0)
        {
            RecordNullCamPos();
            Ggos.g.goArrowImg1.SetActive(true);
        }

        if (cli == 0) Ggos.g.goArrowImg1.SetActive(false);
        targetLoc = cli;
        ChangeLocAssist();
        fly = true;
    }
// *********** АССИСТЕНТ СМЕНЫ ЛОКАЦИИ ******************************************************************************************************************
    public static void ChangeLocAssist()
    {
        switch (myLoc)
        {
            //********************************************************************************************************
            case 0:
                switch (targetLoc)
                {
                    case 1:
                        Ggos.g.goBad1.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBad1table1.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBad1table2.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBad1pillow1.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goBad1pillow2.GetComponent<BoxCollider>().enabled = true;
                        break;
                    case 4:
                        if (Gevents.gEvents[5] == 0)
                        {
                            Ggos.g.goTv100.SetActive(false);
                            Ggos.g.goTv101.SetActive(true);
                        }
                        else
                        {
                            Ggos.g.goTv11.GetComponent<BoxCollider>().enabled = false;
                        }
                        break;
                    case 5:
                        Ggos.g.goBad1.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBad1table1.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBad1table1lamp.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goBad1table1drawer.GetComponent<BoxCollider>().enabled = true;
                        break;
                    case 9:
                        Ggos.g.goBookshelf3.GetComponent<BoxCollider>().enabled = false;
                        if (Gevents.gEvents[8] == 0)
                        {
                            for (int i = 0; i < Ggos.g.goBookshelf3books.Length; i++) Ggos.g.goBookshelf3books[i].GetComponent<BoxCollider>().enabled = true;
                        }
                        else
                        {
                            Ggos.g.goDoor1key0.GetComponent<BoxCollider>().enabled = true;
                            Ggos.g.goCard1.GetComponent<BoxCollider>().enabled = true;
                        }
                        break;
                    case 10:
                        Ggos.g.goDoor1.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goDoor1keyholeplate.GetComponent<BoxCollider>().enabled = true;
                        break;
                    case 11:
                        Ggos.g.goBook2coll.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBook2.GetComponent<BoxCollider>().enabled = true;
                        break;
                    case 13:
                        Ggos.g.goBookshelf2.GetComponent<BoxCollider>().enabled = false;
                        if (Gevents.gEvents[12] == 0)
                        {
                            for (int i = 0; i < Ggos.g.goBookshelf2books.Length; i++) Ggos.g.goBookshelf2books[i].GetComponent<BoxCollider>().enabled = true;
                        }
                        else
                        {
                            Ggos.g.goWrenchdriver0.GetComponent<BoxCollider>().enabled = true;
                            Ggos.g.goBox4.GetComponent<BoxCollider>().enabled = true;
                        }
                        break;
                    case 14:
                        Ggos.g.goVentilation1.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goVentilation1grid.GetComponent<BoxCollider>().enabled = true;
                        break;
                    case 15:
                        Ggos.g.goVentilation1.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBureau1key20.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goPic1piece70.GetComponent<BoxCollider>().enabled = true;
                        break;
                    case 16:
                        Ggos.g.goBureau1.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goSp1.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goSp2.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBureau1drawer1.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goBureau1drawer2.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goBureau1drawer3.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goBureau1drawer4.GetComponent<BoxCollider>().enabled = true;
                        break;
                    case 21:
                        Ggos.g.goPic4.GetComponent<BoxCollider>().enabled = false;
                        if (Gevents.gEvents[18] == 1)
                        {
                            if (Gevents.gEvents[19] == 1)
                            {
                                if (Gevents.gEvents[21] == 1)
                                {
                                    Ggos.g.goPic2key0.GetComponent<BoxCollider>().enabled = true;
                                    Ggos.g.goNotebook1flash0.GetComponent<BoxCollider>().enabled = true;
                                    if (Gevents.gEvents[75] == 0 || Gevents.gEvents[76] == 0) Ggos.g.goPiramids[0].GetComponent<BoxCollider>().enabled = true;
                                }
                                else
                                {
                                    for (int i = 0; i < 4; i++) Ggos.g.goSafe2coderolls[i].GetComponent<BoxCollider>().enabled = true;
                                }
                            }
                            else
                            {
                                for (int i = 0; i < 9; i++) Ggos.g.goPic4pieces[i].GetComponent<BoxCollider>().enabled = true;
                            }
                        }
                        else
                        {
                            Ggos.g.goPic4P.GetComponent<BoxCollider>().enabled = true;
                        }
                        break;
                    case 22:
                        Ggos.g.goPic6.GetComponent<BoxCollider>().enabled = false;
                        Gevents.WasEvent(20);
                        break;
                    case 23:
                        Ggos.g.goSp1.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goSp2.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBureau1.GetComponent<BoxCollider>().enabled = false;
                        if (Gevents.gEvents[23] == 0) Ggos.g.goSp1door.GetComponent<BoxCollider>().enabled = true;
                        if (Gevents.gEvents[23] == 1 && Gevents.gEvents[28] == 0) Ggos.g.goSp1pin2.GetComponent<BoxCollider>().enabled = true;
                        break;
                    case 24:
                        Ggos.g.goSp1.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goSp2.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBureau1.GetComponent<BoxCollider>().enabled = false;
                        if (Gevents.gEvents[24] == 0) Ggos.g.goSp2door.GetComponent<BoxCollider>().enabled = true;
                        if (Gevents.gEvents[24] == 1 && Gevents.gEvents[29] == 0) Ggos.g.goSp2pin1.GetComponent<BoxCollider>().enabled = true;
                        break;
                    case 25:
                        Ggos.g.goBad1.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBad1table2.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBad1table2lamp.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goBad1table2drawer.GetComponent<BoxCollider>().enabled = true;
                        break;
                    case 28:
                        Ggos.g.goChair1.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBigcogwheel1.GetComponent<BoxCollider>().enabled = true;
                        break;
                    case 29:
                        Ggos.g.goPic2.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goPic1.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goPic3.GetComponent<BoxCollider>().enabled = false;
                        if (Gevents.gEvents[31] == 1)
                        {
                            if (Gevents.gEvents[32] == 0)
                            {
                                for (int i = 0; i < 9; i++) Ggos.g.goPic2pieces[i].GetComponent<BoxCollider>().enabled = true;
                            }
                        }
                        else
                        {
                            Ggos.g.goPic2in.GetComponent<BoxCollider>().enabled = true;
                        }
                        break;
                    case 30:
                        Ggos.g.goPic2.GetComponent<BoxCollider>().enabled = false;
                        if (Gevents.gEvents[42] == 0) Ggos.g.goPic2keyhole.GetComponent<BoxCollider>().enabled = true;
                        break;
                    case 31:
                        Ggos.g.goPic1.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goPic2.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goLamp2.GetComponent<BoxCollider>().enabled = false;
                        if (Gevents.gEvents[35] == 1)
                        {
                            if (Gevents.gEvents[36] == 0)
                            {
                                for (int i = 0; i < 9; i++) Ggos.g.goPic1pieces[i].GetComponent<BoxCollider>().enabled = true;
                            }
                        }
                        else
                        {
                            Ggos.g.goPic1in.GetComponent<BoxCollider>().enabled = true;
                        }
                        break;
                    case 32:
                        Ggos.g.goPic1.GetComponent<BoxCollider>().enabled = false;
                        if (Gevents.gEvents[46] == 1)
                        {
                            if (Gevents.gEvents[51] == 0)
                            {
                                for (int i = 1; i < Ggos.g.goPic1btns.Length; i++) Ggos.g.goPic1btns[i].GetComponent<BoxCollider>().enabled = true;
                            }
                        }
                        else
                        {
                            Ggos.g.goPic1coinsocket.GetComponent<BoxCollider>().enabled = true;
                        }
                        break;
                    case 33:
                        Ggos.g.goVentilation2.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goVentilation2grid.GetComponent<BoxCollider>().enabled = true;
                        break;
                    case 34:
                        Ggos.g.goVentilation2.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goPic3coin0.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goPic3piece90.GetComponent<BoxCollider>().enabled = true;
                        break;
                    case 35:
                        Ggos.g.goPic3.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goPic2.GetComponent<BoxCollider>().enabled = false;
                        if (Gevents.gEvents[39] == 1)
                        {
                            if (Gevents.gEvents[40] == 0)
                            {
                                for (int i = 0; i < 9; i++) Ggos.g.goPic3pieces[i].GetComponent<BoxCollider>().enabled = true;
                            }
                        }
                        else
                        {
                            Ggos.g.goPic3in.GetComponent<BoxCollider>().enabled = true;
                        }
                        break;
                    case 36:
                        Ggos.g.goPic3.GetComponent<BoxCollider>().enabled = false;
                        if (Gevents.gEvents[48] == 1)
                        {
                            if (Gevents.gEvents[52] == 0)
                            {
                                for (int i = 1; i < Ggos.g.goPic3btns.Length; i++) Ggos.g.goPic3btns[i].GetComponent<BoxCollider>().enabled = true;
                            }
                        }
                        else
                        {
                            Ggos.g.goPic3coinsocket.GetComponent<BoxCollider>().enabled = true;
                        }
                        break;
                    case 37:
                        Ggos.g.goTable1.GetComponent<BoxCollider>().enabled = false;
                        if (Gevents.gEvents[50] == 0) Ggos.g.goNotebook1.GetComponent<BoxCollider>().enabled = true;
                        break;
                }
                break;
            //********************************************************************************************************
            case 1:
                switch (targetLoc)
                {
                    case 0:
                        Ggos.g.goBad1.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goBad1table1.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goBad1table2.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goBad1pillow1.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBad1pillow2.GetComponent<BoxCollider>().enabled = false;
                        break;
                    case 2:
                        Ggos.g.goBad1pillow1.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBad1pillow2.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goTv1remote0.GetComponent<BoxCollider>().enabled = true;

                        go1IsFly = true;
                        go1Fly = Ggos.g.goBad1pillow1;
                        goTarget1 = new Vector3(-0.3f, 0.67f, -0.2f);
                        break;
                    case 3:
                        Ggos.g.goBad1pillow1.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBad1pillow2.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goPic1coin0.GetComponent<BoxCollider>().enabled = true;

                        go1IsFly = true;
                        go1Fly = Ggos.g.goBad1pillow2;
                        goTarget1 = new Vector3(0.31f, 0.67f, -0.2f);
                        break;
                }
                break;
            //********************************************************************************************************
            case 2:
                switch (targetLoc)
                {
                    case 1:
                        Ggos.g.goBad1pillow1.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goBad1pillow2.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goTv1remote0.GetComponent<BoxCollider>().enabled = false;

                        go1IsFly = true;
                        go1Fly = Ggos.g.goBad1pillow1;
                        goTarget1 = new Vector3(-0.3f, 0.52f, -0.2f);
                        break;
                }
                break;
            //********************************************************************************************************
            case 3:
                switch (targetLoc)
                {
                    case 1:
                        Ggos.g.goBad1pillow1.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goBad1pillow2.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goPic1coin0.GetComponent<BoxCollider>().enabled = false;

                        go1IsFly = true;
                        go1Fly = Ggos.g.goBad1pillow2;
                        goTarget1 = new Vector3(0.31f, 0.52f, -0.2f);
                        break;
                }
                break;
            //********************************************************************************************************
            case 4:
                switch (targetLoc)
                {
                    case 0:
                        if (Gevents.gEvents[5] == 0)
                        {
                            Ggos.g.goTv100.SetActive(true);
                            Ggos.g.goTv101.SetActive(false);
                        }
                        else
                        {
                            Ggos.g.goTv11.GetComponent<BoxCollider>().enabled = true;
                        }
                        break;
                }
                break;
            //********************************************************************************************************
            case 5:
                switch (targetLoc)
                {
                    case 0:
                        Ggos.g.goBad1.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goBad1table1.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goBad1table1lamp.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBad1table1drawer.GetComponent<BoxCollider>().enabled = false;
                        break;
                    case 6:
                        Ggos.g.goBad1table1lamp.GetComponent<BoxCollider>().enabled = false;
                        if (Gevents.gEvents[6] == 0)
                        {
                            Ggos.g.goLamp1rolls[0].GetComponent<BoxCollider>().enabled = true;
                            Ggos.g.goLamp1rolls[1].GetComponent<BoxCollider>().enabled = true;
                            Ggos.g.goLamp1rolls[2].GetComponent<BoxCollider>().enabled = true;
                            Ggos.g.goLamp1rolls[3].GetComponent<BoxCollider>().enabled = true;
                        }
                        break;
                    case 7:
                        Ggos.g.goBad1table1lamp.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBad1table1drawer.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBook3.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goCard4.GetComponent<BoxCollider>().enabled = true;

                        go1IsFly = true;
                        go1Fly = Ggos.g.goBad1table1drawer;
                        goTarget1 = new Vector3(-2.19f, 0.26f, 1.26f);

                        Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[2]);
                        break;
                }
                break;
            //********************************************************************************************************
            case 6:
                switch (targetLoc)
                {
                    case 5:
                        Ggos.g.goBad1table1lamp.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goLamp1rolls[0].GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goLamp1rolls[1].GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goLamp1rolls[2].GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goLamp1rolls[3].GetComponent<BoxCollider>().enabled = false;
                        break;
                }
                break;
            //********************************************************************************************************
            case 7:
                switch (targetLoc)
                {
                    case 5:
                        Ggos.g.goBad1table1lamp.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goBad1table1drawer.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goBook3.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goCard4.GetComponent<BoxCollider>().enabled = false;

                        go1IsFly = true;
                        go1Fly = Ggos.g.goBad1table1drawer;
                        goTarget1 = new Vector3(-2.19f, 0.26f, 1.56f);

                        Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[2]);
                        break;
                    case 8:
                        Ggos.g.goBook3.SetActive(false);
                        Ggos.g.goCard4.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goLookCamera.SetActive(true);
                        Ggos.g.goBook30l.SetActive(true);
                        Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[0]);
                        Gevents.WasEvent(7);
                        break;
                }
                break;
            //********************************************************************************************************
            case 8:
                switch (targetLoc)
                {
                    case 7:
                        Ggos.g.goBook30l.SetActive(false);
                        Ggos.g.goLookCamera.SetActive(false);
                        Ggos.g.goBook3.SetActive(true);
                        Ggos.g.goCard4.GetComponent<BoxCollider>().enabled = true;
                        break;
                }
                break;
            //********************************************************************************************************
            case 9:
                switch (targetLoc)
                {
                    case 0:
                        Ggos.g.goBookshelf3.GetComponent<BoxCollider>().enabled = true;
                        for (int i = 0; i < Ggos.g.goBookshelf3books.Length; i++) Ggos.g.goBookshelf3books[i].GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goDoor1key0.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goCard1.GetComponent<BoxCollider>().enabled = false;
                        break;
                }
                break;
            //********************************************************************************************************
            case 10:
                switch (targetLoc)
                {
                    case 0:
                        Ggos.g.goDoor1.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goDoor1keyholeplate.GetComponent<BoxCollider>().enabled = false;
                        break;
                }
                break;
            //********************************************************************************************************
            case 11:
                switch (targetLoc)
                {
                    case 0:
                        Ggos.g.goBook2coll.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goBook2.GetComponent<BoxCollider>().enabled = false;
                        break;
                    case 12:
                        Ggos.g.goBook2coll.SetActive(false);
                        Ggos.g.goLookCamera.SetActive(true);
                        Ggos.g.goBook20l.SetActive(true);
                        Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[0]);
                        Gevents.WasEvent(11);
                        break;
                }
                break;
            //********************************************************************************************************
            case 12:
                switch (targetLoc)
                {
                    case 11:
                        Ggos.g.goBook2coll.SetActive(true);
                        Ggos.g.goLookCamera.SetActive(false);
                        Ggos.g.goBook20l.SetActive(false);
                        break;
                }
                break;
            //********************************************************************************************************
            case 13:
                switch (targetLoc)
                {
                    case 0:
                        Ggos.g.goBookshelf2.GetComponent<BoxCollider>().enabled = true;
                        for (int i = 0; i < Ggos.g.goBookshelf2books.Length; i++) Ggos.g.goBookshelf2books[i].GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goWrenchdriver0.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBox4.GetComponent<BoxCollider>().enabled = false;
                        break;
                }
                break;
            //********************************************************************************************************
            case 14:
                switch (targetLoc)
                {
                    case 0:
                        Ggos.g.goVentilation1.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goVentilation1grid.GetComponent<BoxCollider>().enabled = false;
                        break;
                    case 15:
                        Ggos.g.goVentilation1.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBureau1key20.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goPic1piece70.GetComponent<BoxCollider>().enabled = true;
                        break;
                }
                break;
            //********************************************************************************************************
            case 15:
                switch (targetLoc)
                {
                    case 0:
                        Ggos.g.goVentilation1.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goBureau1key20.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goPic1piece70.GetComponent<BoxCollider>().enabled = false;
                        break;
                }
                break;
            //********************************************************************************************************
            case 16:
                switch (targetLoc)
                {
                    case 0:
                        Ggos.g.goBureau1.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goSp1.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goSp2.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goBureau1drawer1.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBureau1drawer2.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBureau1drawer3.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBureau1drawer4.GetComponent<BoxCollider>().enabled = false;
                        break;
                    case 17:
                        Ggos.g.goBook1.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goPiramid30.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goBox3.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goBureau1drawer1.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBureau1drawer2.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBureau1drawer3.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBureau1drawer4.GetComponent<BoxCollider>().enabled = false;

                        go1IsFly = true;
                        go1Fly = Ggos.g.goBureau1drawer1;
                        goTarget1 = new Vector3(-0.09f, 0.3f, -1.3f);

                        Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[2]);
                        break;
                    case 18:
                        Ggos.g.goNote1.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goScrewdriver0.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goPic4piece40.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goBureau1drawer1.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBureau1drawer2.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBureau1drawer3.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBureau1drawer4.GetComponent<BoxCollider>().enabled = false;

                        go1IsFly = true;
                        go1Fly = Ggos.g.goBureau1drawer2;
                        goTarget1 = new Vector3(-0.89f, 0.3f, -1.3f);

                        Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[2]);
                        break;
                    case 19:
                        Ggos.g.goPic2piece80.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goBureau1drawer1.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBureau1drawer2.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBureau1drawer3.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBureau1drawer4.GetComponent<BoxCollider>().enabled = false;

                        go1IsFly = true;
                        go1Fly = Ggos.g.goBureau1drawer3;
                        goTarget1 = new Vector3(-0.09f, 0.1f, -1.3f);

                        Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[2]);
                        break;
                    case 20:
                        Ggos.g.goCard3.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goBureau1drawer1.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBureau1drawer2.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBureau1drawer3.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBureau1drawer4.GetComponent<BoxCollider>().enabled = false;

                        go1IsFly = true;
                        go1Fly = Ggos.g.goBureau1drawer4;
                        goTarget1 = new Vector3(-0.89f, 0.1f, -1.3f);

                        Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[2]);
                        break;
                }
                break;
            //********************************************************************************************************
            case 17:
                switch (targetLoc)
                {
                    case 16:
                        Ggos.g.goBook1.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goPiramid30.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBox3.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBureau1drawer1.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goBureau1drawer2.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goBureau1drawer3.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goBureau1drawer4.GetComponent<BoxCollider>().enabled = true;

                        go1IsFly = true;
                        go1Fly = Ggos.g.goBureau1drawer1;
                        goTarget1 = new Vector3(-0.09f, 0.3f, -1.6f);

                        Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[2]);
                        break;
                }
                break;
            //********************************************************************************************************
            case 18:
                switch (targetLoc)
                {
                    case 16:
                        Ggos.g.goNote1.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goScrewdriver0.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goPic4piece40.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBureau1drawer1.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goBureau1drawer2.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goBureau1drawer3.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goBureau1drawer4.GetComponent<BoxCollider>().enabled = true;

                        go1IsFly = true;
                        go1Fly = Ggos.g.goBureau1drawer2;
                        goTarget1 = new Vector3(-0.89f, 0.3f, -1.6f);

                        Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[2]);
                        break;
                }
                break;
            //********************************************************************************************************
            case 19:
                switch (targetLoc)
                {
                    case 16:
                        Ggos.g.goPic2piece80.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBureau1drawer1.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goBureau1drawer2.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goBureau1drawer3.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goBureau1drawer4.GetComponent<BoxCollider>().enabled = true;

                        go1IsFly = true;
                        go1Fly = Ggos.g.goBureau1drawer3;
                        goTarget1 = new Vector3(-0.09f, 0.1f, -1.6f);

                        Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[2]);
                        break;
                }
                break;
            //********************************************************************************************************
            case 20:
                switch (targetLoc)
                {
                    case 16:
                        Ggos.g.goCard3.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBureau1drawer1.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goBureau1drawer2.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goBureau1drawer3.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goBureau1drawer4.GetComponent<BoxCollider>().enabled = true;

                        go1IsFly = true;
                        go1Fly = Ggos.g.goBureau1drawer4;
                        goTarget1 = new Vector3(-0.89f, 0.1f, -1.6f);

                        Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[2]);
                        break;
                }
                break;
            //********************************************************************************************************
            case 21:
                switch (targetLoc)
                {
                    case 0:
                        Ggos.g.goPic4.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goPic2key0.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goNotebook1flash0.GetComponent<BoxCollider>().enabled = false;
                        for (int i = 0; i < 9; i++) Ggos.g.goPic4pieces[i].GetComponent<BoxCollider>().enabled = false;
                        for (int i = 0; i < 4; i++) Ggos.g.goSafe2coderolls[i].GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goPic4P.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goPiramids[0].GetComponent<BoxCollider>().enabled = false;
                        break;
                }
                break;
            //********************************************************************************************************
            case 22:
                switch (targetLoc)
                {
                    case 0:
                        Ggos.g.goPic6.GetComponent<BoxCollider>().enabled = true;
                        break;
                }
                break;
            //********************************************************************************************************
            case 23:
                switch (targetLoc)
                {
                    case 0:
                        Ggos.g.goSp1.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goSp2.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goBureau1.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goSp1door.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goSp1pin2.GetComponent<BoxCollider>().enabled = false;
                        break;
                }
                break;
            //********************************************************************************************************
            case 24:
                switch (targetLoc)
                {
                    case 0:
                        Ggos.g.goSp1.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goSp2.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goBureau1.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goSp2door.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goSp2pin1.GetComponent<BoxCollider>().enabled = false;
                        break;
                }
                break;
            //********************************************************************************************************
            case 25:
                switch (targetLoc)
                {
                    case 0:
                        Ggos.g.goBad1.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goBad1table2.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goBad1table2lamp.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBad1table2drawer.GetComponent<BoxCollider>().enabled = false;
                        break;
                    case 26:
                        Ggos.g.goBad1table2lamp.GetComponent<BoxCollider>().enabled = false;
                        if (Gevents.gEvents[25] == 0)
                        {
                            Ggos.g.goLamp2rolls[0].GetComponent<BoxCollider>().enabled = true;
                            Ggos.g.goLamp2rolls[1].GetComponent<BoxCollider>().enabled = true;
                            Ggos.g.goLamp2rolls[2].GetComponent<BoxCollider>().enabled = true;
                            Ggos.g.goLamp2rolls[3].GetComponent<BoxCollider>().enabled = true;
                        }
                        break;
                    case 27:
                        Ggos.g.goBad1table2lamp.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBad1table2drawer.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goBox2.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goSmallcogwheel1.GetComponent<BoxCollider>().enabled = true;

                        go1IsFly = true;
                        go1Fly = Ggos.g.goBad1table2drawer;
                        goTarget1 = new Vector3(0.39f, 0.26f, 1.26f);

                        Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[2]);
                        break;
                }
                break;
            //********************************************************************************************************
            case 26:
                switch (targetLoc)
                {
                    case 25:
                        Ggos.g.goBad1table2lamp.GetComponent<BoxCollider>().enabled = true;
                        for (int i = 0; i < Ggos.g.goLamp2rolls.Length; i++) Ggos.g.goLamp2rolls[i].GetComponent<BoxCollider>().enabled = false;
                        break;
                }
                break;
            //********************************************************************************************************
            case 27:
                switch (targetLoc)
                {
                    case 25:
                        Ggos.g.goBad1table2lamp.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goBad1table2drawer.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goBox2.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goSmallcogwheel1.GetComponent<BoxCollider>().enabled = false;

                        go1IsFly = true;
                        go1Fly = Ggos.g.goBad1table2drawer;
                        goTarget1 = new Vector3(0.39f, 0.26f, 1.56f);

                        Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[2]);
                        break;
                }
                break;
            //********************************************************************************************************
            case 28:
                switch (targetLoc)
                {
                    case 0:
                        Ggos.g.goChair1.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goBigcogwheel1.GetComponent<BoxCollider>().enabled = false;
                        break;
                }
                break;
            //********************************************************************************************************
            case 29:
                switch (targetLoc)
                {
                    case 0:
                        Ggos.g.goPic2.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goPic1.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goPic3.GetComponent<BoxCollider>().enabled = true;
                        for (int i = 0; i < Ggos.g.goPic2pieces.Length; i++) Ggos.g.goPic2pieces[i].GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goPic2in.GetComponent<BoxCollider>().enabled = false;
                        break;
                }
                break;
            //********************************************************************************************************
            case 30:
                switch (targetLoc)
                {
                    case 0:
                        Ggos.g.goPic2.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goPic2keyhole.GetComponent<BoxCollider>().enabled = false;
                        break;
                }
                break;
            //********************************************************************************************************
            case 31:
                switch (targetLoc)
                {
                    case 0:
                        Ggos.g.goPic1.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goPic2.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goLamp2.GetComponent<BoxCollider>().enabled = true;
                        for (int i = 0; i < Ggos.g.goPic1pieces.Length; i++) Ggos.g.goPic1pieces[i].GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goPic1in.GetComponent<BoxCollider>().enabled = false;
                        break;
                }
                break;
            //********************************************************************************************************
            case 32:
                switch (targetLoc)
                {
                    case 0:
                        Codes.Clear9(10);
                        Ggos.g.goPic1.GetComponent<BoxCollider>().enabled = true;
                        for (int i = 1; i < Ggos.g.goPic1btns.Length; i++) Ggos.g.goPic1btns[i].GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goPic1coinsocket.GetComponent<BoxCollider>().enabled = false;
                        break;
                }
                break;
            //********************************************************************************************************
            case 33:
                switch (targetLoc)
                {
                    case 0:
                        Ggos.g.goVentilation2.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goVentilation2grid.GetComponent<BoxCollider>().enabled = false;
                        break;
                    case 34:
                        Ggos.g.goPic3coin0.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goPic3piece90.GetComponent<BoxCollider>().enabled = true;
                        break;
                }
                break;
            //********************************************************************************************************
            case 34:
                switch (targetLoc)
                {
                    case 0:
                        Ggos.g.goVentilation2.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goPic3coin0.GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goPic3piece90.GetComponent<BoxCollider>().enabled = false;
                        break;
                }
                break;
            //********************************************************************************************************
            case 35:
                switch (targetLoc)
                {
                    case 0:
                        Ggos.g.goPic3.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goPic2.GetComponent<BoxCollider>().enabled = true;
                        for (int i = 0; i < Ggos.g.goPic3pieces.Length; i++) Ggos.g.goPic3pieces[i].GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goPic3in.GetComponent<BoxCollider>().enabled = false;
                        break;
                }
                break;
            //********************************************************************************************************
            case 36:
                switch (targetLoc)
                {
                    case 0:
                        Ggos.g.goPic3.GetComponent<BoxCollider>().enabled = true;
                        for (int i = 1; i < Ggos.g.goPic3btns.Length; i++) Ggos.g.goPic3btns[i].GetComponent<BoxCollider>().enabled = false;
                        Ggos.g.goPic3coinsocket.GetComponent<BoxCollider>().enabled = false;
                        break;
                }
                break;
            //********************************************************************************************************
            case 37:
                switch (targetLoc)
                {
                    case 0:
                        Ggos.g.goTable1.GetComponent<BoxCollider>().enabled = true;
                        Ggos.g.goNotebook1.GetComponent<BoxCollider>().enabled = false;
                        break;
                }
                break;


        }
    }
// *********** КОНЕЦ АССИСТЕНТА СМЕНЫ ЛОКАЦИИ ***********************************************************************************************************

    public static void PosReset()
    {
        if (Gevents.gEvents[0] == 0)
        {
            angleNull.y = 135f;
        }
        else
        {
            angleNull.y = 50f;
        }
        angleHor = 0;
        angleVert = 0;
        Ggos.g.goMainCamera.transform.localEulerAngles = angleNull;
        Ggos.g.goMainCamera.transform.localPosition = new Vector3(0f, 1.7f, 0f);
        originRot = Ggos.g.goMainCamera.transform.localRotation;
    }


    private void FixedUpdate()
    {
        s = "\n" + Codes.codeReal[10][0].ToString() + " * " + Codes.codeReal[10][1].ToString() + " * " + Codes.codeReal[10][2].ToString() + " * " + Codes.codeReal[10][3].ToString() + " * " + Codes.codeReal[10][4].ToString() + " * " + Codes.codeReal[10][5].ToString() + " * " + Codes.codeReal[10][6].ToString() + " * " + Codes.codeReal[10][7].ToString() + " * " + Codes.codeReal[10][8].ToString();

        if (touchable)
        {
            Ggos.g.goDebText.GetComponent<Text>().text = "touchabe count: " + Codes.count.ToString() + " myLoc: " + myLoc.ToString() + s;
        }
        else
        {
            Ggos.g.goDebText.GetComponent<Text>().text = "NON touchabe count: " + Codes.count.ToString() + " myLoc: " + myLoc.ToString() + s;

        }
        if (fly)
        {
            Ggos.g.goMainCamera.transform.localPosition = Vector3.Lerp(Ggos.g.goMainCamera.transform.localPosition, camPos[targetLoc], Time.deltaTime * 20f);
            Ggos.g.goMainCamera.transform.localRotation = Quaternion.Slerp(Ggos.g.goMainCamera.transform.localRotation, Quaternion.Euler(camRot[targetLoc]), Time.deltaTime * 20f);

            if (go1IsFly) go1Fly.transform.localPosition = Vector3.Lerp(go1Fly.transform.localPosition, goTarget1, Time.deltaTime * 20f);
            if (go2IsFly) go2Fly.transform.localPosition = Vector3.Lerp(go2Fly.transform.localPosition, goTarget2, Time.deltaTime * 20f);

            if (Ggos.g.goMainCamera.transform.localPosition == camPos[targetLoc])
            {
                touchable = true;
                myLoc = targetLoc;
                fly = false;
                go1IsFly = false;
                go2IsFly = false;
                if (myLoc == 0) rotable = true;
            }
        }
    }

    private void Update()
    {
        if (rotable)
        {
#if UNITY_EDITOR
            if (Input.GetKey(KeyCode.Mouse1))
            {
                angleHor += Input.GetAxis("Mouse X") * Time.deltaTime * 200f;
                angleVert += Input.GetAxis("Mouse Y") * Time.deltaTime * 200f;

                angleVert = Mathf.Clamp(angleVert, -60, 60);


                Quaternion rotY = Quaternion.AngleAxis(angleHor, Vector3.up);
                Quaternion rotX = Quaternion.AngleAxis(-angleVert, Vector3.right);

                Ggos.g.goMainCamera.transform.localRotation = originRot * rotY * rotX;
        }
#endif
#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            Vector2 delta = Input.touches[0].deltaPosition;
            angleHor += delta.x * Time.deltaTime * 8f;
            angleVert += delta.y * Time.deltaTime * 8f;

            angleVert = Mathf.Clamp(angleVert, -60, 60);

            Quaternion rotY = Quaternion.AngleAxis(angleHor, Vector3.up);
            Quaternion rotX = Quaternion.AngleAxis(-angleVert, Vector3.right);

            Ggos.g.goMainCamera.transform.localRotation = originRot * rotY * rotX;
        }
#endif
    }

}
}
