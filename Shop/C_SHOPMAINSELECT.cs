using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using System.IO;
using UnityEngine.EventSystems;


public class C_SHOPMAINSELECT : MonoBehaviour {

    private Button m_btnMy;
    private int m_nMyNum;
    private C_BTNCTR m_cBtnCtr;
    private C_LOADCUSTOMMAPDATA m_cLoadCustomMapData;

	// Use this for initialization
	void Start () {
        m_cLoadCustomMapData = GameObject.Find("LoadData").GetComponent<C_LOADCUSTOMMAPDATA>();
        m_cBtnCtr = GameObject.Find("Canvas").GetComponent<C_BTNCTR>();

        m_btnMy = gameObject.GetComponent<Button>();

        m_btnMy.onClick.AddListener(() => OnClick());

    }
	void OnClick()
    {
        m_cBtnCtr.btnOpenDetail();
        m_cLoadCustomMapData.settingDetailView(m_nMyNum);
    }

    public void init(int nNum)
    {
        m_nMyNum = nNum;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
