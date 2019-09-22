using UnityEngine;

public class Code6Touch : MonoBehaviour
{
    public int rollID;
    private bool rolling = false;
    private Material[] matBuff;

    private Vector3 rollTarget = new Vector3(0f, 0f, 0f);

    private void OnMouseUpAsButton()
    {
        if (Gcam.touchable)
        {
            Gcam.touchable = false;
            Codes.codeReal[6][rollID]++;

            matBuff = GetComponent<MeshRenderer>().materials;
            matBuff[Codes.codeReal[6][rollID]] = Ggos.g.mats[2];
            GetComponent<MeshRenderer>().materials = matBuff;

            Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[3]);
            rollTarget.y = Codes.codeReal[6][rollID] * 60f;
            rolling = true;
        }
    }

    private void FixedUpdate()
    {
        if (rolling)
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(rollTarget), Time.deltaTime * 30f);

            if (transform.localRotation == Quaternion.Euler(rollTarget))
            {
                if (Codes.codeReal[6][rollID] == 6)
                {
                    Codes.codeReal[6][rollID] = 0;
                    rollTarget.y = 0;
                    transform.localRotation = Quaternion.Euler(rollTarget);
                }
                Gcam.touchable = true;

                matBuff[Codes.codeReal[6][rollID] + 1] = Ggos.g.mats[0];
                GetComponent<MeshRenderer>().materials = matBuff;

                Debug.Log(Codes.codeReal[6][0].ToString() + " * " + Codes.codeReal[6][1].ToString() + " * " + Codes.codeReal[6][2].ToString() + " * " + Codes.codeReal[6][3].ToString());
                Codes.CheckCode(6);


                rolling = false;
            }
        }
    }
}
