using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_GAMEOVER : MonoBehaviour {

    private GameObject[] m_arMainName;

	// Use this for initialization
	void Start () {
        int nMainNameIndex = gameObject.transform.GetChild(0).childCount;
        m_arMainName = new GameObject[nMainNameIndex];

        for (int i = 0; i < nMainNameIndex; i++)
        {
            m_arMainName[i] = gameObject.transform.GetChild(0).GetChild(i).gameObject;
            m_arMainName[i].SetActive(false);
        }
    }
	
	public void GameEnding(bool bGameOver)
    {
        GameObject goUiHolder = GameObject.Find("UiHolder");

        for (int i = 0; i < goUiHolder.transform.childCount; i++)
        {
            Destroy(goUiHolder.transform.GetChild(i).gameObject);
        }

        if (bGameOver)
        {
            m_arMainName[0].SetActive(true);
        }
        else
        {
            m_arMainName[1].SetActive(true);
        }
    }
}
