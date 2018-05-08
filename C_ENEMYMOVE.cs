using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_ENEMYMOVE {
    public int MoveNomal(GameObject goMovingCharecter, Transform[] arTargetTranforms, float fMovingSpeed, int nTargetIndex,C_PLAYER cPlayer)
    {
        Vector3 vecDir = goMovingCharecter.transform.position - arTargetTranforms[nTargetIndex].position;
        goMovingCharecter.transform.Translate(vecDir.normalized * -fMovingSpeed/1.5f * Time.deltaTime, Space.World);
        goMovingCharecter.transform.LookAt(arTargetTranforms[nTargetIndex]);

        if (Vector3.Distance(goMovingCharecter.transform.position, arTargetTranforms[nTargetIndex].position) <= 0.4f)
        {
            if (nTargetIndex < arTargetTranforms.Length - 1)
            {
                goMovingCharecter.transform.position = arTargetTranforms[nTargetIndex].position;
            }

            nTargetIndex++;
        }

        return nTargetIndex;
    }
    public void MoveStage0(GameObject goMovingCharecter, Transform[] arTargetTranforms, float fMovingSpeed)
    {
        int nTargetIndex = 1;
        Vector3 vecDir = goMovingCharecter.transform.position - arTargetTranforms[nTargetIndex].position;
        goMovingCharecter.transform.Translate(vecDir.normalized * fMovingSpeed * Time.deltaTime, Space.World);
        goMovingCharecter.transform.LookAt(arTargetTranforms[nTargetIndex]);

        if (Vector3.Distance(goMovingCharecter.transform.position, arTargetTranforms[nTargetIndex].position) <= 0.2f)
        {
            if (nTargetIndex < arTargetTranforms.Length - 1)
                nTargetIndex++;
            else
                nTargetIndex = 0;
        }
    }
}
