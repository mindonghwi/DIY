using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_MAINBTN : MonoBehaviour {

    [SerializeField]
    private GameObject[] m_arDetailBtn;
    private GameObject m_goQuestionBox;

    // Use this for initialization
    void Start () {

        m_arDetailBtn = new GameObject[gameObject.transform.childCount - 1];

        for (int i = 1; i < gameObject.transform.childCount; i++)
        {
            m_arDetailBtn[i - 1] = gameObject.transform.GetChild(i).gameObject;
        }
        m_goQuestionBox = GameObject.Find("QuestionCanvas");
        m_goQuestionBox.GetComponent<C_QUESTIONMESSAGEBOX>().CloseQuestionBox();
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
    public void btnMainDetailOnOff(int nIndex)
    {
        for (int i = 0; i < gameObject.transform.childCount -1; i++)
        {
            m_arDetailBtn[i].SetActive(false);
        }
        m_arDetailBtn[nIndex].SetActive(true);
    }

    public GameObject getDetialView(int nIndex)
    {
        return m_arDetailBtn[nIndex];
    }
}
