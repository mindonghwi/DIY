using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_MAPEDITMR : MonoBehaviour {

    private C_LOADNODE m_cLoadNode;
    private GameObject m_goNode;
    [SerializeField]
    private int[] m_arNodeColor;
    private int m_nNodeIndex;
    private int m_nBackgroundColor;
    [SerializeField]
    private bool[] m_arSelectedTower;
    private MapEdit.C_TOWERSELECT m_cTowerSelect;
    private GameObject m_goTower;
    private C_CUSTOMDEFENCEMAP m_cDefenceMap;


    private bool m_bStart;
    private bool m_bRoadBuilding;
    private bool m_bFloorEdit;
    // Use this for initialization
    void Start() {
        m_cLoadNode = new C_LOADNODE();
        m_cLoadNode.load();
        m_arNodeColor = new int[4];
        m_goNode = null;

        m_goTower = new GameObject();
        m_goTower.name = "TowerHolder";

        for (int i = 0; i < 4; i++)
        {
            if (i < 2)
            {
                m_arNodeColor[i] = colorChangeInt(m_cLoadNode.getImpossibleNode(i).GetComponent<Renderer>().sharedMaterial.color);
            }
            else
            {
                m_arNodeColor[i] = colorChangeInt(m_cLoadNode.getPossibleNode(i - 2).GetComponent<Renderer>().sharedMaterial.color);
            }
        }

        m_nNodeIndex = 0;
        m_nBackgroundColor = 827160832;
        m_cTowerSelect = gameObject.GetComponent<MapEdit.C_TOWERSELECT>();

        m_cDefenceMap = new C_CUSTOMDEFENCEMAP();
        m_cDefenceMap.init(m_cLoadNode);

        m_bStart = false;
        m_bRoadBuilding = false;
        m_bFloorEdit = false;
    }


	public void setBool(int nIndex)
    {
        m_arSelectedTower = new bool[nIndex];

    }

    public void createNode(int nIndex)
    {
        if (m_goNode)
        {
            Destroy(m_goNode);
            m_goNode = null;
        }
        if (m_goTower.transform.childCount > 0)
        {
            Destroy(m_goTower.transform.GetChild(0).gameObject);
        }

        if (nIndex <2)
        {
            m_goNode = Instantiate(m_cLoadNode.getImpossibleNode(nIndex), new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
        }
        else
        {
            m_goNode = Instantiate(m_cLoadNode.getPossibleNode(nIndex-2), new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
        }
    }

    public void selectNodeColor(int nColor, int nIndex)
    {
        if (m_goNode)
        {
            m_goNode.GetComponent<Renderer>().material.color = intChangeColor(nColor);
        }
        m_arNodeColor[nIndex] = nColor;
        Debug.Log(m_arNodeColor[nIndex]);
    }

    public void selectBackGroudColor(int nColor)
    {
        Camera.main.backgroundColor = intChangeColor(nColor);
        m_nBackgroundColor = nColor;
    }

    public void selectInputTower(int nIndex)
    {
        if (m_arSelectedTower[nIndex])
        {
            m_arSelectedTower[nIndex] = false;
        }
        else
        {
            m_arSelectedTower[nIndex] = true;
        }


        if (m_goNode)
        {
            Destroy(m_goNode);
            m_goNode = null;
        }
        if (m_goTower.transform.childCount > 0)
        {
            Destroy(m_goTower.transform.GetChild(0).gameObject);
        }

        m_cTowerSelect.CreateTower(m_goTower, nIndex);
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
    private int colorChangeInt(Color32 colorData)
    {
        int nColor = 0;

        nColor = (int)((colorData.r << 24) | (colorData.g << 16) |
                     (colorData.b << 8) | (colorData.a << 0));


        return nColor;
    }



    public int getNodeIndex()
    {
        return m_nNodeIndex;
    }

    public void setNodeIndex(int nNum)
    {
        m_nNodeIndex = nNum;
    }

    public void release()
    {
        m_cLoadNode = null;

        m_goNode = null;
        m_cTowerSelect = null;
    }

    public void removeFloor()
    {
        if (m_bFloorEdit)
        {
            m_cDefenceMap.hideMapHolder();
            m_bFloorEdit = false;
        }
    }

    public void startFloor()
    {
        m_bStart = true;
    }

    public void returnFloor()
    {
        m_cDefenceMap.removeFloor();
        m_cDefenceMap.createMap(12, 12);
        m_cDefenceMap.mapEditNode();
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            if (m_bRoadBuilding && hit.transform.GetComponent<C_ROADEDIT>())
            {
                m_cDefenceMap.changeNode(hit);
            }
            if (m_bStart &&Input.GetMouseButtonDown(0) && hit.transform.GetComponent<C_ROADEDIT>())
            {
                m_cDefenceMap.changeNode(hit);
                m_bRoadBuilding = true;
                m_bStart = false;
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(1);
            m_bRoadBuilding = false;
        }
    }

    public void Hat()
    {
        m_cDefenceMap.DebugInt();
    }

    public void setFloor()
    {
        if (m_goNode)
        {
            Destroy(m_goNode);
            m_goNode = null;
        }
        if (m_goTower.transform.childCount > 0)
        {
            Destroy(m_goTower.transform.GetChild(0).gameObject);
        }
        m_cDefenceMap.onMapHolder();
        m_bFloorEdit = true;
        m_cDefenceMap.createMap(12, 12);
        m_cDefenceMap.mapEditNode();
    }


    public void passingTowerId( List<int> listSeletedTowerId)
    {

        for (int i = 0; i < m_arSelectedTower.Length; i++)
        {
            if (m_arSelectedTower[i])
            {
                listSeletedTowerId.Add(i);
            }
        }

    }
    public string passingMapData()
    {
        return m_cDefenceMap.getMapNodeData();
    }
    public C_CUSTOMDEFENCEMAP getDefenceMap()
    {
        return m_cDefenceMap;
    }
    public int getBackGroundColor()
    {
        return m_nBackgroundColor;
    }
    public int[] getNodeColor()
    {
        return m_arNodeColor;
    }
}
