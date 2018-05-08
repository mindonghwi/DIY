using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_LOADTOWERTEXTASSET : Object
{

    [SerializeField]
    private TextAsset m_txtaTowerData;
    [SerializeField]
    private string m_strTowerData;
    private uint[] m_arListOrderIntData = new uint[(int)E_LISTORDERINT.E_MAX];
    private float[] m_arListOrderFloatData = new float[(int)E_LISTORDERFLOAT.E_MAX];

    private int m_nTowerCount;
    private int nParseDataIndex = 0;

    private GameObject playerManager;

    public enum E_LISTORDERINT
    {
        E_ID = 0,
        E_FACE,
        E_WEAPON,
        E_CLOTH,
        E_HEAD,
        E_HEADMATERIAL,
        E_AURA,
        E_BULLET,
        E_TARGETCOUNT,
        E_GRADE,
        E_HAIRCOLOR,
        E_BULLETCOLOR,
        E_MAX
    }
    public enum E_LISTORDERFLOAT
    {
        E_STRIKING,
        E_SPEEDOFSTRIKING,
        E_DOWNRANGE,
        E_MAX
    }
    // Use this for initialization
    public void init()
    {
        playerManager = GameObject.Find("PlayerManager");

        m_strTowerData = "";
        /*
        string strpath = "TowerTableData.txt";
        m_txtaTowerData = (TextAsset)Resources.Load("TowerTableData");
        m_strTowerData = m_txtaTowerData.text;
        */
        m_strTowerData = playerManager.GetComponent<ProductManager>().FullTower;
        Debug.Log(m_strTowerData);

    }

    public void setTowerCount()
    {
        m_nTowerCount = 0;
        init();
        //int nIndex = 0;

        //while (nIndex < m_strTowerData.Length)
        //{
        //    m_nTowerCount++;
        //    nIndex += 55;

        //}
        //m_nTowerCount--;
        m_nTowerCount = playerManager.GetComponent<ProductManager>().towers.Count;
        Debug.Log("TowerCount" + m_nTowerCount);
    }

    public void Parse()
    {

        char[] arReadData = new char[10];
        int[] arReadBufferCount = { 2, 1, 1, 2, 1, 2, 1, 1, 1, 1, 10, 1, 6, 4, 4 };
        m_arListOrderIntData = new uint[(int)E_LISTORDERINT.E_MAX];
        m_arListOrderFloatData = new float[(int)E_LISTORDERFLOAT.E_MAX];

        string[] arParseData;
        arParseData = m_strTowerData.Split('/');



        int nBufferIndex = 0;
        for (int i = 0; i < (int)E_LISTORDERINT.E_MAX; i++)
        {
            arReadData = arParseData[nParseDataIndex].ToCharArray();
            if (nParseDataIndex % 15 == 0)
            {
                m_arListOrderIntData[i] = (uint)changeCharToInt(arReadData, arReadBufferCount[nBufferIndex]);
            }

            m_arListOrderIntData[i] = (uint)changeCharToInt(arReadData, arReadBufferCount[nBufferIndex]);
            nBufferIndex++;
            nParseDataIndex++;
            Debug.Log(i + "-------" + m_arListOrderIntData[i]);
        }


        for (int i = 12; i < 12 + (int)E_LISTORDERFLOAT.E_MAX; i++)
        {
            arReadData = arParseData[nParseDataIndex].ToCharArray();

            m_arListOrderFloatData[i - 12] = changeCharToFloat(arReadData, arReadBufferCount[nBufferIndex]);
            nBufferIndex++;
            nParseDataIndex++;
            Debug.Log(i + "-------" + m_arListOrderFloatData[i - 12]);
        }
        nParseDataIndex++;
    }



    private int changeCharToInt(char[] arReadData, int nBufferSize)
    {
        int nData = 0;
        int nChpher = nBufferSize - 1;


        for (int i = 0; i < nBufferSize; i++)
        {
            nData += (arReadData[i] - 48) * (int)(Mathf.Pow(10.0f, (float)nChpher));
            nChpher -= 1;
        }

        return nData;
    }

    private float changeCharToFloat(char[] arReadData, int nBufferSize)
    {
        float fData = 0.0f;

        string strTmp = new string(arReadData, 0, nBufferSize);

        float.TryParse(strTmp, out fData);


        return fData;
    }

    public uint[] GetNTowerData()
    {
        return m_arListOrderIntData;
    }
    public float[] GetFTowerData()
    {
        return m_arListOrderFloatData;
    }

    public int getTowerCount()
    {
        return m_nTowerCount;
    }

    void Start()
    {
        init();
        setTowerCount();
        Parse();
    }
}
