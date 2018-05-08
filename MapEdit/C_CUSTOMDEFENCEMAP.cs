using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_CUSTOMDEFENCEMAP : Object {

    private GameObject[,] m_arMarsMap;
    private GameObject m_goMarsMapHolder;
    private C_LOADNODE m_cLoadNode;
    private int[,] m_arDefenceMapIndex;
    private C_MAPNODEDATA m_cMapNodeData;
    private int nNodeData;
    private List<int> m_listRoadRow;
    private List<int> m_listRoadCol;

    private int[] m_arNodeColor;

    public void init(C_LOADNODE cLoadNode)
    {
        m_goMarsMapHolder = new GameObject();
        m_cLoadNode = cLoadNode;
        m_arDefenceMapIndex = new int[12,12];
        m_cMapNodeData = new C_MAPNODEDATA();
        m_cMapNodeData.init();
        m_cMapNodeData.Parse(m_arDefenceMapIndex);
        m_cMapNodeData.release();
        nNodeData = 0;
        m_goMarsMapHolder.name = "MarsMaps";
        m_arMarsMap = new GameObject[12, 12];

        m_listRoadRow = new List<int>();
        m_listRoadCol = new List<int>();
        m_arNodeColor = new int[4];
    }

    public void changeMapData()
    {
        string strMapData = "";
        strMapData = PlayerPrefs.GetString("Maps");
        int nOffsetIndex = 0;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 12; j++)
            {
                m_arDefenceMapIndex[i, j] = strMapData[nOffsetIndex] - 48;
                nOffsetIndex++;
            }
            nOffsetIndex += 2;
        }
    }

    public void createMap(int nWidth, int nHeight)
    {
        GameObject goTmpTile = null;
        Vector3 vecMapPosition = new Vector3(0.0f, 0.0f, 0.0f);
        float fMapScale = 2.0f;
        int nCount = 1;

        for (int i = 0; i < nWidth; i++)
        {
            for (int j = 0; j < nHeight; j++)
            {
                vecMapPosition = new Vector3((float)i * fMapScale, 0.0f, (float)j * fMapScale);

                if (m_arDefenceMapIndex[i,j] < 2)
                {
                    goTmpTile = Instantiate(m_cLoadNode.getImpossibleNode(m_arDefenceMapIndex[i, j]), vecMapPosition, Quaternion.identity);
                }
                else
                {
                    goTmpTile = Instantiate(m_cLoadNode.getPossibleNode(m_arDefenceMapIndex[i, j] - 2), vecMapPosition, Quaternion.identity);
                }
                m_arMarsMap[i, j] = goTmpTile;
                m_arMarsMap[i, j].name = "Tile" + nCount;
                m_arMarsMap[i, j].transform.parent = m_goMarsMapHolder.transform;
                nCount++;
            }
        }
    }

    public void mapEditNode()
    {
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 12; j++)
            {
                Destroy(m_arMarsMap[i, j].GetComponent<C_NODE>());
                m_arMarsMap[i, j].AddComponent<C_ROADEDIT>();
                m_arMarsMap[i, j].GetComponent<C_ROADEDIT>().setNodeIndex(i, j);
            }
        }
        
    }

    public void changeNode(RaycastHit hit)
    {
        Vector3 vecTmpPos = hit.transform.position;
        C_ROADEDIT cTmpRoadEdit = hit.transform.GetComponent<C_ROADEDIT>();

        if (m_arDefenceMapIndex[cTmpRoadEdit.getNodeIndex()[0], cTmpRoadEdit.getNodeIndex()[1]] >= 2)
        {
            m_arDefenceMapIndex[cTmpRoadEdit.getNodeIndex()[0], cTmpRoadEdit.getNodeIndex()[1]] = nNodeData;
        }
        else
        {
            m_arDefenceMapIndex[cTmpRoadEdit.getNodeIndex()[0], cTmpRoadEdit.getNodeIndex()[1]] = nNodeData + 2;
        }

        if (nNodeData == 1)
        {
            nNodeData = 0;
        }
        else
        {
            nNodeData = 1;
        }
        Destroy(m_arMarsMap[cTmpRoadEdit.getNodeIndex()[0], cTmpRoadEdit.getNodeIndex()[1]]);

        if (m_arDefenceMapIndex[cTmpRoadEdit.getNodeIndex()[0], cTmpRoadEdit.getNodeIndex()[1]] < 2)
        {
            m_arMarsMap[cTmpRoadEdit.getNodeIndex()[0], cTmpRoadEdit.getNodeIndex()[1]] =
                Instantiate(m_cLoadNode.getImpossibleNode(m_arDefenceMapIndex[cTmpRoadEdit.getNodeIndex()[0], cTmpRoadEdit.getNodeIndex()[1]])
                , vecTmpPos, Quaternion.identity);
        }
        else
        {
            m_arMarsMap[cTmpRoadEdit.getNodeIndex()[0], cTmpRoadEdit.getNodeIndex()[1]] =
                Instantiate(m_cLoadNode.getPossibleNode(m_arDefenceMapIndex[cTmpRoadEdit.getNodeIndex()[0], cTmpRoadEdit.getNodeIndex()[1]] - 2)
                , vecTmpPos, Quaternion.identity);
        }

        m_arMarsMap[cTmpRoadEdit.getNodeIndex()[0], cTmpRoadEdit.getNodeIndex()[1]].AddComponent<C_ROADEDIT>();
        m_arMarsMap[cTmpRoadEdit.getNodeIndex()[0], cTmpRoadEdit.getNodeIndex()[1]].GetComponent<C_ROADEDIT>().setNodeIndex(cTmpRoadEdit.getNodeIndex()[0], cTmpRoadEdit.getNodeIndex()[1]);
        m_arMarsMap[cTmpRoadEdit.getNodeIndex()[0], cTmpRoadEdit.getNodeIndex()[1]].transform.parent = m_goMarsMapHolder.transform;

        m_listRoadRow.Add(cTmpRoadEdit.getNodeIndex()[0]);
        m_listRoadCol.Add(cTmpRoadEdit.getNodeIndex()[1]);

    }

    public void removeFloor()
    {
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 12; j++)
            {
                Destroy(m_arMarsMap[i,j]);
            }
        }
        m_cMapNodeData.init();
        m_cMapNodeData.Parse(m_arDefenceMapIndex);
        m_cMapNodeData.release();
        m_listRoadCol.RemoveRange(0,m_listRoadCol.Count);
        m_listRoadRow.RemoveRange(0, m_listRoadRow.Count);
    }


    public GameObject getTilePoint(int nRow, int nCol)
    {
        return m_arMarsMap[nRow, nCol];
    }

    public void DebugInt()
    {
        for (int i = 0; i < m_listRoadCol.Count; i++)
        {
      
                Debug.Log(m_listRoadRow[i] +","+ m_listRoadCol[i] + "======" +m_arDefenceMapIndex[m_listRoadRow[i], m_listRoadCol[i]]);
            
        }

        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 12; j++)
            {
                Debug.Log(m_arDefenceMapIndex[i, j]);
            }
        }

    }

    public List<int> getRoadRow()
    {
        return m_listRoadRow;
    }
    public List<int> getRoadCol()
    {
        return m_listRoadCol;
    }

    public string getMapNodeData()
    {
        string strMap = "";
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 12; j++)
            {
                strMap += m_arDefenceMapIndex[i, j].ToString();
                
            }
            strMap += "mr";
        }

        return strMap;
    }

    public void hideMapHolder()
    {
        m_goMarsMapHolder.SetActive(false);
    }
    public void onMapHolder()
    {
        m_goMarsMapHolder.SetActive(true);
    }

    public void setColors(int[] arNodeColor)
    {
        for (int i = 0; i < 4; i++)
        {
            m_arNodeColor[i] = arNodeColor[i];
        }
    }
    private Color32 intChangeColor(int nIndex)
    {
        Color32 colorData = new Color32();

        colorData.a = (byte)((nIndex) & 0xFF);
        colorData.b = (byte)((nIndex >> 8) & 0xFF);
        colorData.g = (byte)((nIndex >> 16) & 0xFF);
        colorData.r = (byte)((nIndex >> 24) & 0xFF);

        return colorData;

    }

}
