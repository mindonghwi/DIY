using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_MAPDETAILBTNCTN : MonoBehaviour {
    private C_MAPEDITMR m_cMapEditMgr;
    private C_MAINBTN m_cMainBtn;
    private Dropdown m_ddDifficulty;
    private Dropdown m_ddStartResources;
    private Dropdown m_ddStartingCoinPrice;


    // Use this for initialization
    void Start () {
        m_cMapEditMgr = GameObject.Find("MapEditer").GetComponent<C_MAPEDITMR>();
        m_cMainBtn = gameObject.GetComponent<C_MAINBTN>();

        GameObject goGameSettingView = GameObject.Find("MainCanvas").GetComponent<C_MAINBTN>().getDetialView(4).transform.GetChild(1).gameObject;

        m_ddDifficulty = goGameSettingView.transform.GetChild(0).GetChild(1).GetComponent<Dropdown>();
        m_ddStartingCoinPrice = goGameSettingView.transform.GetChild(2).GetChild(1).GetComponent<Dropdown>();
        m_ddStartResources = goGameSettingView.transform.GetChild(1).GetChild(1).GetComponent<Dropdown>();

    }
	
    public void btnSelectNode(int nIndexOffset)
    {
        m_cMapEditMgr.setNodeIndex(nIndexOffset);

        m_cMapEditMgr.createNode(nIndexOffset);
    }

    public void btnSelectNodeColor(int nIndex)
    {
        m_cMapEditMgr.selectNodeColor(colorChangeInt(m_cMainBtn.getDetialView(0).transform.GetChild(1).GetChild(1).GetChild(nIndex).GetComponent<Button>().colors.normalColor)
            , m_cMapEditMgr.getNodeIndex());
    }

    public void btnSelectBackgroundColor(int nIndex)
    {
        m_cMapEditMgr.selectBackGroudColor(colorChangeInt(m_cMainBtn.getDetialView(0).transform.GetChild(1).GetChild(1).GetChild(nIndex).GetComponent<Button>().colors.normalColor));
    }

    public void btnSelectedTower(int nIndex)
    {
        m_cMapEditMgr.selectInputTower(nIndex);
    }

    public void btnFloorReturn()
    {
        m_cMapEditMgr.returnFloor();
    }

    public void btnFloorSettingStart()
    {
        m_cMapEditMgr.startFloor();
    }

    public void btnFloorSetting()
    {
        m_cMapEditMgr.setFloor();
    }

    public void btnFloorRemove()
    {
        m_cMapEditMgr.removeFloor();
    }


    private int colorChangeInt(Color32 colorData)
    {
        int nColor = 0;

        nColor = (int)((colorData.r << 24) | (colorData.g << 16) |
                     (colorData.b << 8) | (colorData.a << 0));

        return nColor;
    }

    void OnDestroy()
    {
        m_cMapEditMgr.release();
        m_cMapEditMgr = null;
    }
}
