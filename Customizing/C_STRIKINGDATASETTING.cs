using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class C_STRIKINGDATASETTING : MonoBehaviour {

    private float m_fStriking;
    private float m_fSpeedOfStriking;
    private int m_nTargetCount;
    private int m_nTowerGrade;
    private float m_fDownrange;

    private Slider m_scbStriking;
    private Slider m_scbSpeedOfStriking;
    private Slider m_scbTargetCount;
    private Slider m_scbTowerGarade;
    private Slider m_scbDownrange;

    // Use this for initialization
    void Start () {
        //1357
        m_scbStriking = gameObject.transform.GetChild(1).GetChild(0).GetComponent<Slider>();
        m_scbSpeedOfStriking = gameObject.transform.GetChild(3).GetChild(0).GetComponent<Slider>();
        m_scbTargetCount = gameObject.transform.GetChild(5).GetChild(0).GetComponent<Slider>();
        m_scbTowerGarade = gameObject.transform.GetChild(7).GetChild(0).GetComponent<Slider>();
        m_scbDownrange = gameObject.transform.GetChild(9).GetChild(0).GetComponent<Slider>();

        m_fStriking = 0.0f;

    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void scbStriking()
    {
        m_fStriking = m_scbStriking.value;
    }
    public void scbSpeedOfStriking()
    {
        m_fSpeedOfStriking = m_scbSpeedOfStriking.value;
    }
    public void scbTargetCount()
    {
        m_nTargetCount = (int)m_scbTargetCount.value;
    }
    public void scbDownrange()
    {
        m_fDownrange = m_scbDownrange.value;
    }
    public void scbTowerGrade()
    {
        m_nTowerGrade = (int)m_scbTowerGarade.value;
    }




    public void btnFinshTower()
    {
        //기본타워 수가 들어와 있고 그 다음것부터 주면된다 타워번호
        GameObject.Find("Cus").GetComponent<C_CREATETOWER>().getCustomTower().GetComponent<C_CUSTOMTOWER>().init(m_fStriking, m_fDownrange, m_fSpeedOfStriking,m_nTargetCount,25);
        Debug.Log(m_fStriking+" "+ m_fDownrange + " " + m_fSpeedOfStriking + " " + m_nTargetCount);

        PlayerPrefs.SetFloat("striking", m_fStriking);
        PlayerPrefs.SetFloat("speedOfStriking", m_fSpeedOfStriking);
        PlayerPrefs.SetInt("targetCount", m_nTargetCount);
        PlayerPrefs.SetFloat("downrange", m_fDownrange);
        PlayerPrefs.SetInt("grade", m_nTowerGrade);
    }

}
