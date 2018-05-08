using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_MAINBUTTON : MonoBehaviour {

    private GameObject[]  m_arDetailView;
    private C_SCENEMGR m_cSceneMgr;
    private GameObject m_goQuestionBox;

    public enum E_MAINBUTTON
    {
        E_MAINBUTTONS = 0,
        E_CLOTH,
        E_HAIR,
        E_ACC,
        E_AURA,
        E_BULLET,
        E_GRADE,
        E_STRIKINGANDSPEED,
        E_TARGETCOUNTANDDOWNRANGE,
        E_MAX,
    }

	// Use this for initialization
	void Start () {
        m_arDetailView = new GameObject[(int)E_MAINBUTTON.E_MAX];
        for (int i = 0; i < (int)E_MAINBUTTON.E_MAX; i++)
        {
            m_arDetailView[i] = GameObject.Find("MainCanvas").transform.GetChild(i).gameObject;
        }
        m_cSceneMgr = gameObject.GetComponent<C_SCENEMGR>();
        m_goQuestionBox = GameObject.Find("QuestionCanvas");
        m_goQuestionBox.GetComponent<C_QUESTIONMESSAGEBOX>().CloseQuestionBox();
    }
	
    public void setActiveDetailView(int nIndex)
    {
        for (int i = 1; i < (int)E_MAINBUTTON.E_MAX; i++)
        {
            m_arDetailView[i].SetActive(false);
        }

        m_arDetailView[nIndex].SetActive(true);
        
    }

    public void btnFinish()
    {
        m_cSceneMgr.mainScene();
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
