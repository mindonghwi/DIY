using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;

public class C_DETAILTOWERSCROLLVIEWSIZE : MonoBehaviour {

    private GridLayoutGroup m_lygContent;
    private int nTowerCount;
    private List<int> m_listTower;

    private C_LOADCUSTOMMAPDATA m_cLoadCustomMapData;

    // Use this for initialization
    void Start()
    {
        m_cLoadCustomMapData = GameObject.Find("LoadData").GetComponent<C_LOADCUSTOMMAPDATA>();


    }

    public void ReturnTowers()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Destroy(gameObject.transform.GetChild(i).gameObject);
        }

        float fSellWidthSize = 0;
        float fSellHeightSize = 0;
        fSellWidthSize = gameObject.transform.parent.parent.parent.GetComponent<RectTransform>().rect.width *
            (gameObject.transform.parent.parent.GetComponent<RectTransform>().anchorMax.x - gameObject.transform.parent.parent.GetComponent<RectTransform>().anchorMin.x) / 3.0f - 40.0f;
        fSellHeightSize = gameObject.transform.parent.parent.parent.GetComponent<RectTransform>().rect.height *
            (gameObject.transform.parent.parent.GetComponent<RectTransform>().anchorMax.y - gameObject.transform.parent.parent.GetComponent<RectTransform>().anchorMin.y) / 3.0f - 40.0f;
        m_lygContent = gameObject.GetComponent<GridLayoutGroup>();


        m_lygContent.cellSize = new Vector2(fSellWidthSize, fSellHeightSize);
        nTowerCount = m_cLoadCustomMapData.getTowerCount();

        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0.0f, fSellHeightSize * (float)nTowerCount);

        m_listTower = new List<int>();


        for (int i = 0; i < nTowerCount; i++)
        {
            m_listTower.Add(m_cLoadCustomMapData.getTowerSelected()[i]);
        }

        Sprite[] m_arTowerImage = Resources.LoadAll<Sprite>("TowerSelect");

        GameObject goImage = new GameObject();
        goImage.AddComponent<Image>();
        //goImage.AddComponent<CanvasRenderer>();

        for (int i = 0; i < nTowerCount; i++)
        {
            GameObject goTmpImage = Instantiate(goImage);
            goTmpImage.transform.SetParent(gameObject.transform);
            goTmpImage.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            if (m_listTower[i] < 25)
            {
                goTmpImage.GetComponent<Image>().sprite = m_arTowerImage[m_listTower[i]];
            }
            else
            {
                goTmpImage.GetComponent<Image>().sprite = m_arTowerImage[24];
            }
        }
    }
    public void setData(C_LOADCUSTOMMAPDATA cLoadCustomData)
    {
        m_cLoadCustomMapData = cLoadCustomData;
    }



    // Update is called once per frame
    void Update () {
		
	}
}
