using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_TARGETCOUNTNDOWNRANGE : MonoBehaviour {

    private C_DATASETTING m_cDataSetting;
    private Text m_txtTargetCountText;
    private Text m_txtDownRangeText;
    private Text m_txtPointText;
    // Use this for initialization

    void Start()
    {
        m_cDataSetting = GameObject.Find("MainCanvas").GetComponent<C_DATASETTING>();
        m_txtPointText = gameObject.transform.GetChild(1).GetChild(0).GetComponent<Text>();
        m_txtTargetCountText = gameObject.transform.GetChild(2).GetComponent<Text>();
        m_txtDownRangeText = gameObject.transform.GetChild(3).GetComponent<Text>();
    }

    public void SettingTargetCountnDownRange()
    {
        if (!m_cDataSetting)
        {
            Start();
        }
        m_txtPointText.text = m_cDataSetting.getTDLeftPt().ToString();
        m_txtTargetCountText.text = "TargetCount : " + m_cDataSetting.getTargetCount().ToString();
        m_txtDownRangeText.text = "DownRange : " + m_cDataSetting.getDownRangeRealValue(m_cDataSetting.getGrade()).ToString("N2");
    }
}
