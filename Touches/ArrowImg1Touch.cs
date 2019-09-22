using UnityEngine;

public class ArrowImg1Touch : MonoBehaviour
{
    public static int[] aitTargetPos = {0,//0
                                        0,//1
                                        1,//2
                                        1,//3
                                        0,//4
                                        0,//5
                                        5,//6
                                        5,//7
                                        7,//8
                                        0,//9
                                        0,//10
                                        0,//11
                                        11,//12
                                        0,//13
                                        0,//14
                                        0,//15
                                        0,//16
                                        16,//17
                                        16,//18
                                        16,//19
                                        16,//20
                                        0,//21
                                        0,//22
                                        0,//23
                                        0,//24
                                        0,//25
                                        25,//26
                                        25,//27
                                        0,//28
                                        0,//29
                                        0,//30
                                        0,//31
                                        0,//32
                                        0,//33
                                        0,//34
                                        0,//35
                                        0,//36
                                        0//37
                                        };

    private void OnMouseUpAsButton()
    {
        if (Gcam.touchable)
        {
            Gcam.ChangeLocation(aitTargetPos[Gcam.myLoc]);
        }
    }
}
