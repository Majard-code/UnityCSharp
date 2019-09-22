using UnityEngine;

public class Code5Touch : MonoBehaviour
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
            Codes.codeReal[5][rollID]++;

            matBuff = GetComponent<MeshRenderer>().materials;
            matBuff[Codes.codeReal[5][rollID]] = Ggos.g.mats[2];
            GetComponent<MeshRenderer>().materials = matBuff;

            Ggos.g.goMainCamera.GetComponent<AudioSource>().PlayOneShot(Ggos.g.audioClips[3]);
            rollTarget.z = Codes.codeReal[5][rollID] * 45f;
            rolling = true;
        }
    }

    private void FixedUpdate()
    {
        if (rolling)
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(rollTarget), Time.deltaTime * 20f);

            if (transform.localRotation == Quaternion.Euler(rollTarget))
            {
                Gcam.touchable = true;
                if (Codes.codeReal[5][rollID] == 8)
                {
                    Codes.codeReal[5][rollID] = 0;
                    rollTarget.z = 0;
                    transform.localRotation = Quaternion.Euler(rollTarget);
                }

                matBuff[Codes.codeReal[5][rollID] + 1] = Ggos.g.mats[0];
                GetComponent<MeshRenderer>().materials = matBuff;

                Debug.Log(Codes.codeReal[5][0].ToString() + " * " + Codes.codeReal[5][1].ToString() + " * " + Codes.codeReal[5][2].ToString() + " * " + Codes.codeReal[5][3].ToString());
                Codes.CheckCode(5);

                rolling = false;
            }
        }
    }
}
