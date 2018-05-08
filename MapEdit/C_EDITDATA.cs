using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;
using UserManager;

public class C_EDITDATA : MonoBehaviour {

    private C_MAPEDITMR m_cMapEditer;

    [SerializeField]
    private string m_strMapData;
    [SerializeField]
    private List<int> m_listRoadRow;
    [SerializeField]
    private List<int> m_listRoadCol;
    [SerializeField]
    private int[] m_arNodeColor;
    [SerializeField]
    private int m_nBackGroundColor;
    [SerializeField]
    private List<int> m_listSelectedTower;

    private float[] m_arDifficultySettingValue;
    private int[] m_arStartResourceSettingValue;
    private int[] m_arStartCoinPriceSettingValue;


    [SerializeField]
    private Dropdown m_ddDifficulty;
    private Dropdown m_ddStartResource;
    private Dropdown m_ddStartCoinPrice;

    private float m_fDifficulty;
    private int m_nStartResource;
    private int m_nStartCoinPrice;

    private GameObject playerManager;
    private string url;

    // Use this for initialization
    void Start()
    {
        m_cMapEditer = gameObject.GetComponent<C_MAPEDITMR>();
        playerManager = GameObject.Find("PlayerManager");

        url = playerManager.GetComponent<PlayerManager>().url;

        m_ddDifficulty = GameObject.Find("MainCanvas").transform.GetChild(5).GetChild(1).GetChild(0).GetChild(1).GetComponent<Dropdown>();
        m_ddStartResource = GameObject.Find("MainCanvas").transform.GetChild(5).GetChild(1).GetChild(1).GetChild(1).GetComponent<Dropdown>();
        m_ddStartCoinPrice = GameObject.Find("MainCanvas").transform.GetChild(5).GetChild(1).GetChild(2).GetChild(1).GetComponent<Dropdown>();

        m_strMapData = "";
        m_listSelectedTower = new List<int>();
        m_arNodeColor = new int[4];
        m_listRoadCol = new List<int>();
        m_listRoadRow = new List<int>();
        init();
    }


    private void init()
    {
        m_arDifficultySettingValue = new float[3];
        m_arStartCoinPriceSettingValue = new int[3];
        m_arStartResourceSettingValue = new int[3];

        int nTmpCoinPrice = 200;
        int nTmpStartResource = 300;
        for (int i = 0; i < 3; i++)
        {
            m_arDifficultySettingValue[i] = (float)(i + 1);
            m_arStartCoinPriceSettingValue[i] = nTmpCoinPrice;
            m_arStartResourceSettingValue[i] = nTmpStartResource;

            nTmpCoinPrice += 300;
            nTmpStartResource += 500;
        }
    }
    public void setMapData()
    {
        m_cMapEditer.passingTowerId(m_listSelectedTower);
        m_strMapData = m_cMapEditer.passingMapData();
        m_arNodeColor = m_cMapEditer.getNodeColor();
        m_nBackGroundColor = m_cMapEditer.getBackGroundColor();

        for (int i = 0; i < m_cMapEditer.getDefenceMap().getRoadCol().Count; i++)
        {
            m_listRoadCol.Add(m_cMapEditer.getDefenceMap().getRoadCol()[i]);
            m_listRoadRow.Add(m_cMapEditer.getDefenceMap().getRoadRow()[i]);
        }
        Debug.Log(m_strMapData);
        m_fDifficulty = m_arDifficultySettingValue[m_ddDifficulty.value];
        m_nStartCoinPrice = m_arStartCoinPriceSettingValue[m_ddStartCoinPrice.value];
        m_nStartResource =  m_arStartResourceSettingValue[m_ddStartResource.value];

        for (int i = 0; i < 4; i++)
        {
            PlayerPrefs.SetInt("NodeColor" + i, m_arNodeColor[i]);
        }
        int nTowerCount = 0;
        for (int i = 0; i < m_listSelectedTower.ToArray().Length; i++)
        {
            PlayerPrefs.SetInt("SelectedTower"+i, m_listSelectedTower[i]);
            nTowerCount++;
        }
        PlayerPrefs.SetInt("TowerCount", nTowerCount);
        PlayerPrefs.SetString("Maps", m_strMapData);
        PlayerPrefs.SetInt("Diff", (int)(m_fDifficulty + 3.0f - ((float)(m_nStartResource) / 1300.0f) - ((float)(m_nStartCoinPrice) / 800.0f)));
    }


