using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_NOMALSTAGE : Object, C_SUPERSTAGE
{
    private GameObject[] m_arMovingPoint;
    private Transform[] m_arMovingPointTransform;
    private C_DEFENCEMAP m_cDefenceMap;
    private GameObject m_goMovingPointHolder;



    public void createStage(GameObject goMovingPoint, GameObject goGameTile, GameObject goImGameTile, C_LOADNODE cLoadNode)
    {
        C_STAGEMGR.m_eStage = C_STAGEINFO.E_STAGE.E_STAGE0;
        int nWidth = 12;
        int nHeight = 12;
        m_arMovingPoint = new GameObject[12];
        m_cDefenceMap = new C_DEFENCEMAP();
        m_arMovingPointTransform = new Transform[12];

        m_cDefenceMap.init(cLoadNode);
        m_cDefenceMap.createMap(nWidth, nHeight);

        Vector3 vUp = new Vector3(0.0f, 1.0f, 0.0f);

        m_arMovingPoint[0] = (GameObject)Instantiate(goMovingPoint, m_cDefenceMap.getTilePoint(0, 0).transform.position + vUp, Quaternion.identity);
        m_arMovingPoint[1] = (GameObject)Instantiate(goMovingPoint, m_cDefenceMap.getTilePoint(0, 4).transform.position + vUp, Quaternion.identity);
        m_arMovingPoint[2] = (GameObject)Instantiate(goMovingPoint, m_cDefenceMap.getTilePoint(nWidth - 1, 4).transform.position + vUp, Quaternion.identity);
        m_arMovingPoint[3] = (GameObject)Instantiate(goMovingPoint, m_cDefenceMap.getTilePoint(nWidth - 1, 0).transform.position + vUp, Quaternion.identity);

        m_arMovingPoint[4] = (GameObject)Instantiate(goMovingPoint, m_cDefenceMap.getTilePoint(nWidth - 5, 0).transform.position + vUp, Quaternion.identity);
        m_arMovingPoint[5] = (GameObject)Instantiate(goMovingPoint, m_cDefenceMap.getTilePoint(nWidth - 5, nHeight-1).transform.position + vUp, Quaternion.identity);
        m_arMovingPoint[6] = (GameObject)Instantiate(goMovingPoint, m_cDefenceMap.getTilePoint(nWidth - 1, nHeight - 1).transform.position + vUp, Quaternion.identity);
        m_arMovingPoint[7] = (GameObject)Instantiate(goMovingPoint, m_cDefenceMap.getTilePoint(nWidth - 1, nHeight - 5).transform.position + vUp, Quaternion.identity);

        m_arMovingPoint[8] = (GameObject)Instantiate(goMovingPoint, m_cDefenceMap.getTilePoint(0, nHeight - 5).transform.position + vUp, Quaternion.identity);
        m_arMovingPoint[9] = (GameObject)Instantiate(goMovingPoint, m_cDefenceMap.getTilePoint(0, nHeight - 1).transform.position + vUp, Quaternion.identity);
        m_arMovingPoint[10] = (GameObject)Instantiate(goMovingPoint, m_cDefenceMap.getTilePoint(4, nHeight - 1).transform.position + vUp, Quaternion.identity);
        m_arMovingPoint[11] = (GameObject)Instantiate(goMovingPoint, m_cDefenceMap.getTilePoint(4, 0).transform.position + vUp, Quaternion.identity);



        m_goMovingPointHolder = new GameObject();
        m_goMovingPointHolder.transform.position = new Vector3(11.0f, 0.0f, 11.0f);
        m_goMovingPointHolder.name = "MovingPoints";
        m_goMovingPointHolder.tag = "MovingPoints";
        for (int i = 0; i < m_arMovingPoint.Length; i++)
        {
            m_arMovingPoint[i].name = "MovingPoint" + i;
            m_arMovingPoint[i].transform.parent = m_goMovingPointHolder.transform;
            m_arMovingPointTransform[i] = m_arMovingPoint[i].transform;
        }
    }
    public C_DEFENCEMAP getDefenceMap()
    {
        return m_cDefenceMap;
    }
    public Transform[] getMovingPoint()
    {
        return m_arMovingPointTransform;
    }
    public GameObject getWavePoint()
    {
        return m_arMovingPoint[0];
    }
}
