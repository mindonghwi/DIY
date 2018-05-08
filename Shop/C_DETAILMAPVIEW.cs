using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;

public class C_DETAILMAPVIEW : MonoBehaviour {

    private GridLayoutGroup m_lygContent;
    private GameObject m_goStars;
    [SerializeField]
    private C_LOADCUSTOMMAPDATA m_cLoadCustomMapData;
    private GameObject[,] m_arTmpImage;
    // Use this for initialization
    void Start()
    {
        m_cLoadCustomMapData = GameObject.Find("LoadData").GetComponent<C_LOADCUSTOMMAPDATA>();

    }

    public void ReturnData()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Destroy(gameObject.transform.GetChild(i).gameObject);
        }

        float fSellWidthSize = 0;
        float fSellHeightSize = 0;
        fSellWidthSize = gameObject.transform.GetComponent<RectTransform>().rect.width *
            (gameObject.transform.GetComponent<RectTransform>().anchorMax.x - gameObject.transform.GetComponent<RectTransform>().anchorMin.x) / 12.0f - 2.0f;
        fSellHeightSize = gameObject.transform.GetComponent<RectTransform>().rect.height *
            (gameObject.transform.GetComponent<RectTransform>().anchorMax.y - gameObject.transform.GetComponent<RectTransform>().anchorMin.y) / 12.0f - 2.0f;
        m_lygContent = gameObject.GetComponent<GridLayoutGroup>();


        m_lygContent.cellSize = new Vector2(fSellHeightSize, fSellHeightSize);

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

                m_arTmpImage[i, j].GetComponent<Image>().color = intChangeColor(m_cLoadCustomMapData.getNodeColor(m_cLoadCustomMapData.getNode(i, j)));

                nIndex++;
            }
            nIndex++;
        }

        m_goStars = gameObject.transform.parent.GetChild(0).gameObject;

        int nDifficultyGame = (int)(m_cLoadCustomMapData.getDiffculty() + 3.0f - ((float)(m_cLoadCustomMapData.getStartResource()) / 1300.0f) - ((float)(m_cLoadCustomMapData.getStartCoinPrice()) / 800.0f));
        for (int i = 0; i < nDifficultyGame; i++)
        {
            m_goStars.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    public void setData(C_LOADCUSTOMMAPDATA cLoadCustomData)
    {
        m_cLoadCustomMapData = cLoadCustomData;
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

    // Update is called once per frame
    void Update () {
		
	}


}