    public void savingData()
    {
        if (!Directory.Exists(Application.persistentDataPath + "/Maps"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Maps");
        }

        int nIndex = 0;
        while (File.Exists(Application.persistentDataPath + "/Maps/" + "CustomMap" + nIndex + ".txt"))
        {
            nIndex++;
        }



        FileStream fs = new FileStream(Application.persistentDataPath + "/Maps/" + "CustomMap" + nIndex + ".txt", FileMode.Create, FileAccess.Write);
        byte[] data = new byte[4000];


        data = Encoding.Default.GetBytes(AllString());
        fs.Write(data, 0, AllString().Length);

        //send to server
        Product product = new Product(playerManager.GetComponent<PlayerManager>().player_id, "...", "...", AllString());
        url += "/api/product/";
        Debug.Log(url + "  :: " + product.getJson());
        playerManager.GetComponent<HttpManager>().POST(url, product.getJson());


        fs.Close();


        CheckInData(nIndex);

    }



    private string AllString()
    {
        /*
1m2m1m2m1m2m1m2m1m2m1m2m
010101010101
010101010101
010101010101
010101010101
323232323232
101010101011
121212121212
121212121212
101010101010
303030303030
323232323232   ... Map
/13/0/1/1/3/0/ ... Row
,13,0,1,2,2,1, ... Col
c43572154c135432151c13541359c743155c ... nodeColor
:4:0:1:2:3     ... Tower
bc15648413bc   ... backgroudColor
.2.800.200.    ... Diffculty,StartResource,StartCoinprice
   */
        string data = "";

        data += '/';
        data += m_listRoadRow.Count;

        for (int i = 0; i < m_listRoadRow.Count; i++)
        {
            data += '/';
            data += m_listRoadRow[i];
        }
        data+= '/';


        data += ',';
        data += m_listRoadCol.Count;

        for (int i = 0; i < m_listRoadCol.Count; i++)
        {
            data += ',';
            data += m_listRoadCol[i];
        }
        data += ',';



        for (int i = 0; i < 4; i++)
        {
            data += 'c';
            data += m_arNodeColor[i];
        }
        data += 'c';


        data += ':';
        data += m_listSelectedTower.Count;
        for (int i = 0; i < m_listSelectedTower.Count; i++)
        {
            data += ':';
            data += m_listSelectedTower[i];
        }
        data += ':';


        data += 'b';
        data += m_nBackGroundColor;
        data += 'b';
        


        data += '.';  
        data += m_fDifficulty;
        data += '.';
        data += m_nStartResource;
        data += '.';
        data+= m_nStartCoinPrice;
        data += '.';




        string strData = "";
        strData = m_strMapData + data;

        return strData;
    }

    public void CheckInData(int nIndex)
    {
        while(!File.Exists(Application.persistentDataPath + "/Maps/" + "CustomMap" + nIndex + ".txt"))
        {

        }
        Destroy(gameObject);
    }



    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


    public string getMapString()
    {
        return m_strMapData;
    }
    public List<int> getRoadRow()
    {
        return m_listRoadRow;
    }
    public List<int> getRoadCol()
    {
        return m_listRoadCol;
    }
    public int getBackGroundColor()
    {
        return m_nBackGroundColor;
    }
    public List<int> getListSelectedTower()
    {
        return m_listSelectedTower;
    }
    public int[] getNodeColor()
    {
        return m_arNodeColor;
    }

    public float getDifficuty()
    {
        return m_fDifficulty;
    }
    public int getStartResource()
    {
        return m_nStartResource;
    }
    public int getStartCoinPrice()
    {
        return m_nStartCoinPrice;
    }

    public int getDiffcultGame() {
        return (int)(m_fDifficulty + 3.0f - ((float)(m_nStartResource) / 1300.0f) - ((float)(m_nStartCoinPrice)/800.0f));
    }


    public void writeStringToFile(string str, string filename)
    {
#if !WEB_BUILD
        string path = pathForDocumentsFile(filename);
        FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write);

        StreamWriter sw = new StreamWriter(file);
        sw.WriteLine(str);

        sw.Close();
        file.Close();
#endif
    }


    public string readStringFromFile(string filename)//, int lineIndex )
    {
#if !WEB_BUILD
        string path = pathForDocumentsFile(filename);

        if (File.Exists(path))
        {
            FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(file);

            string str = null;
            str = sr.ReadLine();

            sr.Close();
            file.Close();

            return str;
        }

        else
        {
            return null;
        }
#else
return null;
#endif
    }


    public string pathForDocumentsFile(string filename)
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            string path = Application.dataPath.Substring(0, Application.dataPath.Length - 5);
            path = path.Substring(0, path.LastIndexOf('/'));
            return Path.Combine(Path.Combine(path, "Documents"), filename);
        }

        else if (Application.platform == RuntimePlatform.Android)
        {
            string path = Application.persistentDataPath;
            path = path.Substring(0, path.LastIndexOf('/'));
            return Path.Combine(path, filename);
        }

        else
        {
            string path = Application.dataPath;
            path = path.Substring(0, path.LastIndexOf('/'));
            return Path.Combine(path, filename);
        }
    }


    
}
