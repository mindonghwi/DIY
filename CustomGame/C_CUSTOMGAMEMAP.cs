using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class C_CUSTOMGAMEMAP : Object {
    private GameObject[,] m_arMarsMap;
    private GameObject m_goMarsMapHolder;
    private C_LOADNODE m_cLoadNode;
    private int[,] m_arDefenceMapIndex;
    private List<int> m_listRoadRow;
    private List<int> m_listRoadCol;

    private int[] m_arNodeColor;


    private List<int> m_listTowerSelected;
    private float m_fDiffculty;
    private int m_nStartCoinPrice;
    private int m_nStartResource;


    public void init(C_LOADNODE cLoadNode,int nIndex)
    {
        m_goMarsMapHolder = new GameObject();
        m_cLoadNode = cLoadNode;
        m_arDefenceMapIndex = new int[12, 12];
        m_goMarsMapHolder.name = "MarsMaps";
        m_goMarsMapHolder.transform.position = new Vector3(11.0f, 0.0f, 11.0f);

        m_arMarsMap = new GameObject[12, 12];

        m_listRoadRow = new List<int>();
        m_listRoadCol = new List<int>();
        m_arNodeColor = new int[4];
        m_listTowerSelected = new List<int>();

        setMapData(nIndex);
    }

    private void setMapData(int nIndex)
    {
        FileStream fsMapData = new FileStream(Application.persistentDataPath + "/Maps/" + "CustomMap" + nIndex + ".txt", FileMode.Open, FileAccess.Read);
        StreamReader srMapData = new StreamReader(fsMapData);
        string strMapData = srMapData.ReadToEnd();
        srMapData.Close();
        fsMapData.Close();

        int nOffsetIndex = 0;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 12; j++)
            {
                Debug.Log(strMapData[nOffsetIndex] + "----" + (strMapData[nOffsetIndex] - 48));
                m_arDefenceMapIndex[i, j] = strMapData[nOffsetIndex] - 48;
                nOffsetIndex++;
            }
            nOffsetIndex+=2;
        }

        string[] arTmpData;
        int nDataCount = 0;

        arTmpData = strMapData.Split('/');
        int.TryParse(arTmpData[1],out nDataCount);
        for (int i = 0; i < nDataCount; i++)
        {
            m_listRoadRow.Add(int.Parse(arTmpData[i+2]));
        }

        arTmpData = strMapData.Split(',');
        int.TryParse(arTmpData[1], out nDataCount);
        for (int i = 0; i < nDataCount; i++)
        {
            m_listRoadCol.Add(int.Parse(arTmpData[i + 2]));
        }

        arTmpData = strMapData.Split('c');
        int.TryParse(arTmpData[1], out nDataCount);
        for (int i = 0; i < 4; i++)
        {
            m_arNodeColor[i] = int.Parse(arTmpData[i + 1]);
        }
        Debug.Log("Color :" + m_arNodeColor[0]);


        arTmpData = strMapData.Split(':');
        int.TryParse(arTmpData[1], out nDataCount);
        for (int i = 0; i < nDataCount; i++)
        {
            m_listTowerSelected.Add(int.Parse(arTmpData[i + 2]));
            Debug.Log("Tower :" + m_listTowerSelected[i]);

        }
        arTmpData = strMapData.Split('c');
        Camera.main.backgroundColor = intChangeColor(int.Parse(arTmpData[1]));

        arTmpData = strMapData.Split('.');

        m_fDiffculty = float.Parse(arTmpData[1]);
        Debug.Log(m_fDiffculty);
        m_nStartResource = int.Parse(arTmpData[2]);
        m_nStartCoinPrice = int.Parse(arTmpData[3]);
        
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

                if (m_arDefenceMapIndex[i, j] < 2)
                {
                    goTmpTile = Instantiate(m_cLoadNode.getImpossibleNode(m_arDefenceMapIndex[i, j]), vecMapPosition, Quaternion.identity);
                }
                else
                {
                    goTmpTile = Instantiate(m_cLoadNode.getPossibleNode(m_arDefenceMapIndex[i, j] - 2), vecMapPosition, Quaternion.identity);
                }
                goTmpTile.GetComponent<Renderer>().material.color = intChangeColor(m_arNodeColor[m_arDefenceMapIndex[i, j]]);
                m_arMarsMap[i, j] = goTmpTile;
                m_arMarsMap[i, j].name = "Tile" + nCount;
                m_arMarsMap[i, j].transform.parent = m_goMarsMapHolder.transform;
                nCount++;
            }
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
    public List<int> getRoadRow() {
        return m_listRoadRow;
    }
    public List<int> getRoadCol()
    {
        return m_listRoadCol;
    }
    public GameObject getNode(int nRow,int nCol)
    {
        return m_arMarsMap[nRow, nCol];
    }

    public float getDiffculty()
    {
        return m_fDiffculty;
    }
    public int getStartResource()
    {
        return m_nStartResource;
    }
    public int getStartCoinPrice()
    {
        return m_nStartCoinPrice;
    }
    public List<int> getTowers()
    {
        return m_listTowerSelected;
    }
}
