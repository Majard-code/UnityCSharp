using UnityEngine;

public class Code10Touch : MonoBehaviour
{
    public int btnID;
    public static Material[] matBuff;

    private void OnMouseUpAsButton()
    {
        if (Gcam.touchable)
        {
            Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[3]);
            matBuff = GetComponent<MeshRenderer>().materials;
            matBuff[0] = Ggos.g.mats[0];
            GetComponent<MeshRenderer>().materials = matBuff;
            GetComponent<BoxCollider>().enabled = false;
            Codes.codeReal[10][Codes.picPointer[10]] = btnID;
            Debug.Log(Codes.codeReal[10][0].ToString() + " * " + Codes.codeReal[10][1].ToString() + " * " + Codes.codeReal[10][2].ToString() + " * " + Codes.codeReal[10][3].ToString() + " * " + Codes.codeReal[10][4].ToString() + " * " + Codes.codeReal[10][5].ToString() + " * " + Codes.codeReal[10][6].ToString() + " * " + Codes.codeReal[10][7].ToString() + " * " + Codes.codeReal[10][8].ToString());
            if (Codes.picPointer[10] == 8)
            {
                Codes.CheckCode(10);
            }
            else
            {
                Codes.picPointer[10]++;
            }
        }
    }
}
