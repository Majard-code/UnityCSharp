using UnityEngine;

public class Ggos : MonoBehaviour
{
    [Header("Main:")]
    public GameObject goGameManager;

    [Header("Cameras:")]
    public GameObject goMainCamera;
    public GameObject goItemCamera;
    public GameObject goLookCamera;
    public GameObject goMenuCamera;

    [Header("Canvas1 UI Elements:")]
    public GameObject goCanvas1;
    public GameObject goCanvas1BG;
    public GameObject goGameName;
    public GameObject goDebText;

    [Header("Canvas2 UI Elements:")]
    public GameObject goCanvas2;
    public GameObject goCanvas2BG;
    public GameObject goCrossImg2;

    [Header("Canvas3 UI Elements:")]
    public GameObject goCanvas3;
    public GameObject goCanvas3BG;

    [Header("Canvas4 UI Elements:")]
    public GameObject goCanvas4;
    public GameObject goCanvas4BG;
    public GameObject goCanvas40BG;
    public GameObject goSoundImgOff;
    public GameObject goSoundImgOn;
    public GameObject goAdImg;
    public GameObject goStarImg1;
    public GameObject goStarImg2;
    public GameObject goHelpImg;
    public GameObject goHelpCount;
    public GameObject goHelpCountInfin;
    public GameObject goArrowImg1;
    public GameObject goCrossImg4;

    [Header("Look Camera Items:")]
    public GameObject goBook30l;
    public GameObject goBook20l;

    [Header("Game Objects:")]
    public GameObject goRoom1;
    public GameObject goRoom2;
    public GameObject goBad1;
    public GameObject goBad1pillow1;
    public GameObject goTv1remote0;
    public GameObject goBad1pillow2;
    public GameObject goPic1coin0;
    public GameObject goTv100;
    public GameObject goTv101;
    public GameObject goTv11;
    public GameObject goBad1table1;
    public GameObject goBad1table1lamp;
    public GameObject[] goLamp1rolls;
    public GameObject goBad1table1drawer;
    public GameObject goBook3;
    public GameObject goCard4;
    public GameObject goBookshelf3;
    public GameObject goBookshelf3in;
    public GameObject[] goBookshelf3books;
    public GameObject goDoor1key0;
    public GameObject goCard1;
    public GameObject goDoor1;
    public GameObject goDoor1keyholeplate;
    public GameObject goDoor1keyhole;
    public GameObject goDoor1key1;
    public GameObject goDoor1handle;
    public GameObject goDoor3;
    public GameObject goDoor3handle;
    public GameObject goBook2coll;
    public GameObject goBook2;
    public GameObject goBookshelf2;
    public GameObject goBookshelf2in;
    public GameObject[] goBookshelf2books;
    public GameObject goWrenchdriver0;
    public GameObject goBox4;
    public GameObject goVentilation1;
    public GameObject goVentilation1grid;
    public GameObject[] goVentilation1bolts;
    public GameObject[] goWrenchdrivers1;
    public GameObject goBureau1key20;
    public GameObject goPic1piece70;
    public GameObject goBureau1;
    public GameObject goBureau1drawer1;
    public GameObject goBureau1keyhole1;
    public GameObject goBureau1key1;
    public GameObject goPiramid30;
    public GameObject goBook1;
    public GameObject goBox3;
    public GameObject goBureau1drawer2;
    public GameObject goBureau1keyhole2;
    public GameObject goBureau1key2;
    public GameObject goScrewdriver0;
    public GameObject goPic4piece40;
    public GameObject goNote1;
    public GameObject goBureau1drawer3;
    public GameObject goPic2piece80;
    public GameObject goBureau1drawer4;
    public GameObject goCard3;
    public GameObject goSp1;
    public GameObject goSp1door;
    public GameObject[] goSp1screws;
    public GameObject[] goScrewdrivers1;
    public GameObject goSp1pin2;
    public GameObject[] goSp1cogwheels;
    public GameObject goSp2;
    public GameObject goSp2door;
    public GameObject[] goSp2screws;
    public GameObject[] goScrewdrivers2;
    public GameObject goSp2pin1;
    public GameObject[] goSp2cogwheels;
    public GameObject goPic4;
    public GameObject goPic4P;
    public GameObject[] goPic4pieces;
    public GameObject goSafe2;
    public GameObject[] goSafe2codes;
    public GameObject[] goSafe2coderolls;
    public GameObject[] goPiramids;
    public GameObject[] goNumbers;
    public GameObject goNotebook1flash0;
    public GameObject goPic2key0;
    public GameObject goPic6;
    public GameObject goBad1table2;
    public GameObject goBad1table2lamp;
    public GameObject[] goLamp2rolls;
    public GameObject goBad1table2drawer;
    public GameObject goBox2;
    public GameObject goSmallcogwheel1;
    public GameObject goChair1;
    public GameObject goBigcogwheel1;
    public GameObject goPic2;
    public GameObject goPic2in;
    public GameObject[] goPic2pieces;
    public GameObject goPic2indoor1;
    public GameObject goPic2indoor2;
    public GameObject goPic2keyhole;
    public GameObject goPic2key1;
    public GameObject goPic1;
    public GameObject goPic1btnspanel;
    public GameObject goPic1coinsocket;
    public GameObject goPic1coin1;
    public GameObject[] goPic1btns;
    public GameObject goPic1in;
    public GameObject goPic1indoor1;
    public GameObject goPic1indoor2;
    public GameObject[] goPic1pieces;
    public GameObject goPic3;
    public GameObject goPic3btnspanel;
    public GameObject goPic3coinsocket;
    public GameObject goPic3coin1;
    public GameObject[] goPic3btns;
    public GameObject goPic3in;
    public GameObject goPic3indoor1;
    public GameObject goPic3indoor2;
    public GameObject[] goPic3pieces;
    public GameObject goVentilation2;
    public GameObject goVentilation2grid;
    public GameObject[] goVentilation2bolts;
    public GameObject[] goWrenchdrivers2;
    public GameObject goPic3coin0;
    public GameObject goPic3piece90;
    public GameObject goLamp2;
    public GameObject goPaper0;
    public GameObject goTable1;
    public GameObject goNotebook1;
    public GameObject goNotebook1flash1;











    [Header("ItemFrames:")]
    public GameObject[] goItemFrames;

    [Header("Items:")]
    public GameObject[] goItems;

    [Header("Items:")]
    public GameObject goBacks;

    [Header("Materials:")]
    public Material[] mats;
    // 0 - lWhite1Mat
    // 1 - grey1Mat
    // 2 - white1Mat
    // 3 - lGreen1Mat
    // 4 - books1Mat
    // 5 - note3Mat
    // 6 - lRed1Mat

    [Header("Sounds:")]
    public AudioClip[] audioClips;
    // 0 - take1
    // 1 - doorlock1
    // 2 - draweropen1
    // 3 - lock1
    // 4 - click1
    // 5 - unlock1
    // 6 - coge1
    // 7 - dooropen1
    // 8 - key1
    // 9 - creak1
    // 10 - error1
    // 11 - unlock2

    public static Ggos g;

    private void Awake()
    {
        g = this;        
    }
}
