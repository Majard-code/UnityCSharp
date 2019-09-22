using UnityEngine;
using UnityEngine.UI;


public class Gprint : MonoBehaviour
{
    public static int count = 0;

    public static void p(string ps)
    {
        ps += "\n";
        Ggos.g.goDebText.GetComponent<Text>().text += ps;
        count++;
        if (count == 18)
        {
            count = 0;
            Ggos.g.goDebText.GetComponent<Text>().text = ps;
        }
    }

}
