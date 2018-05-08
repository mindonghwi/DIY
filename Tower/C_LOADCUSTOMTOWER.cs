using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class C_LOADCUSTOMTOWER : MonoBehaviour {

    private GameObject[] m_goMyTower;

    private C_LOADTOWERTEXTASSET m_cLoadTowerData;

    private uint[][] m_arNTowerData;
    private float[][] m_arFTowerData;
    [SerializeField]
    private List<int>[] m_arTmpListGradeTower;

    [SerializeField]
    private C_TOWERUPGRADE m_cTmpTowerUpgrade;

    private List<int> m_listTowerSelected;
    public enum E_LISTORDER
    {
        E_FACE = 0,
        E_WEAPON,
        E_CLOTH,
        E_HEAD,
        E_HEADMATERIAL,
        E_AURA,
        E_BULLET,
        E_STRIKING,
        E_SPEEDOFSTRIKING,
        E_TARGETCOUNT,
        E_DOWNRANGE,
        E_GRADE,
        E_MAX
    }
    public enum E_LISTTOWERNUM
    {
        E_MUSHROOM1 = 0,
        E_MUSHROOM2,
        E_MUSHROOM3,
        E_MUSHROOM4,
        E_SOLIDER1,
        E_SOLIDER2,
        E_SOLIDER3,
        E_SOLIDER4,
        E_RABBIT1,
        E_RABBIT2,
        E_RABBIT3,
        E_RABBIT4,
        E_CRIS1,
        E_CRIS2,
        E_CRIS3,
        E_CRIS4,
        E_JISUB1,
        E_JISUB2,
        E_JISUB3,
        E_JISUB4,
        E_POLICE1,
        E_POLICE2,
        E_POLICE3,
        E_POLICE4,
        E_MAX
    }


    void Start()
    {
        m_goMyTower = new GameObject[2];
        m_cLoadTowerData = new C_LOADTOWERTEXTASSET();
        m_cLoadTowerData.setTowerCount();

        m_cLoadTowerData.init();

        //0 - Nomal / 1 - Cris
        m_goMyTower[0] = (GameObject)Resources.Load("Tower/Custom/customizingTower");
        m_goMyTower[1] = (GameObject)Resources.Load("Tower/Custom/ch_10_01");


        m_arNTowerData = new uint[m_cLoadTowerData.getTowerCount()][];
        m_arFTowerData = new float[m_cLoadTowerData.getTowerCount()][];

        for (int i = 0; i < m_cLoadTowerData.getTowerCount(); i++)
        {

            m_arNTowerData[i] = new uint[(int)C_LOADTOWERDATA.E_LISTORDERINT.E_MAX];
            m_arFTowerData[i] = new float[(int)C_LOADTOWERDATA.E_LISTORDERFLOAT.E_MAX];
        }
        
        tmpFunc();

        
        m_cTmpTowerUpgrade = GameObject.Find("TowerCreater").GetComponent<C_TOWERUPGRADE>();
        m_cTmpTowerUpgrade.init(m_cLoadTowerData.getTowerCount());
        for (int i = 0; i < m_cLoadTowerData.getTowerCount(); i++)
        {
            m_cTmpTowerUpgrade.loadSecond(m_arFTowerData[i][(int)C_LOADTOWERDATA.E_LISTORDERFLOAT.E_STRIKING], i);
        }

        m_cTmpTowerUpgrade = null;


        m_arTmpListGradeTower = new List<int>[4];

        for (int i = 0; i < 4; i++)
        {

            m_arTmpListGradeTower[i] = new List<int>();
        }

        int nTowerListIndex = 0;
        

        for (int i = 0; i < m_cLoadTowerData.getTowerCount(); i++)
        {
            if (SceneManager.GetActiveScene().buildIndex == 6)
            {
                if (m_listTowerSelected.Count > nTowerListIndex && m_listTowerSelected.ToArray()[nTowerListIndex] == i)
                {
                    m_arTmpListGradeTower[(int)m_arNTowerData[i][(int)C_LOADTOWERDATA.E_LISTORDERINT.E_GRADE] - 1].Add(i);
                    nTowerListIndex++;
                }
            }
            else
            {
                m_arTmpListGradeTower[(int)m_arNTowerData[i][(int)C_LOADTOWERDATA.E_LISTORDERINT.E_GRADE] - 1].Add(i);

            }
        }
        //for (int i = 0; i < m_cLoadTowerData.getTowerCount(); i++)
        //{
        //    if (Application.loadedLevel == 5 && GameObject.Find("MapEditer"))
        //    {
        //        if (GameObject.Find("MapEditer").GetComponent<C_EDITDATA>().getListSelectedTower()[nTowerListIndex] == i)
        //        {
        //            m_arTmpListGradeTower[(int)m_arNTowerData[i][(int)C_LOADTOWERDATA.E_LISTORDERINT.E_GRADE] - 1].Add(i);
        //            nTowerListIndex++;
        //        }
        //    }
        //    else
        //    {
        //        m_arTmpListGradeTower[(int)m_arNTowerData[i][(int)C_LOADTOWERDATA.E_LISTORDERINT.E_GRADE] - 1].Add(i);

        //    }
        //}

        //for (int i = 0; i < m_cLoadTowerData.getTowerCount(); i++)
        //{
        //    m_arTmpListGradeTower[(int)m_arNTowerData[i][(int)C_LOADTOWERDATA.E_LISTORDERINT.E_GRADE] - 1].Add(i);
        //}
    }

    public void setSeletedTower(List<int> listTowerSelected)
    {
        m_listTowerSelected = new List<int>();
        m_listTowerSelected = listTowerSelected;

    }

    private void tmpFunc()
    {
        for (int i = 0; i < m_cLoadTowerData.getTowerCount(); i++)
        {
            m_cLoadTowerData.Parse();

            for (int j = 0; j < (int)C_LOADTOWERDATA.E_LISTORDERINT.E_MAX; j++)
            {
                m_arNTowerData[i][j] = (uint)m_cLoadTowerData.GetNTowerData()[j];

            }
            for (int j = 0; j < (int)C_LOADTOWERDATA.E_LISTORDERFLOAT.E_MAX; j++)
            {
                m_arFTowerData[i][j] = m_cLoadTowerData.GetFTowerData()[j];
            }
                
        }

    }




    public GameObject getCrisModel()
    {
        return m_goMyTower[1];
    }
    public GameObject getNomalModel()
    {
        return m_goMyTower[0];
    }


    public uint getWantNTowerData(int nTowerNumIndex ,C_LOADTOWERDATA.E_LISTORDERINT eListNOrder)
    {
        return m_arNTowerData[nTowerNumIndex][(int)eListNOrder];
    }
    public float getWantFTowerData(int nTowerNuIndex, C_LOADTOWERDATA.E_LISTORDERFLOAT eListFOrder)
    {
        return m_arFTowerData[nTowerNuIndex][(int)eListFOrder];
    }

    public List<int> getGardeList(int nGrade)
    {
        return m_arTmpListGradeTower[nGrade];
    }

    public int getTowerCount()
    {
        return m_cLoadTowerData.getTowerCount();
    }
    public C_TOWERUPGRADE getTowerUpgrade()
    {
        return m_cTmpTowerUpgrade;
    }
}
