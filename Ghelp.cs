using UnityEngine;
using UnityEngine.UI;

public class Ghelp : MonoBehaviour
{
    public static int helpPoints = 0;


    public static void RefreshCount()
    {
        Ggos.g.goHelpCount.GetComponent<Text>().text = helpPoints.ToString();
    }
}
