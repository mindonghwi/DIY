using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_BTNCTR : MonoBehaviour {

    private GameObject m_goDetailView;
    private GameObject m_goShopView;
    private GameObject m_goQuestionView;
    private GameObject m_goQuestionBox;

    // Use this for initialization
    void Start () {
        m_goShopView = gameObject.transform.GetChild(0).gameObject;
        m_goDetailView = gameObject.transform.GetChild(1).gameObject;
        m_goQuestionView = gameObject.transform.GetChild(2).gameObject;

        m_goQuestionBox = GameObject.Find("QuestionCanvas");
        m_goQuestionBox.GetComponent<C_QUESTIONMESSAGEBOX>().CloseQuestionBox();

    }
	

    public void btnOpenDetail()
    {
        m_goDetailView.SetActive(true);
        m_goShopView.SetActive(false);
    }

    public void btnCloseDetail()
    {
        m_goDetailView.SetActive(false);
        m_goShopView.SetActive(true);
    }
    public void btnSellMaps()
    {
        m_goQuestionView.SetActive(true);
    }
    public void btnNotSellMaps()
    {
        m_goQuestionView.SetActive(false);
    }

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                m_goQuestionBox.GetComponent<C_QUESTIONMESSAGEBOX>().setQuestionBox();
            }
        }
    }
}
