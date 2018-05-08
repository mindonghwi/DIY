using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using System.IO;
using UnityEngine.EventSystems;

public class C_SCROLLVIEWSIZE : MonoBehaviour
{

    private GridLayoutGroup m_lygContent;
    private int nMapCount;//서버에서 맵 갯수를 받아와야한다.
    private GameObject PlayerManager;
    private C_LOADCUSTOMMAPDATA m_cLoadCustomMapData;
    // Use this for initialization
    void Start()
    {
        m_cLoadCustomMapData = GameObject.Find("LoadData").GetComponent<C_LOADCUSTOMMAPDATA>();

        float fSellWidthSize = 0;
        float fSellHeightSize = 0;
        fSellWidthSize = gameObject.transform.parent.parent.parent.GetComponent<RectTransform>().rect.width *
            (gameObject.transform.parent.parent.GetComponent<RectTransform>().anchorMax.x - gameObject.transform.parent.parent.GetComponent<RectTransform>().anchorMin.x);
        fSellHeightSize = gameObject.transform.parent.parent.parent.GetComponent<RectTransform>().rect.height *
            (gameObject.transform.parent.parent.GetComponent<RectTransform>().anchorMax.y - gameObject.transform.parent.parent.GetComponent<RectTransform>().anchorMin.y) / 6.0f;
        m_lygContent = gameObject.GetComponent<GridLayoutGroup>();
        PlayerManager = GameObject.Find("PlayerManager");


        m_lygContent.cellSize = new Vector2(fSellWidthSize - m_lygContent.padding.left * 2.0f, fSellHeightSize);
        nMapCount = PlayerManager.GetComponent<ProductManager>().products.Count;

        //GameObject goButton = (GameObject)Resources.Load("ShopButton");
        GameObject goButton = (GameObject)Resources.Load("btnShop");

        GameObject goTmpButton;

        //for (int i = 0; i < nMapCount; i++)
        //{
        //    goTmpButton = Instantiate(goButton);
        //    goTmpButton.transform.SetParent(gameObject.transform);
        //    goTmpButton.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        //    goTmpButton.AddComponent<C_SHOPMAINSELECT>().init(i);
        //}

        GameObject m_goStars;

        for (int i = 0; i < nMapCount; i++)
        {
            goTmpButton = Instantiate(goButton);
            goTmpButton.transform.SetParent(gameObject.transform);
            goTmpButton.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            goTmpButton.transform.GetChild(1).gameObject.AddComponent<C_SHOPMAINSELECT>().init(i);

            m_goStars = goTmpButton.transform.GetChild(0).gameObject;
            m_cLoadCustomMapData.settingButton(i);
            int nDifficultyGame = (int)(m_cLoadCustomMapData.getDiffculty() + 3.0f - ((float)(m_cLoadCustomMapData.getStartResource()) / 1300.0f) - ((float)(m_cLoadCustomMapData.getStartCoinPrice()) / 800.0f));
            for (int j = 0; j < nDifficultyGame; j++)
            {
                m_goStars.transform.GetChild(j).gameObject.SetActive(true);
            }
        }


        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0.0f,fSellHeightSize * (float)nMapCount);

    }
    
    // Update is called once per frame
    void Update()
    {
    }
}
