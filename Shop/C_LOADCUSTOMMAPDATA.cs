using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class C_LOADCUSTOMMAPDATA : MonoBehaviour {


    private int[,] m_arDefenceMapIndex;
    private List<int> m_listRoadRow;
    private List<int> m_listRoadCol;
    private List<int> m_listTowerSelected;
    private int[] m_arNodeColor;
    private int m_nBackGroundColor;
    private float m_fDiffculty;
    private int m_nStartResource;
    private int m_nStartCoinPrice;
    private int m_nSelectedTowerCount;
    private string m_strMapData;

    public GameObject m_goMapView;
    public GameObject m_goTowerView;

    private GameObject playerManager;


    // Use this for initialization
    void Start () {
        m_arNodeColor = new int[4];
        m_arDefenceMapIndex = new int[12, 12];
        playerManager = GameObject.Find("PlayerManager");

    }

    public void init(int nIndex)
    {
        /*
        FileStream fsMapData = new FileStream(Application.persistentDataPath + "/Maps/" + "CustomMap" + nIndex + ".txt", FileMode.Open, FileAccess.Read);
        StreamReader srMapData = new StreamReader(fsMapData);
        m_strMapData = srMapData.ReadToEnd();
        srMapData.Close();
        fsMapData.Close();
        */

        m_strMapData = playerManager.GetComponent<ProductManager>().products[nIndex].customMap;

        m_listRoadCol = new List<int>();
        m_listRoadRow = new List<int>();
        m_listTowerSelected = new List<int>();
    }

    public void parse()
    {
        int nOffsetIndex = 0;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 12; j++)
            {
                Debug.Log(m_strMapData[nOffsetIndex] + "----" + (m_strMapData[nOffsetIndex] - 48));
                m_arDefenceMapIndex[i, j] = m_strMapData[nOffsetIndex] - 48;
                nOffsetIndex++;
            }
            nOffsetIndex += 2;
        }

        string[] arTmpData;
        int nDataCount = 0;

        arTmpData = m_strMapData.Split('/');
        int.TryParse(arTmpData[1], out nDataCount);
        for (int i = 0; i < nDataCount; i++)
        {
            m_listRoadRow.Add(int.Parse(arTmpData[i + 2]));
        }

        arTmpData = m_strMapData.Split(',');
        int.TryParse(arTmpData[1], out nDataCount);
        for (int i = 0; i < nDataCount; i++)
        {
            m_listRoadCol.Add(int.Parse(arTmpData[i + 2]));
        }

        arTmpData = m_strMapData.Split('c');
        int.TryParse(arTmpData[1], out nDataCount);
        for (int i = 0; i < 4; i++)
        {
            m_arNodeColor[i] = int.Parse(arTmpData[i + 1]);
        }


        arTmpData = m_strMapData.Split(':');
        int.TryParse(arTmpData[1], out nDataCount);
        m_nSelectedTowerCount = nDataCount;
        for (int i = 0; i < nDataCount; i++)
        {
            m_listTowerSelected.Add(int.Parse(arTmpData[i + 2]));

        }
        arTmpData = m_strMapData.Split('c');
        m_nBackGroundColor = int.Parse(arTmpData[1]);

        arTmpData = m_strMapData.Split('.');

        m_fDiffculty = float.Parse(arTmpData[1]);
        m_nStartResource = int.Parse(arTmpData[2]);
        m_nStartCoinPrice = int.Parse(arTmpData[3]);

    }

    public void settingDetailView(int nIndex)
    {
        init(nIndex);
        parse();
        m_goMapView.GetComponent<C_DETAILMAPVIEW>().setData(gameObject.GetComponent<C_LOADCUSTOMMAPDATA>());
        m_goTowerView.GetComponent<C_DETAILTOWERSCROLLVIEWSIZE>().setData(gameObject.GetComponent<C_LOADCUSTOMMAPDATA>());
        m_goMapView.GetComponent<C_DETAILMAPVIEW>().ReturnData();
        m_goTowerView.GetComponent<C_DETAILTOWERSCROLLVIEWSIZE>().ReturnTowers();
    }


    public void settingButton(int nIndex)
    {
        init(nIndex);
        parse();
    }
    public List<int> getRoadRow()
    {
        return m_listRoadRow;
    }
    public List<int> getRoadCol()
    {
        return m_listRoadCol;
    }
    public List<int> getTowerSelected()
    {
        return m_listTowerSelected;
    }
    public int getNodeColor(int nIndex)
    {
        return m_arNodeColor[nIndex];
    }
    public int getNode(int nRow, int nCol)
    {
        return m_arDefenceMapIndex[nRow, nCol];
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
    public int getTowerCount()
    {
        return m_nSelectedTowerCount;
    }
    public string getMapStrData(){
        return m_strMapData;
    }



}
