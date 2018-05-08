using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.U2D;
using UnityEngine.SceneManagement;
public class C_CUSTOMMAPBTN : MonoBehaviour {


    private GridLayoutGroup m_lygContent;

    private GameObject[,] m_arTmpImage;

    private string m_strMapData;
    private int[,] m_arDefenceMapIndex;
    private int[] m_arNodeColor;
    private Button m_btnStartGame;
    private int m_nMapNum;
    void Start()
    {
        m_btnStartGame = gameObject.AddComponent<Button>();
        m_btnStartGame.onClick.AddListener(() => onClickBtn());
    }
    void onClickBtn()
    {
        PlayerPrefs.SetInt("CustomMapNum", m_nMapNum);
        SceneManager.LoadScene(6);
    }
    public void ReturnData()
    {
        float fSellWidthSize = 0;
        float fSellHeightSize = 0;
        gameObject.AddComponent<RectTransform>();

        fSellWidthSize = gameObject.transform.GetComponent<RectTransform>().rect.width/ 12.0f;
        fSellHeightSize = gameObject.transform.GetComponent<RectTransform>().rect.height / 12.0f;
        m_lygContent = gameObject.AddComponent<GridLayoutGroup>();
        m_lygContent.startCorner = GridLayoutGroup.Corner.LowerLeft;
        m_lygContent.startAxis = GridLayoutGroup.Axis.Vertical;

        m_lygContent.cellSize = new Vector2(18.0f, 18.0f);

        GameObject goImage = new GameObject();
        goImage.AddComponent<Image>();
        goImage.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);


        int nIndex = 0;
        m_arTmpImage = new GameObject[12, 12];
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 12; j++)
            {
                m_arTmpImage[i, j] = Instantiate(goImage);
                m_arTmpImage[i, j].transform.SetParent(gameObject.transform);
                m_arTmpImage[i, j].transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

                m_arTmpImage[i, j].GetComponent<Image>().color = intChangeColor(m_arNodeColor[m_arDefenceMapIndex[i,j]]);

                nIndex++;
            }
            nIndex++;
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

    private uint colorChangeInt(Color32 colorData)
    {
        uint nColor = 0;

        nColor = (uint)((colorData.r << 24) | (colorData.g << 16) |
                     (colorData.b << 8) | (colorData.a << 0));
        return nColor;
    }

    public void init(int nIndex)
    {
        FileStream fsMapData = new FileStream(Application.persistentDataPath + "/Maps/" + "CustomMap" + nIndex + ".txt", FileMode.Open, FileAccess.Read);
        StreamReader srMapData = new StreamReader(fsMapData);
        m_strMapData = srMapData.ReadToEnd();
        srMapData.Close();
        fsMapData.Close();
        m_nMapNum = nIndex;
    }

    public void parse()
    {
        m_arDefenceMapIndex = new int[12, 12];
        m_arNodeColor = new int[4];

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
        arTmpData = m_strMapData.Split('c');
        for (int i = 0; i < 4; i++)
        {
            m_arNodeColor[i] = int.Parse(arTmpData[i + 1]);
        }

        arTmpData = m_strMapData.Split('.');
        PlayerPrefs.SetFloat("CustomGameDifficulty", float.Parse(arTmpData[1]));
    }
}
