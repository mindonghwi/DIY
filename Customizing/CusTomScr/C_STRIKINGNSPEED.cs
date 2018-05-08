using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_STRIKINGNSPEED : MonoBehaviour {

    private C_DATASETTING m_cDataSetting;
    private Text m_txtStrikingText;
    private Text m_txtAttackSpeedText;
    private Text m_txtPointText;
    // Use this for initialization

    void Start () {
        m_cDataSetting = GameObject.Find("MainCanvas").GetComponent<C_DATASETTING>();
        m_txtPointText = gameObject.transform.GetChild(1).GetChild(0).GetComponent<Text>();
        m_txtStrikingText = gameObject.transform.GetChild(2).GetComponent<Text>();
        m_txtAttackSpeedText = gameObject.transform.GetChild(3).GetComponent<Text>();
    }
	
    public void SettingStrikingnSpeed()
    {
        if (!m_cDataSetting)
        {
            Start();
        }
        m_txtPointText.text = m_cDataSetting.getSALeftPt().ToString();
        m_txtAttackSpeedText.text = "Strking Speed : " + m_cDataSetting.getAttackSpeedRealValue(m_cDataSetting.getGrade()).ToString("N2");
        m_txtStrikingText.text = "Strking : " + m_cDataSetting.getStrikingRealValue(m_cDataSetting.getGrade()).ToString("N2");
    }
	
}
